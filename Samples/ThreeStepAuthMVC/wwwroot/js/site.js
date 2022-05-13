// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
login  = function(){
    const account = document.getElementById("AccountName").value;
   
    sessionStorage.clear();
    console.log(`Logging in to ${account}...`);
    
    var url = `/api/tsa/request-token?account=${account}`;
    fetch(url)
        .then((response)=>{
            if ( response.status === 200) {
                return response.json();
            }
            else { throw Error(response);}
        })
        .then((result)=> {
            sessionStorage.setItem("celigo_oauth_token_secret", result.tokenSecret);
            sessionStorage.setItem("celigo_account", account);

            window.location.href = `https://${account}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token=${result.token}`;
        })
        .catch((error) => {
            console.log(error);
        })
}