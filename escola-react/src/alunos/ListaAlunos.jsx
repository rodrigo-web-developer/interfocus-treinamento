import { useEffect, useState } from "react";
import { listarAlunos, uploadImagem } from "../services/alunoApi";
import { Link } from "simple-react-routing";

export default function ListaAlunos(properties) {
    const [lista, setLista] = useState([]);
    const [busca, setBusca] = useState("");
    const [page, setPage] = useState(1);

    useEffect(() => {
        listarAlunos(busca, page, 8)
            .then(resposta => {
                if (resposta.status == 200) {
                    resposta.json()
                        .then(alunos => {
                            setLista(alunos);
                        })
                }
            });
    }, [busca, page]);

    return (<>
        <h1>Lista de alunos</h1>
        <div className="row">
            <input
                type="search"
                style={{ minWidth: 250 }}
                value={busca}
                onChange={(event) => {
                    setBusca(event.target.value);
                }}
            />
            <Link to="/alunos/criar">Novo Aluno</Link>
        </div>

        <div className="grid" id="grid-alunos">
            {lista.map(
                aluno => {
                    return <AlunoItem key={aluno.codigo}
                        aluno={aluno}></AlunoItem>
                }
            )}
        </div>
        <div className="row">
            <button type="button" onClick={() => setPage(page - 1)}>Anterior</button>
            <span>{page}</span>
            <button type="button" onClick={() => setPage(page + 1)}>Próximo</button>
        </div>
    </>)
}

function AlunoItem(p) {
    const aluno = p.aluno;
    var data = new Date(aluno.dataNascimento);
    var dia = data.getDate().toString().padStart(2, '0');
    var mes = (data.getMonth() + 1).toString().padStart(2, '0');
    var ano = data.getFullYear();
    var [_, n, sn] = p.aluno.nome.match(/^\s*(\w).*\s(\w)/) || ["", p.aluno.nome[0], p.aluno.nome[1]];
    var iniciais = [n, sn].join("").toUpperCase();
    const sendImagem = async (e) => {
        e.preventDefault();
        var res = await uploadImagem(e.target, p.aluno.codigo);
        if (res.status == 200) {
            var data = await res.json();
            p.aluno.photoUrl = data.photoUrl;
        }
        setImagem(false);
    }

    const [imagem, setImagem] = useState(false);

    return (<div className="card">
        <div className="column">
            <img src={p.aluno.photoUrl || "https://place-hold.it/80x80/909090&text=" + iniciais} width="80" height="80"></img>
            {imagem && <form onSubmit={sendImagem}>
                <input name="imagem" type="file" accept="image/*"></input>
                <button type="submit">Salvar</button>
            </form>}
            <button type="button" onClick={() => setImagem(true)}>Editar</button>
        </div>
        <ul>
            <li>Código: {aluno.codigo}</li>
            <li>Nome: {aluno.nome}</li>
            <li>Data de Nascimento: {dia}/{mes}/{ano}</li>
            <li>E-mail: {aluno.email}</li>
        </ul>
        <div className="acoes">
            <Link to={"/alunos/editar/" + aluno.codigo}>Editar</Link>
            <button type="button">Excluir</button>
        </div>
    </div>)
}