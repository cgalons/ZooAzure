type = ['', 'info', 'success', 'warning', 'error'];

mensajes = {
    showSwal: function (type, title,text) {
        if (type == 'aviso') {
            swal({
                title: title,
                text: text,
                type: 'warning',
            });
            return
        }

        if (type == 'error') {
            swal({
                title: title,
                text: text,
                type: 'error'
            });
            return

            if (type == 'exito') {
                swal({
                    title: title,
                    text: text,
                    type: 'success'
                });
                return

            }

        }
    },

    checkLogin: function (email, password, cb)

    {
        
        $.ajax({
            url: '/api/login',
            type: "POST",
            dataType: 'json',
            data: {
                email: email,
                password: password
            },
            success: function (respuesta) {
                // TODO OK
                if (respuesta !== null && respuesta.error !== '') {
                    //mensajes.showSwal('error', 'Atención', respuesta.error);
                    return cb(null, respuesta.error); // Error del API
                }

                if (respuesta !== null && respuesta.error === '' && respuesta.totalElementos == 0) {//Sin error pero vacío
                    //mensajes.showSwal('error', 'Atención', 'Usuario inexistente o no encontrado');
                    return cb(null, 'Usuario inexistente o no encontrado'); //Error mío
                }

                if (respuesta !== null && respuesta.error === '') {
                    //mensajes.showSwal('aviso', 'éxito', 'Usuario encontrado');
                    //hacer la redirección al dashboard
                    //window.location.href = '/dashboard.html';
                    return cb(respuesta); // Otro valor para el error
                }
            },
            error: function (respuesta) {
                // HAY ERROR
                mensajes.showSwal('error', 'Error en la llamada', '' + respuesta.status);
            }
        });
    },

    cargarDatosUsuario: function(){
        var datosUsuario = {}; // JSON VACIO
        var obj = localStorage.getItem('usuarioLogueado')
        if (obj !== null && obj !== undefined){
            datosUsuario = JSON.parse(obj)
    }
    return datosUsuario;
    }
}