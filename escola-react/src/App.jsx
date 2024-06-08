import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Layout from './layout/Layout';
import { BrowserRouter } from 'simple-react-routing';
import Home from './Home';

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

  return (
    <BrowserRouter routes={[
      {
        path: "",
        component: <Home></Home>
      }
    ]}>
      <div className={classDiv}></div>
      <Layout></Layout>
    </BrowserRouter>
  )
}

export default App
