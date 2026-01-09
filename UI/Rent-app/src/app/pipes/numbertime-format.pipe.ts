import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name:'numberTimeFormat',
    standalone: true 
})

export class NumberimeFormatPipe  implements PipeTransform {
    transform(value: number) {
       return convertHourToTimeString(value);
    }
    
}

export function convertHourToTimeString(hour: number): string {
  const hourStr = hour.toString().padStart(2, '0');
  return `${hourStr}:00`;
}