$(document).ready(function () {
    //On load of page activate menu link
    activateCurrentMenuLink();
    var $sidebarNav = $('.sidebar');
    $(document).mouseup(function (e) {
        if (!$sidebarNav.is(e.target)) {
            //TODO - re-select menu for loaded page
            //e.stopPropagation();
            //activateCurrentMenuLink();
        }
    });
});

function activateCurrentMenuLink() {
    var activeLink = $.AdminLTE.ConstroSoft.getLinkToActivate();
    var ul = activeLink.parent();
    if (ul != 'undefined') {
        if (ul.hasClass('treeview-menu') && !ul.hasClass('menu-open')) {
            var treeViewLI = ul.parent();
            treeViewLI.find('a').click();
        } else if (!activeLink.hasClass('active')){
            activeLink.addClass('active');
        }
    }
}

var dialog;

jQuery.fn.extend({
    disable: function (state) {
        return this.each(function () {
            var $this = $(this);
            if ($this.is('input, button, textarea, select'))
                this.disabled = state;
            else
                $this.toggleClass('disabled', state);
        });
    }
});

$.fn.mirror = function (selector) {
    return this.each(function () {
        var $this = $(this);
        var $selector = $(selector);
        $this.bind('change keyup', function () {
            $selector.val($this.val()).change();
        });
    });
};
/**
 * This function will take to the page where 'element' is present with attribute 'index' having value given in 'data'.
 * Usage - dtTable.api().page.jumpToIndex("6"); 
 */
jQuery.fn.dataTable.Api.register('page.jumpToIndex()', function (data) {
    var pos = -1;
    this.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var index = this.nodes().to$().find('.row-identifier').attr('row-identifier');
        if (index == data) {
            pos = rowLoop;
        }
    });
    if (pos >= 0) {
        var page = Math.floor(pos / this.page.info().length);
        this.page(page).draw(false);
    }
});
/**
 * This function will select the datatable row check box for given row identifier 'data'
 * Usage - dtTable.api().page.selectRecord("checkBoxId","1"); 
 */
jQuery.fn.dataTable.Api.register('page.selectRecord()', function (elementId, data) {
    var pos = -1;
    this.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var index = this.nodes().to$().find('.row-identifier').attr('row-identifier');
        if (index == data) {
            //Here rowIdx should be used as it is used to form checkbox element id.
            pos = rowIdx;
        }
    });
    if (pos >= 0) {
        var chBox = this.row(pos).nodes().to$().find("[id$='" + elementId + "_" + pos + "']");
        var value = $(chBox).prop('checked');
        if (value == false) {
            $(chBox).prop('checked', true);
        }
    }
});


function applyAdditionalStyle() {
    //Apply Small css for bootstrap-select dropdown and input inside it.
    $('div.bootstrap-select > button').addClass("btn-sm");
    $('div.bootstrap-select > div.searchbox > input').addClass("input-sm");
}

function applyDataTable(dtOptions) {
    $("[id$='" + dtOptions.tableId + "']").addClass('col2-responsive');
    $("[id$='" + dtOptions.tableId + "']").prepend($("<thead></thead>").append($("[id$='" + dtOptions.tableId + "']").find("tr:first")));
    var dtTable = $("[id$='" + dtOptions.tableId + "']").DataTable({
        dom: "<'row'<'col-sm-6 tmpCustomBtn'l><'col-sm-6'f>>" +
                     "<'row'<'col-sm-12'tr>>" +
                     "<'row'<'col-sm-3'B><'col-sm-2'i><'col-sm-7'p>>",
        buttons: [
                    {
                        extend: 'excelHtml5',
                        filename: dtOptions.exportFileName,
                        exportOptions: {
                            columns: [dtOptions.exportColumns]
                        }
                    },
                    {
                        extend: 'pdf',
                        title: dtOptions.exportFileTitle,
                        filename: dtOptions.exportFileName,
                        exportOptions: {
                            columns: [dtOptions.exportColumns]
                        }
                    },
                    'print'
                 ],
        columnDefs: [
               { "targets": 0,
                   "searchable": false,
                   "orderable": false
               }
            ],
        order: [[1, 'asc']],
        responsive: {
            details: {
                type: 'column',
                target: 1,
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
                        var data = row.data();
                        return dtOptions.modalHeaderText;
                    }
                }),
                renderer: function (api, rowIdx, columns) {
                    var data = $.map(columns, function (col, i) {
                        return i != 0 ?
							'<tr data-dt-row="' + col.rowIndex + '" data-dt-column="' + col.columnIndex + '">' +
								'<td nowrap style="width: 20%;">' + col.title + ':' + '</td> ' +
								'<td>' + col.data + '</td>' +
							'</tr>' :
							'';
                    }).join('');
                    var footer = '<tfoot><tr><th style="text-align: center;" colspan=2>' +
									'<button type="button" class="btn btn-primary btn-sm" data-dismiss="modal">Close</button>' +
									'</th></tr></tfoot>';
                    var modalContent = data ? $('<table class="table datatable-modal-table">').append(data).append(footer) : false;
                    return modalContent;
                }
            }
        }
    });
    toolTipOnTable(dtOptions.tableId);
    //If dtOptions has 'customBtnGrpId' then replace Page Length section with given button group.
    if(dtOptions.customBtnGrpId) {
    	$("[id$='" + dtOptions.tableId + "_wrapper']").find('.tmpCustomBtn').html($(dtOptions.customBtnGrpId).html());
        $(dtOptions.customBtnGrpId).html('')
    }
    $('div.dt-buttons > a').removeClass("btn-default");
    $('div.dt-buttons > a').addClass("btn-primary btn-sm table_button_space");
    return dtTable;
}

