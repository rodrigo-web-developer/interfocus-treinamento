const URL_API = "http://172.16.102.202:5046";

export function listarAlunos(pesquisa, page, pageSize) {
    // PROMISE
    var data = page == 0 ? "" : `page=${page}&pageSize=${pageSize}`;

    var response = pesquisa ?
        fetch(URL_API + "/api/aluno?pesquisa=" + pesquisa + "&" + data) :
        fetch(URL_API + "/api/aluno?" + data);

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