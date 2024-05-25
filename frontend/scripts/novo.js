var numero = 1.5;
var texto = "texto da variavel";
var bool = true;
var lista = [1, 2, 3];
var obj = {
    id: 1,
    nome: "nome do objeto"
}

var x = 10;
x = "texto";
x = false;

if (numero > 1) {
    console.log("maior que 1");
}

for (var i in texto) {
    console.log(texto[i])
}

if (obj > 1) {
    console.log("TRUE")
}
else {
    console.log("FALSE")
}

function fazAlgumaCoisa() {
    alert("Você clicou no botão");
}

function enviarDados(evento) {
    console.log(evento.target);

    var dados = new FormData(evento.target);
    var texto =
        `Texto: ${dados.get("texto")}\nNúmero: ${dados.get("numero")}`; // $""

    console.log("ANTES DE CONFIRMAR")
    var resposta = confirm(texto);

    console.log("DEPOIS DE CONFIRMAR")
    if (resposta == false) {
        evento.preventDefault();
    }

}
