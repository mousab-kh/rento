import { Injectable } from '@angular/core';
import { IBranches } from '../interface/IBranches'
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class BranchesService {

  private _branchesSubject = new BehaviorSubject<IBranches[]>([]);
  public _branches: Observable<IBranches[]> = this._branchesSubject.asObservable();

  constructor(private http: HttpClient) { }

  loadBranches() {
    this.http.get<IBranches[]>('https://localhost:44358/Branch')
      .subscribe(branches => {
        this._branchesSubject.next(branches);
      }
      )
  }

  getBranch(id :number ) : IBranches {
    return this._branchesSubject.getValue().find(branch=>branch.id===id)!
  }

  UpdateBranch(branche: IBranches){
   this.http.put<IBranches>('https://localhost:44358/Branch',branche).subscribe();
  }

  CreateBranch(branche: IBranches){
    this.http.post<IBranches>('https://localhost:44358/Branch',branche).subscribe();
  }

  DeleteBranch(id :number): Observable<any>{
    return this.http.delete(`https://localhost:44358/Branch/${id}`);
  }
}
