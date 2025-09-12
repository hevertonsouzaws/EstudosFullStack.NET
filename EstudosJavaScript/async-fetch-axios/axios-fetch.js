// 1 - get fetch

fetch('https://jsonplaceholder.typicode.com/todos')
    .then((response) => response.json())
    .then((data) => {
        console.log('Retorno do FETCH:')
        console.log(data)
    }).catch((error) => {
        console.log(error)
    })


// 2 - get com axios
axios
    .get("https://jsonplaceholder.typicode.com/todos")
    .then((response) => {
        console.log('Retorno do AXIOS')
        console.log(response.data)
    }).catch((error) => {
        console.log(error);
    })

// 3 - POST com fetch

const data = {
    title: "#SomosWS",
    content: "POST com fetch",
    userId: 1
}

fetch('https://jsonplaceholder.typicode.com/posts', {
    method: "POST",
    headers: {
        "Content-Type": "application/json" // tipo de contéudo 
    },
    body: JSON.stringify(data),  //converte para Json    
})
    .then((response) => response.json())
    .then((data) => {
        console.log('Retorno POST do FETCH:')
        console.log(data)
    }).catch((error) => {
        console.log(error)
    })


// 4 - POST com axios

axios.post('https://jsonplaceholder.typicode.com/posts', data)
    .then((response) => {
        console.log('Retorno POST do AXIOS')
        console.log(response.data)
    }).catch((error) => {
        console.log(error);
    })


// Testando api do projeto 

axios
    .get("https://localhost:7166/api/Employees/")
    .then((response) => {
        console.log('Retorno PROJETOWS do AXIOS')
        console.log(response.data)
    }).catch((error) => {
        console.log(error);
    })


const employee = {
    name: "Index axios",
    position: "Post com axios"
}

axios
    .post('https://localhost:7166/api/Employees/', employee)
    .then((response) => {
        console.log('Retorno POST no projeto')
        console.log(response.employee)
    }).catch((error) => {
        console.log(error);
    })