import { Pipe, PipeTransform } from '@angular/core';

@Pipe
({     name: 'dateFormat' ,
        standalone: true 
})

export class DateFormatPipe implements PipeTransform  {
    transform(value: string | number | Date): string {
        return toDateString(value);
    }


}


export function toDateString(datetime: string | number | Date): string {
  const date = new Date(datetime);
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0'); // +1 لأن الشهور تبدأ من 0
  const day = String(date.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

