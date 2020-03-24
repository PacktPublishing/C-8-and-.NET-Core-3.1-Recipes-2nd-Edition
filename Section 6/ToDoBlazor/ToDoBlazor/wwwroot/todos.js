async function fetchToDos() {
    let response = await fetch("http://jsonplaceholder.typicode.com/todos");
    let todos = await response.json();
    console.log("Todos: ", todos);
    return todos;
}