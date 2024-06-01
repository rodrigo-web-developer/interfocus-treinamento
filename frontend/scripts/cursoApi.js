var x = 10;
const c = "";
let i = 10;

const URL_API = "https://localhost:7236";

function listarCursos() {
    // PROMISE
    var response = fetch(URL_API + "/api/curso")
    return response;
}

function postCurso(curso) {
    // PROMISE
    var request = {
        method: "POST",
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

function preencherTabela() {
    var tabela = document.getElementById("table-cursos");
    listarCursos().then((resultado) => {
        if (resultado.status == 200) {
            resultado.json().then(
                cursos => {
                    var tbody = tabela.querySelector("tbody");
                    cursos.forEach(curso => {
                        tbody.innerHTML += `<tr>
                            <td>${curso.id}</td>
                            <td>${curso.nome}</td>
                            <td>${curso.descricao}</td>
                        </tr>`
                    });
                }
            )
        }
    })
}

function criarCurso(event){
    event.preventDefault();
    var dados = new FormData(event.target);
    var objCurso = {
        nome: dados.get("nome"),
        nivel: Number(dados.get("nivel")),
        duracao: Number(dados.get("duracao")),
        descricao: dados.get("descricao"),
    }

    postCurso(objCurso)
    .then(resultado => {
        if (resultado == 200){

        }
        else if (resultado == 422){
            
        }
    })
}
