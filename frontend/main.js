window.addEventListener("DOMContentLoaded", (event) => {
  getVisitors();
})

const functionApi = "https://getresumefunction.azurewebsites.net/api/GetResume?code=HB7cyRUy14kdOiiLwJP8x7rRT7YFPqpdyibE_ps_2berAzFuOjLaIQ==";

const getVisitors = () =>{
  let count = 0;
  fetch(functionApi).then(response => {
    return response.json()
  }).then(response =>{
    count = response.count;
    document.getElementById("visitor-count").innerHTML = `${count}`;
  }).catch(function(err){
    console.error(err)
  });
  return count
}

