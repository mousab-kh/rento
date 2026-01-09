import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {IBranchWorkingHours} from 'src/app/interface/IBranchWorkingHours'
@Injectable({
  providedIn: 'root'
})
export class BranchWorkingHourService {
  

    constructor(private http: HttpClient) { }

GetAllBranchWorkingHourService(branchid:number) : Observable<IBranchWorkingHours[]> {
return this.http.get<IBranchWorkingHours[]>
(`https://localhost:44358/Branch/${branchid}/BranchWorkingHour`);
}

GetBranchWorkingHourService(branchid:number, Id :number ) : Observable<IBranchWorkingHours[]> {
return this.http.get<IBranchWorkingHours[]>
(`https://localhost:44358/Branch/${branchid}/BranchWorkingHour/${Id}`);
}

CreateBranchWorkingHourService(BranchWorkingHours:IBranchWorkingHours){
  this.http.post
  (`https://localhost:44358/Branch/${BranchWorkingHours.branchId}/BranchWorkingHour/`
    ,BranchWorkingHours).subscribe();
}

UpdateBranchWorkingHourService(branch: IBranchWorkingHours): Observable<any> {
  return this.http.put(
    `https://localhost:44358/Branch/${branch.branchId}/BranchWorkingHour/`,
    branch
  );
}

DeleteBranchWorkingHourService(branchid:number, Id :number ) {
  this.http.delete
  (`https://localhost:44358/Branch/${branchid}/BranchWorkingHour/${Id}`).subscribe();
}

SaveAll(branchWorkingHours: IBranchWorkingHours[]) {
    branchWorkingHours.forEach(branchWorkingHour => {
      this.UpdateBranchWorkingHourService(branchWorkingHour).subscribe({
        next: () => console.log(`✅ تم تحديث الفرع ID: ${branchWorkingHour.id}`),
        error: err => console.error(`❌ خطأ في تحديث الفرع ID ${branchWorkingHour.id}:`, err)
      });
    });
 
}

}
