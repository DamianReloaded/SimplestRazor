'use strict';

class Selector {
    constructor(ctrlName) {
        let this_ = this;
        this.CtrlName = ctrlName;
        this.CtrlValueId = document.getElementById(this.CtrlName);
        this.CtrlValueText = document.getElementById(this.CtrlName + '_SelectorText');
        this.Content = document.getElementById(this.CtrlName + '_Content');
        this.ColumnNameId = 'UserId';
        this.ColumnNameText = 'UserName';
        this.Title = 'Seleccionar';
        this.SearchText = 'Buscar...';
        this.CancelText = 'Cancelar';
        this.AcceptText = 'Seleccionar';
        this.StyleContent = 'padding:5px 5px 5px 5px;';
        this.StyleHeader = 'margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;'
        this.StyleSearch = 'border:0px; width:280px';
        this.StyleItemList = 'height:200px; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;'
        this.ModalEffect = 'fade';
        this.ModalSize = ''; //modal-sm modal-lg modal-xl
        this.VerticalScroll = true;
        this.Data = null;
        this.ModalDiv = document.getElementById(this.CtrlName + '_SelectorModal');
        this.ModalDiv.classList.add(this.ModalEffect);
        this.Modal = $(this.ModalDiv);
        this.OlHeader = document.getElementById(this.CtrlName + '_olHeader');
        this.OlItems = document.getElementById(this.CtrlName + '_olItems');
        this.TextboxSearch = document.getElementById(this.CtrlName + '_SearchText');
        this.TextboxSearch.placeholder = this.SearchText;
        this.TextboxSearch.addEventListener('keyup', (ev) => {
            this_.doSearch(ev)
        });
        document.getElementById(this.CtrlName + '_Title').innerText = this.Title;
        document.getElementById(this.CtrlName + '_CancelButton').innerText = this.CancelText;
        document.getElementById(this.CtrlName + '_AcceptButton').innerText = this.AcceptText;
        this.setupDecorations();
        this.clearSelection();
        this.applyParameters();
        Object.seal(this);
    }

    applyParameters() {
        this.JsonURL = '/?r=Examples_DynamicGrid_Data_SelectAll';
        if (this.ModalSize != '') {
            this.ModalDiv.classList.add(this.ModalSize);
        }
        if (this.VerticalScroll) {
            this.OlHeader.style.overflowY = 'scroll';
            this.OlItems.style.overflowY = 'scroll';
        }
        this.OlHeader.style.cssText = this.StyleHeader;
        this.OlItems.style.cssText = this.StyleItemList;
        this.TextboxSearch.style.cssText = this.StyleSearch;
        this.Content.style.cssText = this.StyleContent;
    }

    show() {
        this.getData();
        this.Modal.modal('show');
    }

    hide() {
        this.Modal.modal('hide');
    }

    cancelSelector() {
        this.hide();
    }

    acceptSelector() {
        if (this.SelectedId == -1) return;
        this.CtrlValueId.value = this.SelectedId;
        this.CtrlValueText.value = this.SelectedText;
        this.hide();
    }

    doSearch(p1) {
        var tmp = this.TextboxSearch.value;
        this.OlItems.innerHTML = '';
        this.clearSelection();
        for (var i = 0; i < this.Data.length; i++) {
            var obj = this.Data[i];
            for (var key in obj) {
                if (obj[key].toString().toLowerCase().includes(tmp.toLowerCase())) {
                    this.populateRow(i);
                    break;
                }
            }
        }
    }

    clearSelection() {
        this.SelectedId = -1
        this.SelectedText = null;
    }

    setupDecorations() {
        let this_ = this;
        let olItems = jQuery('#' + this.CtrlName + '_olItems');

        $(function () {
            olItems.selectable({
                selected: function (event, ui) {
                    $(ui.selected).addClass('ui-selected').siblings().removeClass('ui-selected').children().removeClass('ui-selected');
                },
                stop: function () {
                    $('.ui-selected', this).each(function () {
                        if (this.attributes['data-id'] != null) { 
                            this_.SelectedId = this.attributes['data-id']
                            this_.SelectedText = this.attributes['data-text'];
                        }
                    });
                }
            });
        });
    }

    populateRow(i) {
        let liItem = document.createElement('li');
        liItem.attributes['data-id'] = '-1';
        liItem.style.userSelect = 'none';
        liItem.classList.add('dropdown-item');
        liItem.classList.add('ui-widget-content');
        this.OlItems.appendChild(liItem);

        let divContainer2 = document.createElement('div');
        divContainer2.classList.add('container');
        liItem.appendChild(divContainer2);

        let divRowItem = document.createElement('div');
        divRowItem.classList.add('row');
        divContainer2.appendChild(divRowItem);

        let obj = this.Data[i];
        for (var key in obj) {
            var value = obj[key];

            if (key == this.ColumnNameId) {
                liItem.attributes['data-id'] = value;
            }
            if (key == this.ColumnNameText) {
                liItem.attributes['data-text'] = value;
            }

            let text1 = document.createTextNode(value);
            let divCol = document.createElement('div');
            divCol.classList.add('col');
            divRowItem.appendChild(divCol);
            divCol.appendChild(text1);
        }
    }

    populateSelector() {
        this.OlHeader.innerHTML = '';
        this.OlItems.innerHTML = '';

        var liHeader = document.createElement('li');
        liHeader.classList.add('dropdown-header');
        liHeader.classList.add('ui-widget-content');
        this.OlHeader.appendChild(liHeader);

        var divContainer = document.createElement('div');
        divContainer.classList.add('container');
        liHeader.appendChild(divContainer);

        var divRowHeader = document.createElement('div');
        divRowHeader.classList.add('row');
        divContainer.appendChild(divRowHeader);

        if (this.Data.length > 0) {
            var obj = this.Data[0];

            for (var key in obj) {
                var text1 = document.createTextNode(key);
                var divCol = document.createElement('div');
                divCol.classList.add('col');
                divRowHeader.appendChild(divCol);
                divCol.appendChild(text1);
            }

            for (var i = 0; i < this.Data.length; i++) {
                this.populateRow(i)
            }
        } //if (data.length > 0)
    }

    dataCallback(data, status) {
        try {
            this.Data = JSON.parse(data);
            this.populateSelector(); //status
        }
        catch (e) {
            //console.print(e);
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