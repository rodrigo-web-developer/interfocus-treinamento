import { useNavigation, useRouter } from "simple-react-routing"
import { postAluno, getByCodigo } from "../services/alunoApi";
import { useEffect, useReducer, useState } from "react";

export default function FormAluno() {
    const { pathParams } = useRouter();

    const codigo = pathParams["codigo"];

    const { navigateTo } = useNavigation();

    const [errorMessage, setErrorMessage] = useState("");

    const [email, setEmail] = useReducer((old, value) => {
        return value.toLowerCase().replaceAll(" ", "");
    }, "");
    // import re -> regular expression
    // using System.Text.RegularExpressions -> Regex
    const [cpf, setCpf] = useReducer((old, value) => {
        var regex = /[0-9]+/g;
        var digitos = value.replace(/[^0-9]+/g, "").substring(0, 11);

        if (digitos.length <= 3) return digitos;
        else if (digitos.length <= 6) {
            return digitos.replace(/(\d{3})(\d+)/, "$1.$2");
        }
        else if (digitos.length <= 9) {
            return digitos.replace(/(\d{3})(\d{3})(\d+)/, "$1.$2.$3");
        }
        else {
            return digitos.replace(/(\d{3})(\d{3})(\d{3})(\d+)/, "$1.$2.$3-$4");
        }

    }, "");

    const salvarAluno = async (evento) => {
        evento.preventDefault();
        var dados = new FormData(evento.target);
        var aluno = {
            codigo: codigo,
            nome: dados.get("nome"),
            email: dados.get("email"),
            dataNascimento: dados.get("dataNascimento"),
        };
        var result = await postAluno(aluno);
        if (result.status == 200) {
            navigateTo(null, "/alunos")
        }
        else {
            var erro = await result.json();
            setErrorMessage("Erro ao criar aluno: \n" + JSON.stringify(erro, null, '\t'))
        }
    }

    const [aluno, setAluno] = useState();

    useEffect(() => {
        if (codigo) {
            getByCodigo(codigo)
                .then(e => e.json())
                .then(result => setAluno(result));
        }
        else {
            setAluno({ inscricoes: [] })
        }
    }, []);

    return aluno && (<>
        <h1>{codigo ? "Editar" : "Cadastrar"} aluno</h1>
        <form onSubmit={salvarAluno}>
            <div className="formulario">
                <div className="row">
                    <div className="input">
                        <label>Nome:</label>
                        <input defaultValue={aluno.nome} placeholder="Nome do curso" type="text" name="nome" />
                        <span className="error"></span>
                    </div>
                </div>
                <div className="row">
                    <div className="input">
                        <label>Data nascimento:</label>
                        <input defaultValue={aluno.dataNascimento?.substring(0, 10)} type="date" name="dataNascimento" />
                        <span className="error"></span>
                    </div>
                </div>
                <div className="row">
                    <div className="input">
                        <label>Email:</label>
                        <input value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="E-mail do aluno" type="email" name="email" />
                        <span className="error"></span>
                    </div>
                </div>
                <div className="row">
                    <div className="input">
                        <label>CPF:</label>
                        <input value={cpf}
                            onChange={(e) => setCpf(e.target.value)}
                            placeholder="CPF do aluno" type="text" name="cpf" />
                        <span className="error"></span>
                    </div>
                </div>
            </div>
            <button type="submit">Salvar</button>
            <p className="error">{errorMessage}</p>
        </form>
    </>
    )
}