import './App.css';
import BotonesFlotantesLogin from './Componentes/BotonesFlotantesLogin';
import Footer from './Componentes/Footer';
import LoginForm from './Componentes/LoginForm';
import TituloPagina from './Componentes/TituloPagina';

function App() {
  return (
    <>
      <TituloPagina/>
      <div className='row'>
        <div className='col-1'></div>
        <div className='col-10'>
          <BotonesFlotantesLogin/>
          <div className='row'>
              <div className='col-1'></div>
              <div className='col-5'>
                <img src="/Imagenes/Modelos.png" alt="Modelos"/>
              </div>
              <div className='col-5'>
                <LoginForm/>
              </div>
              <div className='col-1'></div>
          </div>
        </div>
        <div className='col-1'></div>
        <div>
          <Footer/>
        </div>
      </div> 
    </>
  );
}

export default App;
