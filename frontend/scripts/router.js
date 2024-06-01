function checkRoute() {
    var tela = "/home.html"
    switch (window.location.pathname) {
        case "/alunos":
            tela = "/lista.html";
            break;
        case "/alunos/criar":
            tela = "/cadastro.html";
            break;
        default:
            break;
    }
    fetch(tela)
    .then(
        (r) => r.text()
    )
    .then((html) => {
        var conteudo = document.getElementById("conteudo");
        conteudo.innerHTML = html;
    })
}