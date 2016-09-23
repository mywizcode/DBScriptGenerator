$(document).ready(function () {
    $('#tabs').tab();
    initBootstrapComponants();
});

function initBootstrapComponants() {

    var dropDownIds = ["drpSearchBy", "drpSearchByValue", "drpSalutation", "drpGender", "drpMaritalStatus", "drpOccupation",
                        "drpDepartment", "drpDesignation"];
    applySelectPicker(dropDownIds);
    var inputIds = ["txtDOB", "txtJoiningDate"];
    applyDatePicker(inputIds);
    initEmployeeGrid();
    $('a[href="#tab2Content"]').tab('show');
    //This script stores the current selected tab so that when any ajax call refreshes the page will land on same tab
    $('a.storeTabName').click(function () {
        $("[id$='activeTabHdn']").val($(this).attr('id'));
        /*$("[id$='tab1SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary1']").addClass('hidden');
        $("[id$='tab2SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary2']").addClass('hidden');
        $("[id$='tab3SuccessPanel']").addClass('hidden');
        $("[id$='ValidationSummary3']").addClass('hidden');*/
    });
    //This script will enable tabs which was last active even after postback call.
    if ($("[id$='activeTabHdn']").val()) {
        $('a[id$="' + $("[id$='activeTabHdn']").val() + '"]').tab('show');
    }
    initViewMode();
}

function initViewMode() {
    var pageMode = $("[id$='pageModeHdn']").val();
    if ("VIEW" == pageMode) {
        $('div[id$="tab2Content"]').find('input.form-control.input-sm').each(function () {
            $this = $(this);
            var tmp = $('<label class="rdview-text" />').text($this.val());
            $this.replaceWith(tmp);
        });
        $('div[id$="tab2Content"]').find('textarea.form-control.input-sm').each(function () {
            $this = $(this);
            var tmp = $('<label class="rdview-text" />').text($this.val());
            $this.replaceWith(tmp);
        });
        $('div[id$="tab2Content"]').find('div.btn-group.bootstrap-select').each(function () {
            $this = $(this);
            var tmp = $('<label class="rdview-text" />').text($this.find('select :selected').text());
            $this.replaceWith(tmp);
        });
    }
}

function initEmployeeGrid() {
    var dtOptions = {
        tableId: "employeeGrid",
        pageLength: 10,
        responsiveModalTitle: "Employee Details",
        isViewOnly: "false",
        showSearch: "true",
        customBtnGrpId: "#empSearchBtnDiv"
    };
    var dtTable = applyCustomResponsiveDtTable(dtOptions);
    jumpToTablePage(dtTable, "jumpToEmployeeHdnId");
}

function initEmployeeGrid1() {
    var dtOptions = {
        tableId: "employeeGrid",
        exportFileName: "Property Report",
        exportFileTitle: "Property Details",
        exportColumns: "1, 2, 3, 4, 5, 6",
        modalHeaderText: "Property Details",
        customBtnGrpId: "#empSearchBtnDiv"
    };
    var dtTable = applyDataTable(dtOptions);
    jumpToTablePage(dtTable, "jumpToPropertyHdnId");
}
function showTab3() {
    $('a[href="#tab3Content"]').click();
}