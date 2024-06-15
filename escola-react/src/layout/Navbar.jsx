import { Link } from "simple-react-routing";

function Navbar() {
    return (<nav>
        <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/alunos">Alunos</Link></li>
            <li><Link to="/alunos/criar">Novo aluno</Link></li>
        </ul>
    </nav>)
};

export default Navbar;