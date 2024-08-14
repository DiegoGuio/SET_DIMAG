import React from "react";

function Footer(){
    return(
        <footer id="footer" class="border-top footer text-muted bg-blue p-2">
            <div class="d-flex justify-content-between p-4">
                <div class="d-flex flex-column">
                    <span class="text-white">Bogotá D.C. - Colombia</span>
                    <span class="text-white">Calle 3 # 30 - 47, Local 102</span>
                    <span class="text-white">Celular: 300-6403088</span>
                </div>
                <div class="d-flex flex-column justify-content-center align-items-center">
                    <span class="text-white">La calidad es nuestra mejor herramienta</span>
                    <span class="text-white">¡Permitanos servirles!</span>
                </div>
                <div class="d-flex">
                    <div class="d-flex justify-content-center align-items-center">
                        <img src="/Imagenes/Icon-instagram-white.svg" alt="Instagram" />
                    </div>
                    <div class="d-flex justify-content-center align-items-center">
                        <img src="/Imagenes/Icon-facebook-white.svg" alt="Facebook" />
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;