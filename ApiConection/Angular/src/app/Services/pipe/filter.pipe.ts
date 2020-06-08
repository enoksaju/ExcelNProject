import {
  Injector,
  Pipe,
  PipeTransform
} from '@angular/core';
@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  public constructor(private readonly injector: Injector) {
  }

  transform(items: any[], callback: (item: any) => boolean): any {
    if (!items || !callback) {
      return items;
    }
    return items.filter(item => callback(item));
  }
  // transform(items: any, filter: any): any {
  //   if (filter && Array.isArray(items)) {
  //       let filterKeys = Object.keys(filter);
  //       return items.filter(item =>
  //           filterKeys.reduce((memo, keyName) =>
  //               (memo && new RegExp(filter[keyName], 'gi').test(item[keyName])) || filter[keyName] === "", true));
  //   } else {
  //       return items;
  //   }
  // }

}
