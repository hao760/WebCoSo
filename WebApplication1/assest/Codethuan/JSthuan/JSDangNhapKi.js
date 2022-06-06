var btn = document.getElementById("customCheck");
var passs = document.querySelector('.anpass');

btn.addEventListener('change', (event) => {
    if (event.currentTarget.checked)
        passs.setAttribute("type", "text");
    else
        passs.setAttribute("type", "password");
    
})