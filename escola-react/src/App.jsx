import React, { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Layout from './layout/Layout';
import { BrowserRouter } from 'simple-react-routing';
import Home from './Home';
import ListaAlunos from './alunos/ListaAlunos';
import FormAluno from './alunos/FormAlunos';

function App() {
  var numero = 0;
  var setNumero = (novoNumero) => {
    numero = novoNumero;
  }

  var [x, y] = [0, "teste"];
  var array = [0, "teste"];
  x = array[0]
  y = array[1]

  const stateCount = useState(0); // state - hook -> retorna [valor, setValor]

  const count = stateCount[0];
  const setCount = stateCount[1];

  console.log("RENDERIZANDO APP:::", count);
  var classDiv = "classe-div";

  useEffect(function () {
    console.log("1) ACIONANDO EFEITO DO COMPONENTE")
  }, []);

  useEffect(() => {
    console.log("2) ACIONANDO EFEITO DO COMPONENTE")
  }, [count]);

  return (
    <BrowserRouter routes={[
      {
        path: "",
        component: <Home></Home>
      },
      {
        path: "alunos",
        component: <ListaAlunos a={0} texto="TEXT" seila={true}></ListaAlunos>
      },
      {
        path: "alunos/criar",
        component: <FormAluno></FormAluno>
      },
      {
        path: "alunos/editar/:codigo",
        component: <FormAluno></FormAluno>
      }
    ]}>
      <button onClick={() => setCount(Math.min(5, count + 1))}>
        count is {count}
      </button>
      <Layout></Layout>
    </BrowserRouter>
  )
}

export default App
