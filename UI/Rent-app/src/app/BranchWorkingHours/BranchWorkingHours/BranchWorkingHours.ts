import { Component } from '@angular/core';
import { IBranchWorkingHours } from '../../interface/IBranchWorkingHours';
import { BranchWorkingHourService } from '../../Service/BranchWorkingHours-Service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {TimeFormatPipe} from 'src/app/pipes/time-format.pipe';
import {DateFormatPipe} from 'src/app/pipes/date-format.pipe';
import {NumberimeFormatPipe} from 'src/app/pipes/numbertime-format.pipe';
import { IWorkingHourInterval } from '../../interface/IWorkingHourInterval';

@Component({
  selector: 'BranchWorkingHours',
  imports: [
    CommonModule,
    FormsModule,
    TimeFormatPipe,
    DateFormatPipe,
    NumberimeFormatPipe],
  standalone: true, // ✅ تأكد أنها ستاندالون
  templateUrl: './BranchWorkingHours.html',
  styleUrl: './BranchWorkingHours.css'
})
export class BranchWorkingHours {
 BranchWorkingHoursObserve!: Observable<IBranchWorkingHours[]>; // ✅ الحقل
 BranchWorkingHours: IBranchWorkingHours[] = [];
 branchid!: number;


  constructor(
    private branchWorkingHourService$: BranchWorkingHourService,
    private router: Router,
    private route: ActivatedRoute) {} // ✅ الكونستركتر

  ngOnInit(): void {
    this.GetAllBranchWorkingHour(); 
    this.BranchWorkingHoursObserve.subscribe(data=>{
    this.BranchWorkingHours=data;
    })
  }

 GetAllBranchWorkingHour() {
    this.branchid=Number(this.route.snapshot.paramMap.get('branchid'));
    this.BranchWorkingHoursObserve=
    this.branchWorkingHourService$.GetAllBranchWorkingHourService(this.branchid);
      // 🔍 لمراقبة البيانات في DevTools:
  this.BranchWorkingHoursObserve.subscribe(data => {
    console.log('📦 البيانات المستلمة من السيرفيس:', data);
  });
  }

  onSaveAll(){

  console.log('📦 جميع بيانات الفروع:', this.BranchWorkingHours);
  // مثال: طباعة كل فرع وكل فتراته


    this.branchWorkingHourService$.SaveAll(this.BranchWorkingHours);
  }



  onEditBranch(id:number){
   this.router.navigate(
    [`Branch/${this.branchid}/BranchWorkingHour/${id}/edit/`]
  )}

onstartDateChange(newValue: string, branchWorkingHour: IBranchWorkingHours) {
  // هنا تحدث القيمة الأصلية بصيغة تناسب السيرفر أو الاستخدام اللاحق
   branchWorkingHour.startTime = this.updateDate(
    branchWorkingHour.startTime,newValue);
  // ممكن تضيف هنا منطق إرسال التحديث للسيرفر لو تحتاج
}

onendDateChange(newValue: string, branchWorkingHour: IBranchWorkingHours) {
  // هنا تحدث القيمة الأصلية بصيغة تناسب السيرفر أو الاستخدام اللاحق
   branchWorkingHour.endTime=this.updateDate(
    branchWorkingHour.endTime,newValue);
}
updateDate(originalDateTime: Date | string, newDateStr: string): Date {
  // تأكد من أن originalDateTime هو كائن Date
  const baseDate = new Date(originalDateTime);

  if (isNaN(baseDate.getTime())) {
    console.error("originalDateTime غير صالح:", originalDateTime);
    throw new Error("تاريخ غير صالح في updateDate");
  }

  const [year, month, day] = newDateStr.split('-').map(Number);
  const hours = baseDate.getHours();
  const minutes = baseDate.getMinutes();

  // إنشاء كائن Date جديد مع التاريخ الجديد والوقت من baseDate
  return new Date(year, month - 1, day, hours, minutes);
}

onstartTimeChange(newValue: string , branchWorkingHour: IBranchWorkingHours) {
  
  // هنا تحدث القيمة الأصلية بصيغة تناسب السيرفر أو الاستخدام اللاحق
  branchWorkingHour.startTime = this.updateTime(
    branchWorkingHour.startTime,newValue);
  // ممكن تضيف هنا منطق إرسال التحديث للسيرفر لو تحتاج
}
  
updateTime(originalDate: Date | string, newTimeStr: string): Date {
  // تأكد من أن originalDate هو كائن Date
  const baseDate = new Date(originalDate);

  if (isNaN(baseDate.getTime())) {
    console.error("originalDate غير صالح:", originalDate);
    throw new Error("تاريخ غير صالح في updateTime");
  }

  const year = baseDate.getFullYear();
  const month = baseDate.getMonth(); // يبدأ من 0 في JavaScript
  const day = baseDate.getDate();

  const [hours, minutes] = newTimeStr.split(':').map(Number);

  return new Date(year, month, day, hours, minutes);
}

onendTimeChange(newValue: string, branchWorkingHour: IBranchWorkingHours) {
  
  // هنا تحدث القيمة الأصلية بصيغة تناسب السيرفر أو الاستخدام اللاحق
  branchWorkingHour.endTime=this.updateTime(
    branchWorkingHour.endTime,newValue);
}



onintervalstartChange(newValue: string, intervals: IWorkingHourInterval) {
  // هنا تحدث القيمة الأصلية بصيغة تناسب السيرفر أو الاستخدام اللاحق
   intervals.start=this.timeStringToDecimal(newValue);
}

onintervalendChange(newValue: string, intervals: IWorkingHourInterval) {
intervals.end=this.timeStringToDecimal(newValue);
}

timeStringToDecimal(timeStr: string): number {
  const [hoursStr, minutesStr] = timeStr.split(':');
  const hours = parseInt(hoursStr, 10);
  const minutes = parseInt(minutesStr, 10);

  const decimalHours = hours + minutes / 60;
  return Math.round(decimalHours); // تقريب لأقرب عدد صحيح
}

}

