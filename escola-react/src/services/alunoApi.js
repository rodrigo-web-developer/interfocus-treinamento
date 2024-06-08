const URL_API = "https://localhost:7236";

export function listarAlunos(pesquisa) {
    // PROMISE
    var response = pesquisa ?
        fetch(URL_API + "/api/aluno?pesquisa=" + pesquisa) :
        fetch(URL_API + "/api/aluno");

    return response;
}

export function deletarAluno(id) {
    // PROMISE
    var request = {
        method: "DELETE"
    }
    var response = fetch(URL_API + "/api/aluno/" + id, request)
    return response;
}

export function postAluno(aluno) {
    // PROMISE
    var request = {
        method: aluno.id ? "PUT" : "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(aluno)
    }
    var response =
        fetch(URL_API + "/api/aluno",
            request)
    return response;
}