'use strict';

class CheckboxList {
    constructor(ctrlName) {
        let this_ = this;
        this.CtrlName = ctrlName;
        this.JsonURL = '/?r=Examples_DynamicGrid_Data_SelectAll';
        this.JsonData = '';
        this.JsonParams = {};
        this.JsonCheckedData = '';
        this.JsonCheckedURL = '';
        this.JsonCheckedParams = {};
        this.Data = null;
        this.DataChecked = null;
        this.DataFiltered = null;
        this.ColumnNameId = 'Id';
        this.ShowCheckboxes = true;
        this.ShowHeader = true;
        this.Div1 = document.getElementById(this.CtrlName + '_Div1');
        this.Div2 = document.getElementById(this.CtrlName + '_Div2');
        this.Table = document.getElementById(this.CtrlName + '_Table');
        this.THead = document.getElementById(this.CtrlName + '_THead');
        this.TBody = document.getElementById(this.CtrlName + '_TBody');
        this.TFoot = document.getElementById(this.CtrlName + '_TFoot');
        this.Rectangle = document.getElementById(this.CtrlName + '_Rectangle');
        this.TextboxSearchId = this.CtrlName + '_SearchText';
        this.setTextBoxSearch();
        this.HiddenColumns = "";
        this.HiddenColumnsArray = [];

        this.clearSelection();
        Object.seal(this);
    }

    setTextBoxSearch() {
        let this_ = this;
        this.TextboxSearch = document.getElementById(this.TextboxSearchId);
        if (this.TextboxSearch == null) return;
        this.TextboxSearch.addEventListener('keyup', (ev) => {
            this_.doSearch(ev)
        });
    }

    applyParameters() {
        this.HiddenColumnsArray = this.HiddenColumns.split(",");
        this.setTextBoxSearch();
        this.refresh();
    }

    clearSelection() {

    }

    populateRow(i) {
        let obj = this.DataFiltered[i];
        var tr = document.createElement('tr');
        this.TBody.appendChild(tr);

        // Command Columns
        for (var key in obj) {
            var value = obj[key];

            if (key == this.ColumnNameId) {
                tr.attributes['data-id'] = value;

                if (this.ShowCheckboxes) {
                    let td = document.createElement('td');
                    td.classList.add('table_command_column');
                    let chk = document.createElement('input');
                    chk.classList.add("table_checkbox");
                    chk.setAttribute('id', this.CtrlName);
                    chk.setAttribute('name', this.CtrlName);
                    chk.setAttribute('type', 'checkbox');
                    chk.setAttribute('value', value);

                    for (var k = 0; k < this.DataChecked.length; k++) {
                        let objChk = this.DataChecked[k];
                        var valueCheck = objChk[key];
                        if (valueCheck == value) {
                            chk.setAttribute('checked', 'true');
                            break;
                        }
                    }

                    td.appendChild(chk);
                    tr.appendChild(td);
                }

            }
            if (key == this.ColumnNameText) {
                tr.attributes['data-text'] = value;
            }

            let text1 = document.createTextNode(value);
            let td = document.createElement('td');
            let span = document.createElement('span');
            if (this.HiddenColumnsArray.includes(key)) td.classList.add('gridfix-hidden');
            td.appendChild(span);
            span.appendChild(text1);
            tr.appendChild(td);
        }
    }

    populate() {
        this.clear();

        var tr = document.createElement('tr');
        tr.classList.add('gridfix-headers');
        if (this.ShowHeader)
            this.THead.appendChild(tr);

        // Command Columns
        if (this.ShowCheckboxes) {
            let td = document.createElement('th');
            td.classList.add('table_command_column');
            tr.appendChild(td);
        }

        if (this.DataFiltered.length > 0) {
            var obj = this.DataFiltered[0];

            for (var key in obj) {
                var text1 = document.createTextNode(key);
                var th = document.createElement('th');
                if (this.HiddenColumnsArray.includes(key)) th.classList.add('gridfix-hidden');
                tr.appendChild(th);
                th.appendChild(text1);
            }

            let from = 0;
            let to = this.DataFiltered.length;
            for (var i = from; i < to; i++) {
                this.populateRow(i)
            }
        } //if (data.length > 0)
    }

    doSearch(p1) {
        if (this.TextboxSearch == null) return;
        var tmp = this.TextboxSearch.value;
        if (tmp.length < 1) {
            this.DataFiltered = this.Data;
            this.populate();
            return;
        }

        this.TBody.innerHTML = '';
        this.clearSelection();
        this.DataFiltered = JSON.parse('[]');
        for (var i = 0; i < this.Data.length; i++) {
            var obj = this.Data[i];
            for (var key in obj) {
                let val = obj[key];
                if (val == null) continue;
                if (val.toString().toLowerCase().includes(tmp.toLowerCase())) {
                    this.DataFiltered.push(obj);
                    break;
                }
            }
        }
        this.populate();
    }

    clear() {
        this.THead.innerHTML = '';
        this.TBody.innerHTML = '';
        this.TFoot.innerHTML = '';
    }

    refresh() {
        this.refreshDataChecked();
        this.refreshData();
    }

    refreshData() {
        if (this.JsonURL.length > 0) {
            this.getData();
        }
        else {
            if (this.JsonData.length > 0) this.setJson(this.JsonData);
            this.populate();
        }
    }

    refreshDataChecked() {
        if (this.JsonCheckedURL.length > 0) {
            this.getDataChecked();
        }
        else {
            if (this.JsonCheckedData.length > 0) this.setCheckedJson(this.JsonCheckedData);
        }
    }

    setJson(data) {
        this.Data = JSON.parse(data);
        this.DataFiltered = this.Data;
    }

    setCheckedJson(data) {
        this.DataChecked = JSON.parse(data);
    }

    dataCallback(data, status) {
        try {
            this.setJson(data);
            this.populate();
        }
        catch (e) {
            console.log(e);
        }
    }

    dataCheckedCallback(data, status) {
        try {
            this.setCheckedJson(data);
            this.populate();
        }
        catch (e) {
            console.log(e);
        }
    }

    getData() {
        let this_ = this;
        let token = $("input[name='__RequestVerificationToken']", form).val();
        let urlParams = { __RequestVerificationToken: token };
        $.extend(urlParams, urlParams, this.JsonParams);
        $.post(this.JsonURL, urlParams, function (data, status) { this_.dataCallback(data, status); });
    }

    getDataChecked() {
        let this_ = this;
        let token = $("input[name='__RequestVerificationToken']", form).val();
        let urlParams = { __RequestVerificationToken: token };
        $.extend(urlParams, urlParams, this.JsonCheckedParams);
        $.post(this.JsonCheckedURL, urlParams, function (data, status) { this_.dataCheckedCallback(data, status); }
        );
    }
}