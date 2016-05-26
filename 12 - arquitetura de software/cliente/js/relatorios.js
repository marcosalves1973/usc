function listaParcial(){
    $("#listagem").html("");
    $.ajax({
        url: url_padrao+'/relatorio/pacial',
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if(data.status==true){
                if(data.objeto.length > 0){
                    data.objeto.forEach(
                        function(row){
                            var linha = "<tr>";
                            linha += "<td width='50%'>";
                            linha += "(" + row.RESTAURANTE_ID + ") " + row.RESTAURANTE_NOME;
                            linha += "</td>";
                            linha += "<td width='50%'>";
                            linha += "(" + row.LOGIN_ID + ") " + row.USUARIO;
                            linha += "</td>";
                            linha += "</tr>";  
                            $("#listagem").append(linha);
                        }
                    )
                }else{
                    var linha = "<tr>";
                    linha += "<td colspan='4' align='center'>";
                    linha += data.mensagem;
                    linha += "</td>"; 
                    linha += "</tr>";  
                    $("#listagem").append(linha);
                }
            }else{
                alert(data.mensagem)
            }
        }
    });   
}

function listaSemanaPassada(){
    $("#listagem").html("");
    $.ajax({
        url: url_padrao+'/relatorio/semanaPassada',
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if(data.status==true){
                if(data.objeto.length > 0){
                    data.objeto.forEach(
                        function(row){
                            var date = new Date(row.DATA)
                            var month = date.getMonth() + 1

                            if(month < 10){
                                month = "0" + month
                            }


                            var linha = "<tr>";
                            linha += "<td>";
                            linha += "(" + row.RESTAURANTE_ID + ") " + row.NOME;
                            linha += "</td>";
                            linha += "<td>";
                            linha += date.getDate() + "/" + month + "/" + date.getFullYear();
                            linha += "</td>";
                            linha += "</tr>";  
                            $("#listagem").append(linha);
                        }
                    )
                }else{
                    var linha = "<tr>";
                    linha += "<td colspan='4' align='center'>";
                    linha += data.mensagem;
                    linha += "</td>"; 
                    linha += "</tr>";  
                    $("#listagem").append(linha);
                }
            }else{
                alert(data.mensagem)
            }
        }
    });   
}

function listaMaisVotado(){
    $("#listagem").html("");
    $.ajax({
        url: url_padrao+'/relatorio/maisVotado',
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if(data.status==true){
                if(data.objeto.length > 0){
                    data.objeto.forEach(
                        function(row){
                            var linha = "<tr>";
                            linha += "<td>";
                            linha += "(" + row.RESTAURANTE_ID + ") " + row.NOME;
                            linha += "</td>";
                            linha += "<td>";
                            linha += row.TOTAL;
                            linha += "</td>";
                            linha += "</tr>";  
                            $("#listagem").append(linha);
                        }
                    )
                }else{
                    var linha = "<tr>";
                    linha += "<td colspan='4' align='center'>";
                    linha += data.mensagem;
                    linha += "</td>"; 
                    linha += "</tr>";  
                    $("#listagem").append(linha);
                }
            }else{
                alert(data.mensagem)
            }
        }
    });   
}