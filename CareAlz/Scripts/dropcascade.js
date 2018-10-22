$(document).ready(function () {
    $("#StateId").change(function () {
        $("#MunicipalityId").empty();
        $("#MunicipalityId").append('<option value="0">[--Selecciona un Municipio--]</option>');
        $.ajax({
            type: 'POST',
            url: Url,
            dataType: 'json',
            data: { stateId: $("#StateId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#MunicipalityId").append('<option value="'
                        + data.MunicipalityId + '">'
                        + data.Description + '</option>');
                });
            },
            error: function (ex) {
                alert('Fallo la consulta de municipios.' + ex);
            }
        });
        return false;
    })
});

$(document).ready(function () {
    $("#MunicipalityId").change(function () {
        $("#ColonyId").empty();
        $("#ColonyId").append('<option value="0">[--Selecciona una Colonia--]</option>');
        $.ajax({
            type: 'POST',
            url: Urlc,
            dataType: 'json',
            data: { municipalityId: $("#MunicipalityId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#ColonyId").append('<option value="'
                        + data.ColonyId + '">'
                        + data.Description + '</option>');
                });
            },
            error: function (ex) {
                alert('Fallo la consulta de municipios.' + ex);
            }
        });
        return false;
    })
});
