import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { BranchesService } from '../../branches/Branches-Service/Branchesservice';
import { IBranches } from '../interface/IBranches';
import { FormsModule } from '@angular/forms'; // 👈 أضف هذا
import { Router } from '@angular/router';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './update.html',
  styleUrl: './update.css' ,
})
export class Update implements OnInit {
  public BranchUpdate! : IBranches;
  id!: number;

  constructor(
    private route: ActivatedRoute,
    private BranchesServ: BranchesService,
    private router : Router)  {}

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.BranchUpdate = this.BranchesServ.getBranch(this.id);
  }

  saveChanges(Branch: IBranches){
   this.BranchesServ.UpdateBranch(Branch);
   this.router.navigate(['/branches']);
  }
}