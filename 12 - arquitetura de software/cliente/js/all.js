var url_padrao = "http://localhost:61748/api";

function carrega(page, funcao, parametro_pos){
    $.ajax({
        url: page+'.html',
        cache: false,
        success: function (data) {
            $("#menu").show();
            $("#pageLogin").hide();
            $("#pageMain").html(data);

            if(typeof funcao != undefined){
                if(typeof parametro_pos != undefined){
                    funcao(parametro_pos)
                }else{
                    funcao()
                }
            }

        }
    });   
}

function fazer_login() {
    var login = {
        "usuario" : $("#formLogin #usuario").val(),
        "senha" : $("#formLogin #senha").val()
    }

    $.ajax({
        url: url_padrao+'/login/logar',
        type: 'POST',
        data: JSON.stringify(login),
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if(data.status==true){
                $("#id").val(data.objeto.ID)
                carrega('forms/home');
            }else{
                alert(data.mensagem)
            }
        }
    });   
}
