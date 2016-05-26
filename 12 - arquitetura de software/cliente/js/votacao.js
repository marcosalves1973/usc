function listaVotacao(){
    $("#listagem").html("");
    var usuario_id = $("#formLogin #id").val()
    $.ajax({
        url: url_padrao+'/votacao/listar/restaurantes/'+usuario_id,
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            
            if(data.status == true){
                if(typeof data.objeto == "object"){
                    if(data.objeto.length > 0){
                        data.objeto.forEach(
                        function(row){
                            var linha = "<tr>";
                            linha += "<td width='90%'>";
                            linha += "("+row.ID+") "+row.NOME;
                            linha += "</td>";
                            linha += "<td align=''>";
                            linha += "<button type='button' class='btn btn-default' onclick='votar("+row.ID+")'>";
                            linha += "<span class='glyphicon glyphicon-hand-up' aria-hidden='true'></span>";
                            linha += "</button>";
                            linha += "</td>";
                            linha += "</tr>";  
                            $("#listagem").append(linha);
                        }
                    )
                    }else{
                        var linha = "<tr>";
                        linha += "<td colspan='2' align='center'>";
                        linha += "Restaurante ganhador: ("+data.objeto.ID+") "+data.objeto.NOME;
                        linha += "</td>"; 
                        linha += "</tr>";  
                        $("#listagem").append(linha);
                    }
                }else{
                    var linha = "<tr>";
                    linha += "<td colspan='2' align='center'>";
                    linha += data.mensagem;
                    linha += "</td>"; 
                    linha += "</tr>";  
                    $("#listagem").append(linha);
                }
            }else{
                var linha = "<tr>";
                linha += "<td colspan='2' align='center'>";
                linha += data.mensagem;
                linha += "</td>"; 
                linha += "</tr>";  
                $("#listagem").append(linha);
            }
        }
    });   
}

function votar(restaurante_id){

    var parametros = {
        "login_id": $("#formLogin #id").val(),
        "restaurante_id": restaurante_id
    };

    $.ajax({
        url: url_padrao+"/votacao/votar",
        type: "POST",
        data: JSON.stringify(parametros),
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function(data) {
            alert(data.mensagem);
            listaVotacao();
        }
    })
}