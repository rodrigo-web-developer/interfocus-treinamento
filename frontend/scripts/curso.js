var contador = 10;

function addCurso(evento) {
    var dados = new FormData(evento.target);

    var submit = evento.target
        .querySelector("button[type=submit]");


    console.log(submit);

    var indice = Number(dados.get("index"));
    if (indice > -1) {
        var nodeTr = document
            .querySelector("tbody")
            .children
            .item(indice);

        var [id, nome, descricao] =
            nodeTr.children;
        nome.innerHTML = dados.get("nome");
        descricao.innerHTML = dados.get("descricao");
        evento.target.reset();
    }
    else {

        submit.disabled = true;
        submit.innerHTML = "Enviando...";
        var linha = `
            <tr>
                <td>${contador++}</td>
                <td>${dados.get("nome")}</td>
                <td>${dados.get("descricao")}</td>
            </tr>
            `;

        //DOM
        var tabela =
            document.getElementsByTagName("table")[0];

        var [body] = tabela
            .getElementsByTagName("tbody");

        console.log("ANTES DE INCLUIR");

        setTimeout(() => {
            body.innerHTML += linha;
            console.log("INCLUÍDO");
            submit.innerHTML = "Novo Curso";
            submit.disabled = false;
            evento.target.reset();
        }, 2000);

        console.log("DEPOIS DE INCLUIR");

        var funcaoNormal = function () {
            console.log("blablabla")
        }

        var arrowFunction = () => {
            console.log("blablabla")
        }

        var arrowFunctionUnica =
            () => console.log("blablabla")

    }
    evento.preventDefault();
    console.log("FINALIZADO");
}

function selecionar(evento) {

    var { target } = evento;
    var nodeTR = target.closest("tr");
    // spread operator
    /*
    criar copia do array
    repassar copia de array como parametro
    transformar iteravel em array
     */
    var index = [...target
        .closest("tbody")
        .querySelectorAll("tr")
    ].indexOf(nodeTR);

    console.log(target, nodeTR, index);
    var [id, nome, descricao] =
        nodeTR.querySelectorAll("td");

    var form = document.querySelector("form");

    var campoNome = form
        .querySelector("input[name=nome]");
    var campoDescricao = form
        .querySelector("textarea[name=descricao]");

    var campoIndice = form
        .querySelector("input[name=index]");

    campoNome.value = nome.innerText;
    campoDescricao.value = descricao.innerText;
    campoIndice.value = index;
}
