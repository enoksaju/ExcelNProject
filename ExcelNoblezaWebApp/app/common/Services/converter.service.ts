import { Injectable } from '@angular/core';

const uri = 'data:application/vnd.ms-excel;base64,';

class ExcelTemplate {
  private template: string = `
<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40">  
  <head>
    <!--[if gte mso 9]>
      <xml>
        <x:ExcelWorkbook>
          <x:ExcelWorksheets>
            <x:ExcelWorksheet>
              <x:Name>{worksheet}</x:Name>
              <x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions>
            </x:ExcelWorksheet>
          </x:ExcelWorksheets>
        </x:ExcelWorkbook>
      </xml>
    <![endif]-->
  <style>{style}</style>
  </head>
  <body>
    <table>{table}</table>
  </body>
</html>
`;
  style: string;
  table: string;
  name: string;
  constructor(table: Element, name: string = "Hoja1", style: string = null) {
    this.style = style ? style : '';
    this.table = this.matTableToTable(table.innerHTML);
    this.name = name;
  }

  private format = function (template: any, obj: any) { return template.replace(/{(\w+)}/g, function (m: any, p: any) { return obj[p]; }) };
  private changeString = function (template: string, obj: any) {
    return template
      .replace(/<(\w+)/g, function (m: any, p: any) { return '<' + obj[p]; })
      .replace(/<\/(\w+)/g, function (m: any, p: any) { return '</' + obj[p]; })
  }

  private matTableToTable(table: string): string {

    let tb = ((): HTMLTableElement => {
      let ret = document.createElement("table"), _tb = table;
      _tb = _tb.replace(new RegExp('<!---->', 'g'), "");
      _tb = _tb.replace(new RegExp('[-]', 'g'), '');
      _tb = this.changeString(_tb, { matheaderrow: 'tr', matheadercell: 'th', matrow: 'tr', matcell: 'td', span: 'span' });
      _tb = _tb.replace(new RegExp('<tr', 'g'), "\n\n<tr")
      _tb = _tb.replace(new RegExp('<th', 'g'), "\n\t<th")
      _tb = _tb.replace(new RegExp('<td', 'g'), "\n\t<td")
      _tb = _tb.replace(new RegExp('<span', 'g'), "\n\t\t<span")
      ret.innerHTML = _tb;
      return ret;
    })(),
      gtArr = (cls: string): Array<Element> => { return Array.prototype.slice.call(tb.getElementsByClassName(cls)) },
      arr: Array<Array<Element>> = [gtArr('matheadercell'), gtArr('matrow'), gtArr('matcell'), gtArr('matheaderrow')];

    arr.forEach(_arr => {
      _arr.forEach(_Ele => {
        _Ele.setAttribute('style', _Ele.classList.contains('dayheader') ?
          'mso-rotate:90;background: #81DAF5;' : (_Ele.classList.contains('hastextExcel') ?
            'mso-number-format:"\@";' : (_Ele.classList.contains('matheadercell') ?
              'background: #81DAF5;' : '')));               
        _Ele.setAttribute('class', '');
      })
    });
    console.log(tb)
    return tb.innerHTML;
  }
  ExportResult(): string {
    return this.format(this.template, { table: this.table, worksheet: this.name, style: this.style })
  }
}

@Injectable() export class ConverterService {

  toXls(table: Element, name: string): string {

    let tp = new ExcelTemplate(table, name, `.day-header{ mso-rotate:90; }`),
      base64 = (s: any) => { return window.btoa(decodeURI(decodeURIComponent(s))) };
    return uri + base64(tp.ExportResult());
  }


}