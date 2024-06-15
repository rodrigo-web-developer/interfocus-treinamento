import { useEffect, useState } from "react";
import { getById, listarCursos } from "../services/cursoApi";
import FormCurso from "./FormCurso";

const NIVEIS = [
    "Iniciante",
    "Intermediário",
    "Avançado",
    "Expert"
]

export default function CursosList() {

    var [cursos, setCursos] = useState([]);

    var [curso, setCurso] = useState();

    const [busca, setBusca] = useState("");

    useEffect(() => {
        listarCursos(busca)
            .then(resposta => {
                if (resposta.status == 200) {
                    resposta.json()
                        .then(cursos => {
                            setCursos(cursos);
                        })
                }
            });
    }, [busca]);

    const getCurso = async (id) => {
        var result = await getById(id);
        if (result.status == 200) {
            var dados = await result.json();
            setCurso(dados);
        }
    }

    return (<>
        <h1>Cursos</h1>
        <div className="row">
            <input type="search" value={busca}
                onChange={(e) => setBusca(e.target.value)} />
            <button type="button" onClick={() => setCurso({})}>Novo Curso</button>
        </div>

        <table id="table-cursos">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Duração</th>
                    <th>Nível</th>
                    <th>Descrição</th>
                </tr>
            </thead>
            <tbody>
                {cursos.map(curso =>
                    <tr onClick={() => getCurso(curso.id)} key={curso.id}>
                        <td>{curso.id}</td>
                        <td>{curso.nome}</td>
                        <td>{curso.duracao} horas</td>
                        <td>{NIVEIS[curso.nivel]}</td>
                        <td>{curso.descricao}</td>
                    </tr>
                )}
            </tbody>
        </table>
        {curso && <FormCurso
            curso={curso}
            onClose={() => setCurso(undefined)}
        ></FormCurso>}
    </>)
}