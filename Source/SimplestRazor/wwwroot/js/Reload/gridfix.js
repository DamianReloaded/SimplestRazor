'use strict';

class GridFix {
    constructor(ctrlName) {
        let this_ = this;
        this.CtrlName = ctrlName;
        this.JsonURL = '/?r=Examples_DynamicGrid_Data_SelectAll';
        this.JsonData = '';
        this.Data = null;
        this.DataFiltered = null;
        this.SelectedId = -1
        this.SelectedText = null;
        this.RowsPerPage = 10;
        this.CurrentPage = 1;
        this.PreviousPageElement = document.getElementById(this.CtrlName + '_PagerBtn1');
        this.PagerFirst = document.getElementById(this.CtrlName + '_PagerFirst');
        this.PagerPrev = document.getElementById(this.CtrlName + '_PagerPrev');
        this.PagerNext = document.getElementById(this.CtrlName + '_PagerNext');
        this.PagerLast = document.getElementById(this.CtrlName + '_PagerLast');
        this.PagerPages = document.getElementById(this.CtrlName + '_PagerPages');
        this.Div1 = document.getElementById(this.CtrlName + '_Div1');
        this.Div2 = document.getElementById(this.CtrlName + '_Div2');
        this.Table = document.getElementById(this.CtrlName + '_Table');
        this.THead = document.getElementById(this.CtrlName + '_THead');
        this.TBody = document.getElementById(this.CtrlName + '_TBody');
        this.TFoot = document.getElementById(this.CtrlName + '_TFoot');
        this.Rectangle = document.getElementById(this.CtrlName + '_Rectangle');
        this.TextboxSearchId = this.CtrlName + '_SearchText';
        this.setTextBoxSearch();
        this.CommandColumns = `[
                {
                    "cssClass": "table_button_edit",
                        "icon": "mdi-pencil",
                            "funcName": "alert",
                                "title": "Editar"
                },
                {
                    "cssClass": "table_button_delete",
                        "icon": "mdi-trash-can",
                            "funcName": "alert",
                                "title": "Eliminar"
                }
            ]`;
        this.HiddenColumns = "";
        this.HiddenColumnsArray = [];
        this.setCommandColumns();

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

    setCommandColumns() {
        this.CommandColumnsArray = JSON.parse(this.CommandColumns);
    }

    applyParameters() {
        this.HiddenColumnsArray = this.HiddenColumns.split(",");
        this.setTextBoxSearch();
        this.setCommandColumns()
        this.refresh();
    }

    clearSelection() {
        this.SelectedId = -1
        this.SelectedText = null;
    }

    addCommandButton(tr, cssClass, icon, funcName, obj, title) {
        let td = document.createElement('td');
        td.classList.add('table_command_column');
        let a = document.createElement('a');
        a.classList.add(cssClass);
        a.attributes['href'] = '#';
        a.onclick = function () { window[funcName](obj); };
        let ic = document.createElement('i');
        ic.classList.add('mdi');
        ic.classList.add(icon);
        ic.attributes['data-toggle'] = 'tooltip';
        ic.attributes['title'] = title;
        a.appendChild(ic);
        td.appendChild(a);
        tr.appendChild(td);
    }

    populateRow(i) {
        let obj = this.DataFiltered[i];
        var tr = document.createElement('tr');
        this.TBody.appendChild(tr);

        // Command Columns
        for (var c = 0; c < this.CommandColumnsArray.length; c++) {
            this.addCommandButton(tr, this.CommandColumnsArray[c].cssClass, this.CommandColumnsArray[c].icon, this.CommandColumnsArray[c].funcName, obj, this.CommandColumnsArray[c].title)
        }

        for (var key in obj) {
            var value = obj[key];

            if (key == this.ColumnNameId) {
                tr.attributes['data-id'] = value;
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
        this.THead.appendChild(tr);

        // Command Columns
        for (var c = 0; c < this.CommandColumnsArray.length; c++) {
            let th = document.createElement('th');
            th.classList.add('table_command_column');
            tr.appendChild(th);
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
            if (this.RowsPerPage != 0) {
                from = (this.CurrentPage - 1) * this.RowsPerPage;
                to = from + this.RowsPerPage;
                to = (to > this.DataFiltered.length) ? this.DataFiltered.length : to;
            }
            for (var i = from; i < to; i++)
            {
                this.populateRow(i)
            }
        } //if (data.length > 0)

        this.setPagerButtonsAttributes();
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
            for (var key in obj)
            {
                let val = obj[key];
                if (val == null) continue;
                if (val.toString().toLowerCase().includes(tmp.toLowerCase()))
                {
                    this.DataFiltered.push(obj);
                    break;
                }
            }
        }
        this.populate();
    }

    setRowsPerPage(value) {
        this.RowsPerPage = Number(value);
        this.CurrentPage = 1;
        this.refresh();
    }

    setCurrentPage(element) {
        this.CurrentPage = Number(element.value);
        this.refresh();
    }

    setPagerButtonsAttributes() {
        if (this.DataFiltered == null) return;
        this.drawPageButtons();
        if (this.CurrentPage == 1) {
            this.PagerFirst.setAttribute('disabled', '');
            this.PagerPrev.setAttribute('disabled', '');
        }
        else {
            this.PagerFirst.removeAttribute('disabled');
            this.PagerPrev.removeAttribute('disabled');
        }

        let numPages = this.numberOfPages();

        if (this.CurrentPage == numPages || numPages==0) {
            this.PagerLast.setAttribute('disabled', '');
            this.PagerNext.setAttribute('disabled', '');
        }
        else {
            this.PagerLast.removeAttribute('disabled');
            this.PagerNext.removeAttribute('disabled');
        }
    }

    goToFirst(element) {
        this.CurrentPage = 1;
        this.refresh();
    }
    goToPrev(element) {
        this.CurrentPage--;
        this.refresh();
    }
    goToNext(element) {
        this.CurrentPage++;
        this.refresh();
    }
    goToLast(element) {
        this.CurrentPage = this.numberOfPages();
        this.refresh();
    }

    numberOfPages() {
        let numPages = (this.RowsPerPage == 0) ? 1 : Math.round(this.DataFiltered.length / this.RowsPerPage);
        return (numPages == 0) ? 1 : numPages;
    }

    drawPageButtons() {
        this.PagerPages.innerHTML = '';
        let numPages = this.numberOfPages();
        for (var i = 1; i <= numPages; i++) {
            let btn = document.createElement('button');
            //btn.classList.add('table_command_column');
            btn.id = "MyTable_PagerBtn" + i;
            btn.value = i;
            btn.innerHTML = i;
            this.PagerPages.appendChild(btn);
            let this_ = this;
            btn.onclick = function () { this_.setCurrentPage(btn); }
            if (i == this.CurrentPage) btn.classList.add('active');
        }
    }

    clear() {
        this.THead.innerHTML = '';
        this.TBody.innerHTML = '';
        this.TFoot.innerHTML = '';
    }

    refresh() {
        if (this.JsonURL.length > 0) {
            this.getData();
        }
        else {
            if (this.JsonData.length>0) this.setJson(this.JsonData);
            this.populate();
        }
    }

    setJson(data) {
        this.Data = JSON.parse(data);
        this.DataFiltered = this.Data;
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

    getData() {
        let this_ = this;
        let token = $("input[name='__RequestVerificationToken']", form).val();
        $.post(this.JsonURL,
            {
                __RequestVerificationToken: token,
                param1: '',
                param2: ''
            },
            function (data, status) { this_.dataCallback(data, status); }
        );
    }
}