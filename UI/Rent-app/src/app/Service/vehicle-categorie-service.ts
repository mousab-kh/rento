import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IVehicleCategorie } from 'src/app/interface/IVehicleVehicleCategorie'

@Injectable({
  providedIn: 'root'
})
export class VehicleCategorieService {

  constructor(private http: HttpClient) { }

  GetAllVehicleCategorie(): Observable<IVehicleCategorie[]> {
    return this.http.get<IVehicleCategorie[]>(`https://localhost:44358/Vehicle/VehicleCategorie`);
  }

  GetVehicleCategorie(Categorieid: number): Observable<IVehicleCategorie> {
    return this.http.get<IVehicleCategorie>
    (`https://localhost:44358/Vehicle/VehicleCategorie/${Categorieid}`);
  }

  CreateVehicleCategorie(VehicleCategorie: IVehicleCategorie): Observable<IVehicleCategorie> {
    return this.http.post<IVehicleCategorie>
    (`https://localhost:44358/Vehicle/VehicleCategorie`, VehicleCategorie);
  }

  DeleteVehicleCategorie(Categorieid: number): Observable<IVehicleCategorie> {
    return this.http.delete<IVehicleCategorie>
    (`https://localhost:44358/Vehicle/VehicleCategorie/${Categorieid}`);
  }

  UpdateVehicleCategorie(VehicleCategorie: IVehicleCategorie): Observable<IVehicleCategorie> {
    return this.http.put<IVehicleCategorie>
    (`https://localhost:44358/Vehicle/VehicleCategorie`, VehicleCategorie);
  }


}
