async function RegistrarOActualizarUsuario(url = '/Usuarios/RegistrarOActualizarUsuario', data = {}) {

    data = {
        "Id": 1,
        "PrimerNombre": "Juan",
        "SegundoNombre": "Carlos",
        "PrimerApellido": "Pérez",
        "SegundoApellido": "Gómez",
        "TipoDocumentoId": 2,
        "NumeroDocumento": "123456789",
        "PaisId": 33,
        "DepartamentoId": 12,
        "Email": "juan.perez@example.com",
        "Celular": "3001234567",
        "NombreUsuario": "juanperez",
        "Password": "supersecretpassword"
    }
    // Opciones de la petición
    const response = await fetch(url, {
        method: 'POST', // Método HTTP
        headers: {
            'Content-Type': 'application/json' // Tipo de contenido
        },
        body: JSON.stringify(data) // Datos en el cuerpo de la petición
    });

    // Manejo de la respuesta
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }

    return response.json(); // Parseo del JSON en la respuesta
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
            console.log(data);
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

$(document).ready(function () {
    ObtenerDepartamentos();
    $('#registrarUsuario').click(async function () {
        try {
            const data = await RegistrarOActualizarUsuario();
            // Usar los datos retornados
            $('#result').text('Success: ' + JSON.stringify(data));
        } catch (error) {
            $('#result').text('Error: ' + error.message);
        }
    });
});
