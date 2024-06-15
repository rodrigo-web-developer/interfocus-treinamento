
const URL_API = "https://localhost:7236";

function listarAlunos() {
    // PROMISE
    var response = fetch(URL_API + "/api/aluno")
    return response;
}

function deletarAluno(id) {
    // PROMISE
    var request = {
        method: "DELETE"
    }
    var response = fetch(URL_API + "/api/aluno/" + id, request)
    return response;
}

function postAluno(aluno) {
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

async function excluirAluno(id) {
    const confirmou = await confirmar("Deseja confirmar a exclusão do aluno?");
    if (confirmou){
        await deletarAluno(id);
        var grid = document.getElementById("grid-alunos");
        grid.innerHTML = "";
        carregarAlunos();
    }
    console.log("RETORNO DA PROMISE::::::", confirmou);
}

function confirmar(texto) {
    var confirm = document.createElement("div");
    confirm.classList.add("dialog");

    confirm.innerHTML = `<div class="content">
        <p>${texto}</p>
        <div class="acoes"></div>
        </div>
    `;

    var confirmButton = document.createElement("button");
    var declineButton = document.createElement("button");
    confirmButton.innerHTML = "Confirmar";
    declineButton.innerHTML = "Recusar";
    var acoes = confirm.querySelector(".acoes");

    acoes.appendChild(confirmButton);
    acoes.appendChild(declineButton);

    document.body.appendChild(confirm);

    return new Promise((funcaoThen) => {
        confirmButton.addEventListener("click", () => {
            document.body.removeChild(confirm);
            funcaoThen(true)
        });
        declineButton.addEventListener("click", () => {
            document.body.removeChild(confirm);
            funcaoThen(false)
        });
    });
}

async function carregarAlunos() {
    var resultado = await listarAlunos();
    if (resultado.status == 200) {
        var alunos = await resultado.json();
        var grid = document.getElementById("grid-alunos");
        alunos.forEach(aluno => {
            var data = new Date(aluno.dataNascimento);
            var dia = data.getDate().toString().padStart(2, '0');
            var mes = (data.getMonth() + 1).toString().padStart(2, '0');
            var ano = data.getFullYear();
            grid.innerHTML += `<div class="card">
                            <ul>
                                <li>Código: ${aluno.codigo}</li>
                                <li>Nome: ${aluno.nome}</li>
                                <li>Data de Nascimento: ${dia}/${mes}/${ano}</li>
                                <li>E-mail: ${aluno.email}</li>
                            </ul>
                            <div class="acoes">
                                <button type="button">Editar</button>
                                <button type="button" onclick="excluirAluno(${aluno.codigo})">Excluir</button>
                            </div>
                        </div>`;
        });
    }
}

function criarCurso(event) {
    event.preventDefault();
    var dados = new FormData(event.target);
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
