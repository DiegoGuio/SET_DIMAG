import React from "react";

const SetDimagForm = () => {
  return (
    <div
      className="modal fade"
      id="formularioSET"
      data-bs-backdrop="static"
      data-bs-keyboard="false"
      tabIndex="-1"
      aria-labelledby="staticBackdropLabel"
      aria-hidden="true"
    >
      <div className="modal-dialog modal-dialog-centered">
        <div className="modal-content">
          <div className="modal-header border-bottom-0">
            <h5 className="modal-title" id="staticBackdropLabel">
              Ingresa tus medidas corporales
            </h5>
            <button
              type="button"
              className="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div className="modal-body" style={{ fontSize: "15px" }}>
            <div className="row">
              <div className="col-6">
                <label
                  htmlFor="contornoPecho"
                  className="form-label mb-0"
                >
                  Contorno del pecho: (*)
                </label>
                <input
                  type="number"
                  className="form-control"
                  id="contornoPecho"
                  aria-describedby="contornoPechoHelp"
                  placeholder="Dato en cm"
                />
                <span
                  id="errorContornoPecho"
                  className="text-danger fw-bold font-size-x-small d-none"
                >
                  Ingrese medida corporal
                </span>
              </div>
              <div className="col-6">
                <label
                  htmlFor="contornoCintura"
                  className="form-label mb-0"
                >
                  Contorno de la cintura: (*)
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="contornoCintura"
                  aria-describedby="contornoCinturaHelp"
                  placeholder="Dato en cm"
                />
                <span
                  id="errorContornoCintura"
                  className="text-danger fw-bold font-size-x-small d-none"
                >
                  Ingrese medida corporal
                </span>
              </div>
              <div className="col-6">
                <label
                  htmlFor="contornoCadera"
                  className="form-label mb-0"
                >
                  Contorno de la cadera: (*)
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="contornoCadera"
                  aria-describedby="contornoCaderaHelp"
                  placeholder="Dato en cm"
                />
                <span
                  id="errorContornoCadera"
                  className="text-danger fw-bold font-size-x-small d-none"
                >
                  Ingrese medida corporal
                </span>
              </div>
              <div className="col-6">
                <label
                  htmlFor="longitudHombro"
                  className="form-label mb-0"
                >
                  Longitud Hombro a Hombro: (*)
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="longitudHombro"
                  aria-describedby="longitudHombroHelp"
                  placeholder="Dato en cm"
                />
                <span
                  id="errorLongitudHombro"
                  className="text-danger fw-bold font-size-x-small d-none"
                >
                  Ingrese medida corporal
                </span>
              </div>
              <div className="col-6">
                <label
                  htmlFor="generos"
                  className="form-label mb-0"
                >
                  Seleccione su género: (*)
                </label>
                <select
                  className="form-select"
                  id="generos"
                  aria-label="Listado de géneros"
                ></select>
                <span
                  id="errorGenero"
                  className="text-danger fw-bold font-size-x-small d-none"
                >
                  Seleccione un género
                </span>
              </div>
            </div>
          </div>
          <div className="modal-footer justify-content-center border-top-0">
            <button
              type="button"
              className="btn btn-primary"
              data-bs-dismiss="modal"
            >
              Cancelar
            </button>
            <button
              id="registrarMedidasCorporales"
              type="button"
              className="btn btn-success"
            >
              Enviar
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SetDimagForm;