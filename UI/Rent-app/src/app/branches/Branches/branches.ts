import { Component, OnInit } from '@angular/core';
import { BranchesService } from '../Branches-Service/Branchesservice';
import { CommonModule } from '@angular/common';
import { IBranches } from '../interface/IBranches';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-branches',
  standalone: true, // ✅ مهم جدًا
  imports: [CommonModule],
  templateUrl: './branches.html',
  styleUrl: './branches.css'
})
export class Branches implements OnInit {

  branches$!: Observable<IBranches[]>;

  constructor(
    private BranchesServ: BranchesService,
    private router: Router) { }


ngOnInit(): void {
  this.BranchesServ.loadBranches();
  this.branches$ = this.BranchesServ._branches;
}


  goToUpdatePage(id: number): void {
    this.router.navigate([`Branch/${id}/edit`]);
  }

  goTocreatePage() {
    this.router.navigate(['Branch/Create']);
  }


Deletebranch(branchid: number): void {
  this.BranchesServ.DeleteBranch(branchid).subscribe({
    next: () => {
      console.log('🗑️ تم الحذف بنجاح للفرع:', branchid);
      this.BranchesServ.loadBranches(); // فقط أعد التحميل
    },
    error: err => {
      console.error('❌ خطأ أثناء الحذف:', err);
    }
  });
}

goToBranchWorkingHoursPage(branchid: number){
this.router.navigate([`Branch/${branchid}/BranchWorkingHour/`]);
}

}
