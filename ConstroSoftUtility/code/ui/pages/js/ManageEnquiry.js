$(document).ready(function () {
    $('#tabs').tab();
    initBootstrapComponants();
});

function initBootstrapComponants() {

    var dropDownIds = ["drpSearchBy", "drpSearchByValue", "drpSalutation", "drpGender", "drpMaritalStatus", "drpOccupation", "drpEmployee",
                        "drpPropertyType", "drpPropertyLocation", "drpProperty", "drpPropUnitType", "drpEnquirySource", "drpEnquiryStatus"];
    applySelectPicker(dropDownIds);
    var inputIds = ["txtDOB", "txtEnquiryDate", "txtFollowupDate"];
    applyDatePicker(inputIds);
    initEnquiryGrid();
    $('a[href="#tab2Content"]').tab('show');
    //initPaymentHistory();
    //This script stores the current selected tab so that when any ajax call refreshes the page will land on same tab
    $('a.storeTabName').click(function () {
        $("[id$='activeTabHdn']").val($(this).attr('href'));
        /*$("[id$='tab1SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary1']").addClass('hidden');
        $("[id$='tab2SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary2']").addClass('hidden');
        $("[id$='tab3SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary3']").addClass('hidden');*/
    });
    //This script will enable tabs which was last active even after postback call.
    if ($("[id$='activeTabHdn']").val()) {
        $('a[href="' + $("[id$='activeTabHdn']").val() + '"]').tab('show');
    }
}

function initEnquiryGrid() {
    var dtOptions = {
        tableId: "enquiryGrid",
        pageLength: 10,
        responsiveModalTitle: "Enquiry Details",
        isViewOnly: "false",
        showSearch: "true",
        customBtnGrpId: "#customBtnDiv"
    };
    var dtTable = applyCustomResponsiveDtTable(dtOptions);
    jumpToTablePage(dtTable, "jumpToEnquiryHdnId");
}
function showTab3() {
    $('a[href="#tab3Content"]').click();
}