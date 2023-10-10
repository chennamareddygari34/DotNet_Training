import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value:any ,filter:string){

    if(value.length==0||filter==''){

      return value;

    }

    const products=[];

    for(const product of value){

      if(product['name']==filter){

        products.push(product);

      }

    }

    return products;

  }
}
