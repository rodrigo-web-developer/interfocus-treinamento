const URL_API = "https://localhost:7236";

export function listarCursos(pesquisa) {
    // PROMISE
    var response = pesquisa ?
        fetch(URL_API + "/api/curso?busca=" + pesquisa) :
        fetch(URL_API + "/api/curso");

    return response;
}

export function getById(codigo) {
    // PROMISE
    var response = fetch(URL_API + "/api/curso/" + codigo);
    return response;
}

export function deletarCurso(id) {
    // PROMISE
    var request = {
        method: "DELETE"
    }
    var response = fetch(URL_API + "/api/curso/" + id, request)
    return response;
}

export function postCurso(curso) {
    // PROMISE
    var request = {
        method: curso.id ? "PUT" : "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(curso)
    }
    var response =
        fetch(URL_API + "/api/curso",
            request)
    return response;
}
