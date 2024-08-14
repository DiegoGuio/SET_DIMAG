import React from "react";
import TituloPagina from './TituloPagina';
import BotonesFlotantesHome from "./BotonesFlotantesHome";
import SetDimagForm from "./SET_DIMAG_Form";
import Footer from "./Footer";

const HomePage = () => {
    return(
        <>
            <TituloPagina/>
            <div className='row'>
                <div className='col-1'></div>
                <div className='col-10'>
                    <BotonesFlotantesHome/>
                    <div className='row'>
                    <SetDimagForm/>     
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

export default HomePage;