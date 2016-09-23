
$(document).ready(function () {
    $('#tabs').tab();
    initBootstrapComponants();
});

function initBootstrapComponants() {
    $('a[href="#tab1Content"]').tab('show');
    var dropDownIds = ["drpAcntType"];
    applySelectPicker(dropDownIds);
    //Note: Show tab in which datatable to be applied. Other wise it does not align columns correctly
    //$('a[href="#tab2Content"]').tab('show');
    initAccountGrid();
    //This script stores the current selected tab so that when any ajax call refreshes the page will land on same tab
    $('a.storeTabName').click(function () {
        $("[id$='activeTabHdn']").val($(this).attr('href'));
        $("[id$='tab1SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary1']").addClass('hidden');
        $("[id$='tab2SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary2']").addClass('hidden');
    });
    //Set the name of Second property tab whatever set on server
    if ($("[id$='tab2NameHdn']").val() != "") {
        $('#tab2AnchorId').html($("[id$='tab2NameHdn']").val());
    }
    //This script stores the current selected tab so that when any ajax call refreshes the page will land on same tab
    $('a.storeTabName').click(function () {
        $("[id$='activeTabHdn']").val($(this).attr('href'));
    });
    //This script will enable tabs which was last active even after postback call.
    if ($("[id$='activeTabHdn']").val()) {
        $('a[href="' + $("[id$='activeTabHdn']").val() + '"]').tab('show');
    }
}

function initAccountGrid() {
    var dtOptions = {
        tableId: "accountGrid",
        pageLength: 10,
        responsiveModalTitle: "Account Information",
        isViewOnly: $("[id$=viewOnlyTableHdn]").val(),
        showSearch: "true",
        customBtnGrpId: "#customBtnDiv"
    };
    var dtTable = applyCustomResponsiveDtTable(dtOptions);
    jumpToTablePage(dtTable, "jumpToAcntHdnId");
}