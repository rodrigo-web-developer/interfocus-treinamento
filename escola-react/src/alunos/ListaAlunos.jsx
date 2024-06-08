export default function ListaAlunos() {
    return (<>
        <h1>Lista de alunos</h1>
        <div className="grid" id="grid-alunos">

        </div>
    </>)
}

function AlunoItem() {
    return (<div class="card">
        <ul>
            <li>Código: ${aluno.codigo}</li>
            <li>Nome: ${aluno.nome}</li>
            <li>Data de Nascimento: ${dia}/${mes}/${ano}</li>
            <li>E-mail: ${aluno.email}</li>
        </ul>
        <div class="acoes">
            <button type="button">Editar</button>
            <button type="button">Excluir</button>
        </div>
    </div>)
}