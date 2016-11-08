$(() => {
    function processRequest(json) {
        $("#result-container").html(json);
    }

    $("#api-keycheck, #get-upload-url, #get-all-assets").click(event => {
        var url = $(event.target).data("action");
        $.getJSON(url, null, function (data, textStatus, jqXhr)
        {
            processRequest(jqXhr.responseText);
        });
    });

    $("#get-specific-asset").click(event => {
        var url = $(event.target).data("action");
        $.getJSON(url, { id: $("#get-specific-asset-id").val() }, function (data, textStatus, jqXhr) {
            processRequest(jqXhr.responseText);
        });
    });

    $("#search-through-assets").click(event => {
        var url = $(event.target).data("action");
        $.getJSON(url, { query: $("#search-through-assets-query").val() }, function (data, textStatus, jqXhr) {
            processRequest(jqXhr.responseText);
        });
    });

    $("#filter-search-results").click(event => {
        var url = $(event.target).data("action");
        var data = {
            query: $("#filter-search-results-query").val(),
            extraQuery: $("#filter-search-results-extraQuery").val(),
            color: $("#filter-search-results-color").val()
        }
        $.getJSON(url, data, function (data, textStatus, jqXhr) {
            processRequest(jqXhr.responseText);
        });
    });
});