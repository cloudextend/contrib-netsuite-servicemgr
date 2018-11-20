const fse = require( 'fs-extra' );
const readPkgUp = require( 'read-pkg-up' );
const chalk = require( 'chalk' );

console.log( `${chalk.yellow.bold( 'Performing post-release cleanup...' )}\n` );

readPkgUp()
.then( response => {
    const { 'pkg': { 'release': { 'sandbox': sandboxFolderPath } } } = response;

    return fse.remove( sandboxFolderPath )
    .then( () => { console.log( `${chalk.green( `Deleted "${sandboxFolderPath}" folder.` )}\n` ); } )
    .catch( error => { console.error( chalk.red.bold( error ) ); } );
} );