function toolTipOnTable(tableId) {
    $("[id$='" + tableId + "']" + ' tbody td').each(function () {
        var $td = $(this);
        $td.attr('title', '');
        $td.attr('title', $td.text());
    });
    /* Apply the tooltips */
    $("[id$='" + tableId + "']" + 'thead th[title]').tooltip({
        "container": 'body'
    });
}

function applySelectPicker(dropDownIds) {
    $.each(dropDownIds, function (index, id) {
        $("[id$='" + id + "']").selectpicker();
    });
    $('div.bootstrap-select').addClass("dropdown-100-percent");
    $('div.bootstrap-select > button').addClass("btn-sm border-gray");
    $('div.bs-searchbox > input').addClass("input-sm");
}

function applyDatePicker(inputIds) {
    $.each(inputIds, function (index, id) {
        if ($("[id$='" + id + "']") != "undefined") {
            $("[id$='" + id + "']").datepicker({
                autoclose: true,
                todayBtn: true,
                todayHighlight: true,
                format: 'dd-M-yyyy'
            });
        }
    });
}

function jumpToTablePage(dtTable, jumpToHdnId) {
    var index = $("[id$='" + jumpToHdnId + "']").val();
    if (index && index != "") {
        dtTable.page.jumpToIndex(index);
        $("[id$='" + jumpToHdnId + "']").val('');
    }
}

function ConfirmUpdate() {
    return confirm("Are you sure you want to Update ?");
}
function ConfirmSave() {
    //return confirm("Are you sure you want to Save ?");
}
function ConfirmDate() {
    return confirm("Are you sure you want to Delete ?");
    /*return BootstrapDialog.alert({
        title: 'Delete',
        message: 'Are you sure you want to Delete ?'
    });*/
}

function ConfirmDelete(){

    return confirm("Are you sure you want to Delete ?");
}
/**
 * This function is used to apply datatable. It uses custom responsive feature (showing modal (+)). All columns in datatable are visible unlike datatatable
 * responsive behaviour where in last column is hidden.
 * dtOptions will have below variables.
 * 		tableId - This is id of datatable table grid.
 * 		tableCaption - Caption of the Datatable.
 * 		pageLength - PageLength for datatable. If not given default is 10
 * 		responsiveModalTitle - Title of Responsive Modal.
 * 		isViewOnly - true/false, Default true, Whether datatable to be initialized as view only. If true then first column (Action) need to be hide from server side.
 * 		customBtnGrpId - Custom group button to be added in top left corner of datatable.
 * @param dtOptions Various options.
 * @returns dtTable Datatable instance.
 */
