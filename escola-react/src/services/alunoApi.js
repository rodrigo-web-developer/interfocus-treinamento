const URL_API = "https://localhost:7236";

export function listarAlunos(pesquisa) {
    // PROMISE
    var response = pesquisa ?
        fetch(URL_API + "/api/aluno?pesquisa=" + pesquisa) :
        fetch(URL_API + "/api/aluno");

    return response;
}

export function getByCodigo(codigo) {
    // PROMISE
    var response = fetch(URL_API + "/api/aluno/" + codigo);
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
        method: aluno.codigo ? "PUT" : "POST",
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

export function uploadImagem(form, codigo) {
    // PROMISE
    var formData = new FormData(form);
    var request = {
        method: "POST",
        body: formData
    }

    var response = fetch(URL_API + "/api/aluno/uploadimagem/" + codigo, request)
    return response;
}