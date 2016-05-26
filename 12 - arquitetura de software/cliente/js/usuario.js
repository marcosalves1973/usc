function listaUsuarios(){
    $("#listagem").html("");
    $.ajax({
        url: url_padrao+'/login/listar',
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
                            linha += "<td width='90%'>";
                            linha += "("+row.ID+") "+row.NOME;
                            linha += "</td>";
                            linha += "<td align=''>";
                            linha += "<button type='button' class='btn btn-default' onclick='editarUsuario("+row.ID+")'>";
                            linha += "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>";
                            linha += "</button>";
                            linha += "</td>";
                            linha += "</tr>";  
                            $("#listagem").append(linha);
                        }
                    )
                }else{
                    var linha = "<tr>";
                    linha += "<td colspan='4' align='center'>";
                    linha += "Nenhum usuário encontrado";
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

function editarUsuario(id){     
    $.ajax({
        url: url_padrao+'/login/consultar/'+id,
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function(data) {
            if(data.status==true){
                $("#titulo_modal").html("Alterar")
                $('#modalManutencao').modal('show')
                $("#manutencao #id").val(data.objeto.ID);
                $("#manutencao #nome").val(data.objeto.NOME);
                $("#manutencao #usuario").val(data.objeto.USUARIO);
                $("#manutencao #senha").val(data.objeto.SENHA);
            }else{
                alert(data.mensagem);
                $('#modalManutencao').modal('hide')
            }
        }
    })    
}

function salvarUsuario(){
    var url = url_padrao+"/login/salvar";
    var method = "POST";

    if($("#manutencao #id").val() > 0){
        url = url_padrao+"/login/alterar";
        method = "PUT";
    }

    $.ajax({
        url: url,
        type: method,
        data: $("#manutencao").serialize(),
        dataType:"json",
        success: function(data) {
            if(data.status==true){
                alert(data.mensagem);
                $('#modalManutencao').modal('hide')
                listaUsuarios()
            }else{
                alert(data.mensagem);
            }
        }
    })
}