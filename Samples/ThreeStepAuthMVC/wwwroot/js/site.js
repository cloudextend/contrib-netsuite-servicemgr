// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
login  = function(){
    const account = document.getElementById("AccountName").value;
   
    sessionStorage.clear();
    console.log(`Logging in to ${account}...`);
    var request = window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");
    
    if(request){
        var url = `/api/tsa/request-token?account=${account}`;
        request.open("GET", url, false);
        request.setRequestHeader("Content-Type", "application/json");
        request.onreadystatechange = function () {
            if (request.readyState === 4 && request.status === 200) {
                var response = JSON.parse(request.responseText);
                sessionStorage.setItem("celigo_oauth_token_secret", response.tokenSecret);
                sessionStorage.setItem("celigo_account", account);

                window.location.href = `https://${account}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token=${response.token}`;
            }
            
        };
        request.send();
    }
    
    
}