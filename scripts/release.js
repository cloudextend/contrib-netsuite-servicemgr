const fse = require( 'fs-extra' );
const simpleGit = require( 'simple-git/promise' );
const readPkgUp = require( 'read-pkg-up' );
const listr = require( 'listr' );
const chalk = require( 'chalk' );

const tempGitFolder = './.temp-git';

const taskArray = [];

taskArray.push( {
    'title': 'Read the closest package.json for the release-config and the version number...',
    'task': context => {
        return readPkgUp()
        .then( ( { 'pkg': package } ) => {
            if ( !package.release ) {
                throw {
                    'code': 'MISSING_RELEASE_CONFIG',
                    'message': "The package.json doesn't have a release config set in it."
                };
            }

            context.release = package.release;

            if ( !package.version ) {
                throw {
                    'code': 'MISSING_VERSION_NUMBER',
                    'message': "The package.json doesn't have a version number set in it."
                };
            }

            context.version = package.version;
        } );
    }
} );

taskArray.push( {
    'title': 'Perform the pre-release cleanup...',
    'task': context => {
        return fse.remove( context.release.sandbox )
        .then( () => fse.remove( tempGitFolder ) );
    }
} );

taskArray.push( {
    'title': 'Clone the dist repository...',
    'task': context => {
        const { 'release': { repo, sandbox }, branch } = context;

        return simpleGit()
        .clone( repo, sandbox, [ `--branch=${branch}` ] )
        .then( () => { context.localGit = simpleGit( sandbox ); } );
    }
} );

taskArray.push( {
    'title': 'Check the existing tags for the current version tag...',
    'task': ( { localGit, version } ) => {
        return localGit.tags()
        .then( tags => {
            if ( tags.all.includes( `v${version}` ) ) {
                throw {
                    'code': 'TAG_ALREADY_EXISTS',
                    'message': `A tag for "v${version}" already exists.`
                };
            }
        } );
    }
} );

taskArray.push( {
    'title': 'Copy the updated files to the sandbox for commiting...',
    'task': ( { 'release': { 'include': filesToInclude, sandbox, dist } } ) => new listr( [
        {
            'title': `Copy the contents of the "${sandbox}/.git" to the "${tempGitFolder}"...`,
            'task': () => fse.copy( `${sandbox}/.git`, `${tempGitFolder}`, { 'overwrite': true } )
        },
        {
            'title': `Purge the "${sandbox}" before copying the changes...`,
            'task': () => fse.emptyDir( `${sandbox}` )
        },
        {
            'title': `Copy back the contents of the "${tempGitFolder}" to the "${sandbox}/.git"...`,
            'task': () => fse.copy( `${tempGitFolder}`, `${sandbox}/.git`, { 'overwrite': true } )
        },
        {
            'title': `Delete the "${tempGitFolder}" folder...`,
            'task': () => fse.remove( `${tempGitFolder}` )
        },
        {
            'title': `Copy the contents of the "${dist}" to the "${sandbox}"...`,
            'task': () => fse.copy( `${dist}`, `${sandbox}`, { 'overwrite': true } )
        },
        {
            'title': `Copy the files/folders mentioned in the release config's "include"...`,
            'task': () => filesToInclude.reduce(
                ( previousPromise, { src, relativeDest } ) => previousPromise.then( () => {
                    return fse.copy( `${src}`, `${sandbox}${relativeDest}`, { 'overwrite': true } );
                } ),
                Promise.resolve()
            )
        },
    ] )
} );

taskArray.push( {
    'title': 'Create a commit for all the file changes...',
    'task': () => new listr( [
        {
            'title': 'Stage all the file changes for the commit...',
            'task': ( { localGit } ) => localGit.add( './*' )
        },
        {
            'title': 'Commit the staged files with the given commit message...',
            'task': ( { localGit, version } ) => localGit.commit( `release the version ${version}` )
        }
    ] )
} );

taskArray.push( {
    'title': 'Create a release tag for the commit just created...',
    'task': ( { localGit, version } ) => localGit.tag( [ `v${version}` ] )
} );

taskArray.push( {
    'title': 'Push the commit and the tag to the dist repository...',
    'task': ( { localGit, branch } ) => localGit.push( 'origin', branch ).then( () => localGit.pushTags( 'origin' ) )
} );

const branch = process.argv[ 2 ] || 'master';

const tasks = new listr( taskArray );

console.log( `${chalk.yellow.bold( 'Performing a release, for the current version, to the dist repository.' )}\n` );

tasks.run( { branch } )
.then( () => {
    console.log( `\n\n${chalk.green( 'The release, for the current version, to the dist repo, was successful.' )}\n` );
} )
.catch( error => {
    console.log( `\n\n${chalk.red.bold( `ERROR:${error.code ? ' [' + error.code + '] - ' : ''} ${error.message}` )}` );
} );
