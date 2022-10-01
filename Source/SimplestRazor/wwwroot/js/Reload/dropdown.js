'use strict';

class ReloadDropdown {
    constructor(ctrlName) {
        let this_ = this;
        this.CtrlName = ctrlName;
        this.Ctrl = document.getElementById(this.CtrlName);
        this.JsonURL = '/?r=Examples_DynamicGrid_Data_SelectAll';
        this.ColumnNameId = 'UserId';
        this.ColumnNameText = 'UserName';
        this.PlaceholderText = 'Seleccionar';
        this.AddEmptyOption = true;
        this.SelectedValue = '';
        this.Data = JSON.parse('[]');
        this.clearSelection();
        Object.seal(this);
    }

    applyParameters() {
        this.Ctrl.placeholder = this.PlaceholderText;
        this.refresh();
    }

    clearSelection() {

    }

    AddRow(value, text) {
        var opt = document.createElement('option');
        opt.setAttribute('value', value);
        if (this.SelectedValue == value) {
            opt.setAttribute('selected', true);
        }
        var text1 = document.createTextNode(text);
        opt.appendChild(text1);
        this.Ctrl.appendChild(opt);
    }

    populateRow(i) {
        let obj = this.Data[i];
        var opt = document.createElement('option');

        for (var key in obj)
        {
            if (key == this.ColumnNameId)
            {
                var value = obj[key];
                opt.setAttribute('value', value);
                if (this.SelectedValue == value) {
                    opt.setAttribute('selected', true);
                }
            }
            if (key == this.ColumnNameText)
            {
                var value = obj[key];
                var text1 = document.createTextNode(value);
                opt.appendChild(text1);
            }
        }
        this.Ctrl.appendChild(opt);
    }

    populate() {
        this.clear();
        if (this.AddEmptyOption) this.AddRow("-1", this.PlaceholderText);
        if (this.Data.length > 0)
        {
            for (var i = 0; i < this.Data.length; i++)
            {
                this.populateRow(i)
            }
        } 
    }

    clear() {
        this.Ctrl.textContent = '';
    }

    refresh() {
        if (this.JsonURL.length > 0) {
            this.getData();
        }
        else {
            this.populate();
        }
    }

    setJson(data) {
        this.Data = JSON.parse(data);
    }

    dataCallback(data, status) {
        try {
            this.setJson(data);
            this.populate(); //status
        }
        catch (e) {

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
            function (data, status)
            {
                this_.dataCallback(data, status);
            }
        );
    }
}