function applyCustomResponsiveDtTable(dtOptions) {
	var pageLength = (dtOptions.pageLength)?dtOptions.pageLength:10;
    var tableCaption = (dtOptions.tableCaption)?'<div class="datatable-caption">'+dtOptions.tableCaption+'</div>':'';
    var isViewOnly = (dtOptions.isViewOnly == 'false') ? false : true; 
    var firstColsearchable = isViewOnly;
    var defaultColToOrder = (isViewOnly) ? 0 : 1;
    if (isViewOnly) {
        $("[id$='" + dtOptions.tableId + "']").addClass('col1-responsive-custom');
    } else {
        $("[id$='" + dtOptions.tableId + "']").addClass('col2-responsive-custom');
    }
    
    $("[id$='" + dtOptions.tableId + "']").prepend($("<thead></thead>").append($("[id$='" + dtOptions.tableId + "']").find("tr:first")));
    var dtTable = $("[id$='" + dtOptions.tableId + "']").DataTable({
        dom: "<'row'<'col-sm-4 tmpCustomBtn'l><'col-sm-4 tableCaption'i><'col-sm-4'f>>" +
			    "<'row'<'col-sm-12'tr>>" +
			    "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        pageLength: pageLength,
        columnDefs: [{ 
            	   "targets": 0,
                   "searchable": firstColsearchable,
                   "orderable": firstColsearchable
               }
            ],
        order: [[defaultColToOrder, 'asc']]
    });
    $("[id$='" + dtOptions.tableId + "_wrapper']").find('.tableCaption').html(tableCaption);
    if (dtOptions.showSearch != "true") {
        $("[id$='" + dtOptions.tableId + "_wrapper']").find('.dataTables_filter').html('');
    }
    //If dtOptions has 'customBtnGrpId' then replace Page Length section with given button group.
    $("[id$='" + dtOptions.tableId + "_wrapper']").find('.tmpCustomBtn').html('');
    if (dtOptions.customBtnGrpId) {
        $("[id$='" + dtOptions.tableId + "_wrapper']").find('.tmpCustomBtn').html($(dtOptions.customBtnGrpId).html());
        $(dtOptions.customBtnGrpId).html('')
    }
    applyCustomResponsiveModal(dtOptions, dtTable);
    toolTipOnTable(dtOptions.tableId);
    return dtTable;
}

function applyCustomResponsiveModal(dtOptions, dtTable) {
	var isViewOnly = (dtOptions.isViewOnly == 'false') ? false : true; 
	var responsiveColumnIdx = (isViewOnly) ? 1 : 2;//Second column is default column on which + sign will be shown.
	$("[id$='" + dtOptions.tableId + "']").on("click", 'tbody tr td:nth-child(' + responsiveColumnIdx + ')', function () {
	    var tr = $(this).parents('tr');
	    var tableContent = '<table class="table datatable-modal-table"><tbody>';
	    $(tr).find('td').each(function () {
	        var idx = dtTable.cell(this).index().column;
	        //If table is editable then do not show first column in modal.
	        if (isViewOnly || (!isViewOnly && idx != 0)) {
	            var colHeader = dtTable.column(idx).header();
	            var row = '<tr><td style="width:30%;">' + $(colHeader).html() + '</td><td>' + $(this).html() + '</td></tr>';
	            tableContent = tableContent + row;
	        }
	    });
	    var footer = '<tfoot><tr><th style="text-align: center;" colspan=2>' +
				    '<button type="button" class="btn btn-primary btn-sm" data-dismiss="modal">Close</button>' +
				    '</th></tr></tfoot>';
	    tableContent = tableContent + footer + '</table>';
	    BootstrapDialog.show({
	        title: dtOptions.responsiveModalTitle,
	        message: tableContent,
	        nl2br: false,
	        closable: false,
	        buttons: []
	    });
	});
}
function getDeleteMessage(element) {
    var message = $(element).attr('data-delete-message');
    $(element).each(function () {
        $.each(this.attributes, function () {
            if (this.specified) {
                if (this.name.startsWith("data-delete-message-opt")) {
                    var index = this.name.split('-').pop();
                    var pos = "{" + index + "}";
                    message = message.split(pos).join(this.value);
                }
            }
        });
    });
    return message;
}
/*
    Shows confirmation dialog. Array Input 'options' should have 'title' and 'message'.
*/
function confirmModalDelete_old(options, isElement) {
    var title = "";
    var message = "";
    var additionalData = "";
    if (isElement) {
        title = $(options).attr('data-delete-title');
        message = getDeleteMessage(options);
    } else {
        title = options.title;
        message = options.message;
    }
    BootstrapDialog.confirm({
        title: title,
        message: message,
        btnOKClass: 'btn btn-primary btn-sm',
        btnCancelClass: 'btn btn-primary btn-sm',
        closable: false,
        callback: function (result) {
            if (result) {
                if (isElement) {
                    var td = $(options).parents('td');
                    var btn = $(td).find('.deleteHdnTableBtn');
                    $(btn).click();
                } else {
                    doDelete(options);
                }
            }
        }
    });
    return false;
}
function confirmSelectedDelete(element) {
    var title = $(element).attr('data-delete-title');
    var btnToClick = $(element).attr('data-delete-button');
    var message = getDeleteMessage(element);
    BootstrapDialog.confirm({
        title: title,
        message: message,
        btnOKClass: 'btn btn-primary btn-sm',
        btnCancelClass: 'btn btn-primary btn-sm',
        closable: false,
        callback: function (result) {
            if (result) {
                $("[id$=" + btnToClick + "]").click();
            }
        }
    });
    return false;
}

