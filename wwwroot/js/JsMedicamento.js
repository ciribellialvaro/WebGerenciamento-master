var listReacoesMedicamento = [];

function CheckSelecionado(valor) {

    var valorString =  valor.toString();

    const index = listReacoesMedicamento.indexOf(valorString);

    if (index > -1) {
        listReacoesMedicamento.splice(index, 1);
    }
    else {
        listReacoesMedicamento.push(valorString);
    }

    $("#ReacoesMedicamento").val(listReacoesMedicamento.join(";"));

}


$(function () {
    
    if ($("#ReacoesMedicamento").val() != "") {
        listReacoesMedicamento = $("#ReacoesMedicamento").val().split(";");
    }
});