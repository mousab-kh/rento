import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchesService } from '../Branches-Service/Branchesservice';
import { IBranches } from '../interface/IBranches';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create',
  imports: [FormsModule],
  templateUrl: './create.html',
  styleUrl: './create.css'
})
export class Create {
  public createBranches!: IBranches;


  constructor(
    private BranchesServ: BranchesService,
    private router : Router)  {
    this.createBranches = {
        id: 0,
        name: '',
        coordinatesLatitude: 0,
        coordinatesLongitude: 0,
        isActive: true
      };
    }

    createBranch(Branch: IBranches){
      this.BranchesServ.CreateBranch(Branch);
      this.router.navigate(['/branches'])
    }
}
