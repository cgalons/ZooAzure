$(document).ready(function(){



    mensajes.cargarDatosUsuario(function (datosUsuario, error) {
        if (datosUsuario === null) {
            // REDIRECCIONO
            window.location.href = '/login.html';
        }
    });

});

//    var datosUsuario = mensajes.cargarDatosUsuario();
//    if (datosUsuario === null) {
//        windows.location.href = '/login.html';
//    }
    

//});


//mensajes.checkLogin('test@text.com', '123456', function () {
//    //mensajes.checkLogin(email,password, function(resultado, error){
//    debugger;
//    console.log('estoy en el callback');
//    //windows.location.href = '/login.html';

//});