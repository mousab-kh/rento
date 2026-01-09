import { Pipe, PipeTransform } from '@angular/core';

@Pipe
({     name: 'timeFormat' ,
        standalone: true 
})

export class TimeFormatPipe implements PipeTransform  {
    transform(value: string | number | Date): string {
        return toTimeString(value);
    }

    
}

export function toTimeString(datetime: string | number | Date): string {
  const date = new Date(datetime);
  const hours = String(date.getHours()).padStart(2, '0');
  const minutes = String(date.getMinutes()).padStart(2, '0');
  return `${hours}:${minutes}`;
}

