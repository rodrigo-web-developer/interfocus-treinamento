var x = 10;
const c = "";
let i = 10;

function listarCursos() {
    // PROMISE
    var response = fetch(URL_API + "/api/curso")
    return response;
}

function postCurso(curso) {
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

async function criarCurso(event) {
    event.preventDefault();
    var dados = new FormData(event.target);
    var confirmou = await confirmar("Deseja seguir com a criação de um novo curso?");
    if (!confirmou) {
        return;
    }
    var form = event.target;
    var objCurso = {
        nome: dados.get("nome"),
        nivel: Number(dados.get("nivel")),
        duracao: Number(dados.get("duracao")),
        descricao: dados.get("descricao"),
    }

    postCurso(objCurso)
        .then(resultado => {
            if (resultado.status == 200) {
                var tabela = document
                    .getElementById("table-cursos")
                    .querySelector("tbody");
                tabela.innerHTML = "";
                preencherTabela();
            }
            else if (resultado.status == 422) {
                resultado.json().then(erros => {
                    erros.forEach(erro => {
                        const { memberNames, errorMessage } = erro;
                        const [campo] = memberNames;
                        const input = form.querySelector(`[name=${campo.toLowerCase()}]`);
                        const erroMessage = input.parentNode.querySelector(".error")
                        erroMessage.innerHTML = errorMessage;
                    })
                })
            }
        });

}
