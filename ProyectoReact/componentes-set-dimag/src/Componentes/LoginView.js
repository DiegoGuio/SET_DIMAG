import React from "react";
import BotonesFlotantesLogin from './BotonesFlotantesLogin';
import Footer from './Footer';
import LoginForm from './LoginForm';
import TituloPagina from './TituloPagina';

const LoginView = () => {
    return(
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
};

export default LoginView;
