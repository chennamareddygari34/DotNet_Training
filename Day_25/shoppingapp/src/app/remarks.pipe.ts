import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'remarks'
})
export class RemarksPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return (value as string).substring(0,10)+"...";
  }

}
