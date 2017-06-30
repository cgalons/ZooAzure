$(document).ready(function () {
	// defino la funcion que consultara los datos del api
	function cargarDetalle() {
		var id = window.location.search.substring(1).split('=')[1];
		//var id = 0; //de momento le ponemos un 0 es temporal



		// PREPARAR LA LLAMADA AJAX
		$.get(`/api/TiposCombustible/${id}`, function (respuesta, estado) {
			// $('#resultado').html('');
			// COMPRUEBO EL ESTADO DE LA LLAMADA
			if (estado === 'success') {
				// SI LLEGO HASTA AQUÍ QUIERE DECIR
				// QUE EN 'RESPUESTA' TENGO LA INFO
			}
			var contenido = '';
			$('#denominacion').val(respuesta.dataTipoCombustible[0].denominacion);

			$('#resultados').html(contenido);
		});
	}


	//Función para volver al listado
	$('#btnCancelar').click(function () {
		window.location.href = '/tiposCombustible.html';
	});


	// FUNCIÓN PARA ACTUALIZAR LOS DATOS
	$('#btnActualizar').click(function () {

		var id = window.location.search.substring(1).split('=')[1];

		// PREPARAR LA LLAMADA AJAX 
		$.ajax({
			url: `/api/TiposCombustible/${id}`,
			type: "PUT",
			dataType: 'json',
			data: {
				denominacion: $('#denominacion').val()
			},
			success: function (respuesta) {
				// SI LLEGO HASTA AQUÍ QUIERE DECIR
				// ME REDIRECCIONO A LA LISTA DE MARCAS
				window.location.href = './tiposCombustible.html';
			},
			error: function (respuesta) {
				console.log(respuesta);
			}
		});
	});

	//});


	//ejecuto la funcion que consultará los datos del api
	cargarDetalle();

});