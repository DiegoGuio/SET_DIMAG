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
                                var password = $('#password').val();
                                if (password === "") {
                                    $('#errorPassword').removeClass('d-none');
                                } else {
                                    $('#errorPassword').addClass('d-none');
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
                                        } else {
                                            console.error('Error al registrar o actualizar el usuario:', response.statusText);
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
        }
    }   
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

$(document).ready(function () {
    ObtenerDepartamentos();
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