function showModal(mdOptions) {

    dialog = new BootstrapDialog({
        title: mdOptions.modalTitle,
        message: $('#' + mdOptions.modalId).html(),
        nl2br: false,
        closable: false,
        buttons: [],
        onshown: function (dialogRef) {
            if (mdOptions.action == 'UPDATE') {
                dialog.getModalBody().find("[id$=saveModalBtnId]").html('Update');
            }
            dialog.getModalBody().find("[id$=modalHdnType]").val(mdOptions.modalName).change();
            dialog.getModalBody().find("[id$=modalActionHdn]").val(mdOptions.action).change();
            dialog.getModalBody().find("[id$=modalIdentifierHdn]").val(mdOptions.identifier).change();
            dialog.getModalBody().find("[id$=modalInput1Label]").html(mdOptions.input1Label);
            dialog.getModalBody().find("[id$=modalInput2Label]").html(mdOptions.input2Label);
            dialog.getModalBody().find("[id$=modalInput1]").val(mdOptions.input1Value).change();
            dialog.getModalBody().find("[id$=modalInput2]").val(mdOptions.input2Value).change();
            dialogRef.getModalBody().find("[id$=modalInput1]").focus();
        }
    });
    dialog.open();
}
//This method is called on click of Save button of Modal dialog
function saveModalDataClient() {

    $("[id$=modalHdnType]").val(dialog.getModalBody().find("[id$=modalHdnType]").val());
    $("[id$=modalActionHdn]").val(dialog.getModalBody().find("[id$=modalActionHdn]").val());
    $("[id$=modalIdentifierHdn]").val(dialog.getModalBody().find("[id$=modalIdentifierHdn]").val());
    $("[id$=modalInput1]").val(dialog.getModalBody().find("[id$=modalInput1]").val());
    $("[id$=modalInput2]").val(dialog.getModalBody().find("[id$=modalInput2]").val());

    //Invoke server side event for save.
    $("[id$=btSaveModalId]").click();
}
//This method is called on click of Cancel button of Modal dialog
function closeDialogClient() {
    if (dialog) {
        dialog.close();
    }
}

function setModalErrorMsg() {
    var errorMsg = $("[id$=modalErrorMsg]").val();
    $('.modal-body').find('#modalErrorDivId').toggleClass('hidden show');
    $('.modal-body').find('#modalErrorId').html(errorMsg);
}

function addPropertyType() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "PROPERTY_TYPE",
        modalTitle: "Add Property Type",
        action: "ADD",
        identifier: "",
        input1Label: "Property Type",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
    return false;
}
function addLocation() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "PROPERTY_LOCATION",
        modalTitle: "Add Property Location",
        action: "ADD",
        identifier: "",
        input1Label: "Location",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
    return false;
}
function addPropUnitType() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "PROPERTY_UNIT_TYPE",
        modalTitle: "Add Property Unit Type",
        action: "ADD",
        identifier: "",
        input1Label: "Property Unit Type",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
}
function addEnquirySource() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "ENQUIRY_SOURCE",
        modalTitle: "Add Enquiry Source",
        action: "ADD",
        identifier: "",
        input1Label: "Enquiry Source",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
}
function addOccupation() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "OCCUPATION",
        modalTitle: "Add Occupation",
        action: "ADD",
        identifier: "",
        input1Label: "Occupation",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
}
function addDepartment() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "DEPARTMENT",
        modalTitle: "Add Department",
        action: "ADD",
        identifier: "",
        input1Label: "Department Name",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
}
function addDesignation() {
    var mdOptions = {
        modalId: "modalDialogue",
        modalName: "DESIGNATION",
        modalTitle: "Add Designation",
        action: "ADD",
        identifier: "",
        input1Label: "Designation",
        input2Label: "Description",
        input1Value: "",
        input2Value: ""
    };
    showModal(mdOptions);
}