
async function RegistrarUsuario(url = '/Usuarios/RegistrarUsuario', data = {}) {
    
    var primerNombre = $('#primerNombre').val();
    if (primerNombre === "") {
        $('#errorPrimerNombre').removeClass('d-none');
    } else {
        $('#errorPrimerNombre').addClass('d-none');
        var segundoNombre = $('#segundoNombre').val();
        var primerApellido = $('#primerApellido').val();
        if (primerApellido === "") {
            $('#errorPrimerApellido').removeClass('d-none');
        } else {
            $('#errorPrimerApellido').addClass('d-none');
            var segundoApellido = $('#segundoApellido').val();
            var departamentoId = $('#departamentos option:selected').val();
            if (departamentoId == 0) {
                $('#errorDepartamento').removeClass('d-none');
            } else {
                $('#errorDepartamento').addClass('d-none');
                var ciudadOMunicipioId = $('#ciudadesOMunicipios option:selected').val();
                if (ciudadOMunicipioId == 0) {
                    $('#errorDiudadOMunicipio').removeClass('d-none');
                } else {
                    $('#errorDiudadOMunicipio').addClass('d-none');
                    var email = $('#email').val();
                    if (email === "") {
                        $('#errorEmail').removeClass('d-none');
                    } else {
                        $('#errorEmail').addClass('d-none');
                        var celular = $('#celular').val();
                        if (celular === "") {
                            $('#errorCelular').removeClass('d-none');
                        } else {
                            $('#errorCelular').addClass('d-none');
                            var nombreUsuario = $('#nombreUsuarioRegistro').val();
                            if (nombreUsuario === "") {
                                $('#errorNombreUsuarioRegistro').removeClass('d-none');
                            } else {
                                $('#errorNombreUsuarioRegistro').addClass('d-none');
                                var password = $('#passwordRegistro').val();
                                if (password === "") {
                                    $('#errorPasswordRegistro').removeClass('d-none');
                                } else {
                                    $('#errorPasswordRegistro').addClass('d-none');
                                    var userData = {
                                        primerNombre: primerNombre,
                                        segundoNombre: segundoNombre,
                                        primerApellido: primerApellido,
                                        segundoApellido: segundoApellido,
                                        departamentoId: departamentoId,
                                        ciudadOMunicipioId: ciudadOMunicipioId,
                                        email: email,
                                        celular: celular,
                                        nombreUsuario: nombreUsuario,
                                        password: password
                                    };

                                    try {
                                        let response = await fetch(url, {
                                            method: 'POST',
                                            headers: {
                                                'Content-Type': 'application/json'
                                            },
                                            body: JSON.stringify(userData)
                                        });

                                        if (response.ok) {
                                            let result = await response.json();
                                            console.log('Respuesta del servidor:', result);
                                            MostrarNotificacion(1);
                                            CerraModalRegistroUsuario();
                                        } else {
                                            console.error('Error al registrar o actualizar el usuario:', response.statusText);
                                            MostrarNotificacion(2);
                                        }
                                    } catch (error) {
                                        console.error('Error en la solicitud:', error);
                                        MostrarNotificacion(2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }   
}

function IniciarSesion() {
    var nombreUsuario = $('#nombreUsuario').val();
    if (nombreUsuario === "") {
        $('#errorNombreUsuario').removeClass('d-none');
    } else {
        $('#errorNombreUsuario').addClass('d-none');
        var password = $('#password').val();
        if (password == "") {
            $('#errorPassword').removeClass('d-none');
        } else {
            $('#errorPassword').addClass('d-none');
            var aceptarTerminosYCondiciones = $('#terminosCondiciones').prop('checked');
            if (!aceptarTerminosYCondiciones) {
                $('#errorTerminosYCondiciones').removeClass('d-none');
            } else {
                $('#errorTerminosYCondiciones').addClass('d-none');
                var credenciales = {
                    NombreUsuario: nombreUsuario,
                    Password: password
                }
                fetch('/Usuarios/IniciarSesion', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(credenciales)
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Error al obtener los datos del servicio.');
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data == 1) {
                            console.log("Login exitoso");
                            window.location.href = 'https://localhost:44381/Home/SesionIniciada';
                        } else {
                            console.log("Login fallido");
                            MostrarNotificacion(data);
                        }
                    })
                    .catch(error => {
                        console.log(error);
                        MostrarNotificacion(3);
                    });
            }
        }
    }
}

function CerrarSesion() {
    window.location.href = 'https://localhost:44381/Home/Login';
}
function ObtenerDepartamentos() {
    fetch('/Geografia/ObtenerDepartamentos')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener los datos del servicio.');
            }
            return response.json();
        })
        .then(data => {
            var departamentosSelect = $('#departamentos');
            departamentosSelect.empty();
            var optionSelected = $('<option></option>')
            optionSelected.attr('value', 0);
            optionSelected.prop('selected', true);
            optionSelected.text("Selecciones un departamento");
            departamentosSelect.append(optionSelected);
            if (data && data.length > 0) {
                data.forEach(function (departamento) {
                    var option = $('<option></option>')
                    option.attr('value', departamento.id);
                    option.text(departamento.nombre);
                    departamentosSelect.append(option);
                });
            } else {
                departamentosDiv.text('No se encontraron departamentos.');
            }
        })
        .catch(error => {
            console.error('Error fetching data:', error);
            var departamentosDiv = $('#departamentos');
            departamentosDiv.text('Error al obtener los datos del servicio.');
        });
}

function ObtenerCiudadesOMunicipiosPorDepartamento(selectId) {
    var departamentoId = $('#' + selectId + ' option:selected').val();
    fetch('/Geografia/ObtenerCiudadesOMunicipiosPorDepartamento?departamentoId=' + departamentoId)
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener los datos del servicio.');
            }
            return response.json();
        })
        .then(data => {
            var ciudadesOMunicipiosSelect = $('#ciudadesOMunicipios');
            ciudadesOMunicipiosSelect.empty();
            var optionSelected = $('<option></option>')
            optionSelected.attr('value', 0);
            optionSelected.prop('selected', true);
            optionSelected.text("Selecciones una ciudad o municipio");
            ciudadesOMunicipiosSelect.append(optionSelected);
            if (data && data.length > 0) {
                data.forEach(function (ciudadOMunicipio) {
                    var option = $('<option></option>')
                    option.attr('value', ciudadOMunicipio.id);
                    option.text(ciudadOMunicipio.nombre);
                    ciudadesOMunicipiosSelect.append(option);
                });
            } else {
                departamentosDiv.text('No se encontraron departamentos.');
            }
        })
        .catch(error => {
            console.error('Error fetching data:', error);
            var departamentosDiv = $('#departamentos');
            departamentosDiv.text('Error al obtener los datos del servicio.');
        });
}

function ObtenerGeneros() {
    fetch('/Usuarios/ObtenerGeneros')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener los datos del servicio.');
            }
            return response.json();
        })
        .then(data => {
            var generosSelect = $('#generos');
            generosSelect.empty();
            var optionSelected = $('<option></option>')
            optionSelected.attr('value', 0);
            optionSelected.prop('selected', true);
            optionSelected.text("Selecciones un genero");
            generosSelect.append(optionSelected);

            data.forEach(function (genero) {
                var option = $('<option></option>')
                option.attr('value', genero.id);
                option.text(genero.nombre);
                generosSelect.append(option);
            });

        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
}

async function RegistroMedidasCorporalesPorUsuario(url = '/Usuarios/RegistroMedidasCorporalesPorUsuario', data = {}) {
    var contornoPecho = $('#contornoPecho').val();
    if (contornoPecho === "") {
        $('#errorContornoPecho').removeClass('d-none');
    } else {
        $('#errorContornoPecho').addClass('d-none');
        var contornoCintura = $('#contornoCintura').val();
        if (contornoCintura === "") {
            $('#errorContornoCintura').removeClass('d-none');
        } else {
            $('#errorContornoCintura').addClass('d-none');
            var contornoCadera = $('#contornoCadera').val();
            if (contornoCadera === "") {
                $('#errorContornoCadera').removeClass('d-none');
            } else {
                $('#errorContornoCadera').addClass('d-none');
                var longitudHombro = $('#longitudHombro').val();
                if (longitudHombro === "") {
                    $('#errorLongitudHombro').removeClass('d-none');
                } else {
                    $('#errorLongitudHombro').addClass('d-none');
                    var generoId = $('#generos option:selected').val();
                    if (generoId == 0) {
                        $('#errorGenero').removeClass('d-none');
                    } else {
                        $('#errorGenero').addClass('d-none');

                        var userData = {
                            usuarioId: 13,
                            generoId: generoId,
                            contornoPecho: contornoPecho,
                            contornoCintura: contornoCintura,
                            contornoCadera: contornoCadera,
                            longitudHombro: longitudHombro
                        };

                        try {
                            let response = await fetch(url, {
                                method: 'POST',
                                headers: {
                                    'Content-Type': 'application/json'
                                },
                                body: JSON.stringify(userData)
                            });

                            if (response.ok) {
                                let result = await response.json();
                                console.log('Respuesta del servidor:', result);
                                CerrarModalMedidasCorporales();
                                CrearVetanaDeResultado(result);
                            } else {
                                console.error('Error al registrar o actualizar el usuario:', response.statusText);
                                CerrarModalMedidasCorporales();
                            }
                        } catch (error) {
                            console.error('Error en la solicitud:', error);
                        }
                    }
                }  
            } 
        }
    } 
}

function AceptarTerminosYCondiciones() {
    $('#terminosCondiciones').prop('disabled', false);
    $('#terminosCondiciones').prop('checked', true);
}

function CerrarModalMedidasCorporales() {
    var $modalElement = document.getElementById('formularioSET');
    var modalInstance = bootstrap.Modal.getInstance($modalElement);
    modalInstance.hide();
}

function CerraModalRegistroUsuario(){
    var $modalElement = document.getElementById('formularioRegistroUsuario');
    var modalInstance = bootstrap.Modal.getInstance($modalElement);
    modalInstance.hide();
}

function MostrarNotificacion(notificacionId) {
    // 1 Registro de usuario exitoso.
    // 2 Registro de usuario fallido.
    // 3 Inicio de sesión fallido.

    var errorTitulo = $('<span></span>');
    var mensage = $('<p></p>')
    mensage.addClass('text-justify');
    if (notificacionId > 0) {
        errorTitulo.text('Exitoso');
        errorTitulo.addClass('text-success fw-bold');
        mensage.text('Registro de usuario exitoso.');
        
    } else if (notificacionId == 0 || notificacionId == -1) {
        errorTitulo.text('Error');
        errorTitulo.addClass('text-danger fw-bold');
        mensage.text('Registro de usuario fallido.');
    } else if (notificacionId == -2) {
        errorTitulo.text('Error');
        errorTitulo.addClass('text-danger fw-bold');
        mensage.text('Inicio de sesión fallido.');
    }   
   
    var contenedorHeader = $('<div></div>');
    contenedorHeader.addClass('p-2 pb-0 border-bottom-1');
    contenedorHeader.append(errorTitulo);
    
    var contenedorMensaje = $('<div></div>');
    contenedorMensaje.addClass('p-2');
    contenedorMensaje.append(mensage);

    var contenedor = $('<div></div>');
    contenedor.addClass('contenedor-notificaciones bg-white rounded');
    contenedor.append(contenedorHeader);
    contenedor.append(contenedorMensaje);
    $('body').append(contenedor);

    setTimeout(() => {
        contenedor.addClass('active');
    }, 100);

    setTimeout(() => {
        contenedor.remove();
    }, 5000);
}

function CrearVetanaDeResultado(result) {

    var labelContornoPecho = $('<span></span>');
    labelContornoPecho.text('Contorno del pecho: ');
    labelContornoPecho.addClass('fw-bold');

    var contornoPecho = $('<span></span>');
    contornoPecho.text(result.contornoPecho);

    var contenedorDatoContornoPecho = $('<div></div>');
    contenedorDatoContornoPecho.append(labelContornoPecho);
    contenedorDatoContornoPecho.append(contornoPecho);

    var labelContornoCintura = $('<span></span>');
    labelContornoCintura.text('Contorno de la cintura: ');
    labelContornoCintura.addClass('fw-bold');

    var contornoCintura = $('<span></span>');
    contornoCintura.text(result.contornoCintura);

    var contenedorDatoContornoCintura = $('<div></div>');
    contenedorDatoContornoCintura.append(labelContornoCintura);
    contenedorDatoContornoCintura.append(contornoCintura);

    var labelContornoCadera = $('<span></span>');
    labelContornoCadera.text('Contorno de la cadera: ');
    labelContornoCadera.addClass('fw-bold');

    var contornoCadera = $('<span></span>');
    contornoCadera.text(result.contornoCadera);

    var contenedorDatoContornoCadera = $('<div></div>');
    contenedorDatoContornoCadera.append(labelContornoCadera);
    contenedorDatoContornoCadera.append(contornoCadera);

    var labelLongitudHombro = $('<span></span>');
    labelLongitudHombro.text('Longitud del hombro: ');
    labelLongitudHombro.addClass('fw-bold');

    var longitudHombro = $('<span></span>');
    longitudHombro.text(result.longitudHombro);

    var contenedorDatoLongitudHombro = $('<div></div>');
    contenedorDatoLongitudHombro.append(labelLongitudHombro);
    contenedorDatoLongitudHombro.append(longitudHombro);

    var contenedorMedidasIngresadas = $('<div></div>');
    contenedorMedidasIngresadas.addClass('d-flex flex-column col-6');
    contenedorMedidasIngresadas.append(contenedorDatoContornoPecho);
    contenedorMedidasIngresadas.append(contenedorDatoContornoCintura);
    contenedorMedidasIngresadas.append(contenedorDatoContornoCadera);
    contenedorMedidasIngresadas.append(contenedorDatoLongitudHombro);
    
    var tallaSETDimag = $('<span></span>');
    tallaSETDimag.text(result.tallaSETDimag);

    var contenedorTallaEstablecida = $('<div></div>');
    contenedorTallaEstablecida.addClass('d-flex justify-content-center align-items-center p-0 col-6');
    contenedorTallaEstablecida.append(tallaSETDimag);

    var ventanaResultado = $('<div></div>');
    ventanaResultado.addClass('d-flex p-2 rounded bg-white ventana-resultado row');
    ventanaResultado.append(contenedorMedidasIngresadas);
    ventanaResultado.append(contenedorTallaEstablecida);

    $('body').append(ventanaResultado);
}

$(document).ready(function () {
    ObtenerDepartamentos();
    ObtenerGeneros();
    $('#registrarUsuario').click(async function () {
        try {
            const data = await RegistrarUsuario();
            // Usar los datos retornados
            $('#result').text('Success: ' + JSON.stringify(data));
        } catch (error) {
            $('#result').text('Error: ' + error.message);
            console.log(error);
        }
    });
});
