$(document).ready(function (){


    // Función para guardar en el local storage
    function guardarDatosUsuarios(datosUsuarioLogueado){
        debugger;
        if(!window.localStorage){
            mensajes.showSwal('aviso', 'Local Storage', 'No disponible');
            return;
        }

      

        var objetoSerializado = JSON.stringify (datosUsuarioLogueado);
        //var objetoDeserializado =JSON.parse('.....');
        localStorage.setItem('usuarioLogueado', objetoSerializado);
    
    }
  
    $('#btnLogin').click(function () {

        // validar los datos
        var email = $('#email').val();
        if (email.length == 0) {
            //alert('Por favor, indique un valor para el email');
            mensajes.showSwal('aviso', 'Datos incompletos', 'Falta el email');
            return;
        }

        var password = $('#password').val();
        if (password.length == 0) {
            mensajes.showSwal('aviso', 'Datos incompletos', 'Falta la clave');
            return;
        }
        // hacer la llamada vía ajax
        mensajes.checkLogin(email, password, function (resultado, error) {
            
            if (!resultado || resultado === undefined) {
                // mensaje de que no se pudo hacer login
                mensajes.showSwal('error',
                                  'Login error',
                                  'No se pudo hacer login');
                return;
            }
            debugger;
            // GUARDO LOS DATOS OBTENIDOS DEL API EN EL LOCALSTORAGE
            guardarDatosUsuarios(resultado);
            window.location.href = '/dashboard.html';
            
        });
    });

});

