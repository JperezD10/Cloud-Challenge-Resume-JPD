window.addEventListener("DOMContentLoaded", (event) => {
  getVisitors();
})

const functionApi = "http://localhost:7020/api/GetResume";

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

