import React from "react";


function LoginForm(){
    return(
        <div className="d-flex justify-content-center align-items-center">
            <form className="bg-white p-5 rounded">
              <div className="mb-3">
                <label htmlFor="nombreUsuario" className="form-label">Nombre de usuario: (*)</label>
                <input type="text" className="form-control" id="nombreUsuario" aria-describedby="emailHelp" />
                <span id="errorNombreUsuario" className="text-danger fw-bold font-size-x-small d-none">Usuario incorrecto</span>
              </div>
              <div className="mb-3">
                <label htmlFor="password" className="form-label">Password: (*)</label>
                <input type="password" className="form-control" id="password" aria-describedby="passwordHelp" />
                <span id="errorPassword" className="text-danger fw-bold font-size-x-small d-none">Contraseña incorrecta</span>
              </div>
              <div className="mb-3 d-flex flex-column">
                <div className="d-flex">
                  <div className="form-check">
                    <input type="checkbox" className="form-check-input" id="terminosCondiciones" disabled />
                  </div>
                  <div>
                    <label className="form-check-label enlace" data-bs-toggle="modal" data-bs-target="#modalTerminosCondiciones">Acepto terminos & condiciones</label>
                  </div>
                </div>
                <div>
                  <span id="errorTerminosYCondiciones" className="text-danger fw-bold font-size-x-small d-none">Acepte terminos y condiciones</span>
                </div>
              </div>
              <div className="text-center">
                <button type="button" className="btn btn-primary">Iniciar Sesión</button>
              </div>
              <div className="text-center p-3">
                <span className="enlace">¿Olvidaste tu nombre de usuario?</span>
              </div>
              <div className="text-center p-3">
                <span className="enlace">¿Olvidaste tu contraseña?</span>
              </div>
              <div className="text-center p-3">
                <button type="button" className="btn btn-success" data-bs-toggle="modal" data-bs-target="#formularioRegistroUsuario">
                  Registrarse
                </button>
              </div>
            </form>
        </div>
    );
};

export default LoginForm;