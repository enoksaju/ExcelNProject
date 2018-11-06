"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var uri = 'data:application/vnd.ms-excel;base64,';
var ExcelTemplate = /** @class */ (function () {
    function ExcelTemplate(table, name, style) {
        if (name === void 0) { name = "Hoja1"; }
        if (style === void 0) { style = null; }
        this.template = "\n<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">  \n  <head>\n    <!--[if gte mso 9]>\n      <xml>\n        <x:ExcelWorkbook>\n          <x:ExcelWorksheets>\n            <x:ExcelWorksheet>\n              <x:Name>{worksheet}</x:Name>\n              <x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions>\n            </x:ExcelWorksheet>\n          </x:ExcelWorksheets>\n        </x:ExcelWorkbook>\n      </xml>\n    <![endif]-->\n  <style>{style}</style>\n  </head>\n  <body>\n    <table>{table}</table>\n  </body>\n</html>\n";
        this.format = function (template, obj) { return template.replace(/{(\w+)}/g, function (m, p) { return obj[p]; }); };
        this.changeString = function (template, obj) {
            return template
                .replace(/<(\w+)/g, function (m, p) { return '<' + obj[p]; })
                .replace(/<\/(\w+)/g, function (m, p) { return '</' + obj[p]; });
        };
        this.style = style ? style : '';
        this.table = this.matTableToTable(table.innerHTML);
        this.name = name;
    }
    ExcelTemplate.prototype.matTableToTable = function (table) {
        var _this = this;
        var tb = (function () {
            var ret = document.createElement("table"), _tb = table;
            _tb = _tb.replace(new RegExp('<!---->', 'g'), "");
            _tb = _tb.replace(new RegExp('[-]', 'g'), '');
            _tb = _this.changeString(_tb, { matheaderrow: 'tr', matheadercell: 'th', matrow: 'tr', matcell: 'td', span: 'span' });
            _tb = _tb.replace(new RegExp('<tr', 'g'), "\n\n<tr");
            _tb = _tb.replace(new RegExp('<th', 'g'), "\n\t<th");
            _tb = _tb.replace(new RegExp('<td', 'g'), "\n\t<td");
            _tb = _tb.replace(new RegExp('<span', 'g'), "\n\t\t<span");
            ret.innerHTML = _tb;
            return ret;
        })(), gtArr = function (cls) { return Array.prototype.slice.call(tb.getElementsByClassName(cls)); }, arr = [gtArr('matheadercell'), gtArr('matrow'), gtArr('matcell'), gtArr('matheaderrow')];
        arr.forEach(function (_arr) {
            _arr.forEach(function (_Ele) {
                _Ele.setAttribute('style', _Ele.classList.contains('dayheader') ?
                    'mso-rotate:90;background: #81DAF5;' : (_Ele.classList.contains('hastextExcel') ?
                    'mso-number-format:"\@";' : (_Ele.classList.contains('matheadercell') ?
                    'background: #81DAF5;' : '')));
                _Ele.setAttribute('class', '');
            });
        });
        console.log(tb);
        return tb.innerHTML;
    };
    ExcelTemplate.prototype.ExportResult = function () {
        return this.format(this.template, { table: this.table, worksheet: this.name, style: this.style });
    };
    return ExcelTemplate;
}());
var ConverterService = /** @class */ (function () {
    function ConverterService() {
    }
    ConverterService.prototype.toXls = function (table, name) {
        var tp = new ExcelTemplate(table, name, ".day-header{ mso-rotate:90; }"), base64 = function (s) { return window.btoa(decodeURI(decodeURIComponent(s))); };
        return uri + base64(tp.ExportResult());
    };
    ConverterService = __decorate([
        core_1.Injectable()
    ], ConverterService);
    return ConverterService;
}());
exports.ConverterService = ConverterService;
//# sourceMappingURL=converter.service.js.map