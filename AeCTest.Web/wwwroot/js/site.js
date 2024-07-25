function BuscaCEP() {
    var cep = $("#cep").val();
    cep = cep.replace(/[^0-9]/g, '');

    if (cep.length === 8) {
        var url = "https://viacep.com.br/ws/" + cep + "/json/";
        $.get(url, null, function (data) {
            if (!("erro" in data)) {
                $("#logradouro").val(data.logradouro);
                $('#bairro').val(data.bairro);
                $('#cidade').val(data.localidade);
                $('#estado').val(data.uf);
            } else {
                alert("CEP não encontrado.");
                LimparCamposEndereco();
            }
        }).fail(function () {
            alert("Erro ao buscar o CEP. Por favor, tente novamente.");
            LimparCamposEndereco();
        });
    } else {
        alert("CEP inválido. Por favor, verifique.");
        LimparCamposEndereco();
    }
}

function LimparCamposEndereco() {
    $("#logradouro").val('');
    $('#bairro').val('');
    $('#cidade').val('');
    $('#uf').val('');
}