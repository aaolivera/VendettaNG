function attachDataPickers() {
    $('input.date').each(function () {
        var $this = $(this);
        $this.datepicker();
    });
}
var deleteLinkObj;
var confirmarLinkObj;
$(document).ready(function () {
    if (!$("#alerta").hasClass("hide")) {
        if ($("#alerta").hasClass("alert-success"))
            $("#alerta").delay(500).addClass("in").fadeOut(2500);
        else
            $("#alerta").delay(500).addClass("in");
    }
    attachDataPickers();
    $(document).on('click', '#grid thead th a, #grid tfoot td a', function (evt) {
        var container = $(this).parents('#gridContainer');
        if (container.attr('data-grid-url')) {
            container.data().gridUrl = this.href;
        }
        $.get(this.href, function (data) {
            container.html(data);
        });
        return false;
    });

    /* delete Link */
    $(document).on('click', '.ajax-borrar-link', function () {
        deleteLinkObj = $(this); /*for future use*/
        $('#dialogo-borrar').modal({
            //keyboard: false
        });
        return false; /* prevents the default behaviour */
    });
    
    $('#dialogo-borrar').on('shown', function () {
        $('#dialogo-borrar-cancelar').focus();
    });
    
    $('#dialogo-borrar-cancelar').click(function () {
        $('#dialogo-borrar').modal('hide');
    });

    $('#dialogo-borrar-confirmar').click(function () {
        $.post(deleteLinkObj[0].href, function (data) { /*Post to action*/
            if (data == 'true') {
                deleteLinkObj.closest("tr").hide(); /*Hide Row*/
                MostrarAlertaExitosa();
            } else {
                MostrarAlertaError(data);
            }
        })
            .error(
                function (message) {
                    alert(message.responseText);
                });
        $('#dialogo-borrar').modal('hide');
    });

    $('#dialogo-editar-cancelar').click(function () {
        $('#dialogo-editar').modal('hide');
    });

    $('#dialogo-editar-guardar').click(function () {
        $('#dialogo-editar form').submit();
        if ($('#dialogo-editar form').valid())
            $("#dialogo-editar-guardar").attr("disabled", true);
    });

    $(document).on('click', '.ajax-editar-link', function () {
        $.get(this.href, cargarDialogoEditar);
        return false;
    });
    
    $('#dialogo-ver-ok').click(function () {
        $('#dialogo-ver').modal('hide');
    });

    $(document).on('click', '.ajax-ver-link', function () {
        $.get(this.href, cargarDialogoVer);
        return false;
    });

    /* Generic Ajax error handling */
    $("#error-box").ajaxError(function (event, jqXhr, ajaxSettings, thrownError) {
        var $this = $(this);
        var errorText = $this.data().genericError + jqXhr.responseText;
        $this.html(errorText);
        $('#error-box-container').slideDown('slow');
    });
    
    $('#dialogo-editar').on('show', function () {
        $(this).find('.modal-body').css({
            height: 'auto', 'max-height': '400px', 'padding-right': '50px'
        });
    });
       
    $('#dialogo-editar').on('shown', function () {
        $(this).find('.modal-body').find(':input:enabled:visible:first').focus();
    });
    
});

function cargarDialogoEditar(data) {
    $('#dialogo-editar-body').html(data);
    $("#dialogo-editar-guardar").attr("disabled", false);
    $('#dialogo-editar-title').html($('#dialogo-editar-body form').data().dialogoTitulo);
    $('#dialogo-editar-body form').attr('data-ajax-success', 'editarRepuestaFormulario');
    if ($('#dialogo-editar-body form').data().dialogoExtraclass) {
        $('#dialogo-editar').addClass($('#dialogo-editar-body form').data().dialogoExtraclass);
    }

    $('#dialogo-editar').modal({
        backdrop: 'static', keyboard: false
    }).css({

        'top': '50%',
        'margin-top': function () {
            return -($(this).height() / 2);
        }

    });
    attachDataPickers();
}

function cargarDialogoVer(data) {
    $('#dialogo-ver-body').html(data);
    $('#dialogo-ver-body form').attr('data-ajax-success', 'editarRepuestaFormulario');
    $('#dialogo-ver').modal({
        backdrop: 'static', keyboard: false
    }).css({
        'top': '40%',
        'margin-top': function () {
            return -($(this).height() / 2);
        }

    });
}

function editarRepuestaFormulario(respuesta) {
    if (respuesta == window.ajaxEditSuccess) {
        window.location.href = window.location.href;
    } else {
        cargarDialogoEditar(respuesta);
    }
}

function editarRepuestaFormulario(respuesta) {
    if (respuesta == window.ajaxEditSuccess) {
        if ($('#search-form').length == 0) {
            window.location.href = window.location.href;
        } else {
            $('#dialogo-editar').modal('hide');
            $('#search-form').submit();
            MostrarAlertaExitosa();
        }
    } else {
        cargarDialogoEditar(respuesta);
    }
}

function MostrarAlertaError(data) {
   
    if (data != null) {
        $("#alertaError span").text(data);
    } else {
        $("#alertaError span").text($("#alertaError").data().mensaje);
    }
    $("#alertaError").show();
    $("#alertaError").delay(500).addClass("in");
}

function MostrarAlertaAdvertencia(data) {
    if (data != null) {
        $("#alertaAdvertencia span").text(data);
    } else {
        $("#alertaAdvertencia span").text($("#alertaAdvertencia").data().mensaje);
    }
    $("#alertaAdvertencia").show();
    $("#alertaAdvertencia").delay(500).addClass("in");
}

function MostrarAlertaExitosa() {
    $("#alertaExitosa").show();
    $("#alertaExitosa").delay(500).addClass("in").fadeOut(2500);
}

function MostrarAlertaCancelada() {
    $("#alertaCancelada").show();
    $("#alertaCancelada").delay(500).addClass("in").fadeOut(2000);
}

$(document).ready(function () {
    /*Centrar la primera vez*/
    CentrarPosicionElemento();
    /*Centrar por redimensión de pantalla*/
    $(window).resize(function (e) { e.preventDefault(); CentrarPosicionElemento(); });
});

function CentrarPosicionElemento() {
    $('.centro-pantalla').css({
        position: 'fixed',
        left: ($(window).width() - $('.centro-pantalla').outerWidth()) / 2,
        top: ($(window).height() - $('.centro-pantalla').outerHeight()) / 3
    });
}


