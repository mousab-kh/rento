import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IVehicleModel } from 'src/app/interface/IVehicleModel'

@Injectable({
  providedIn: 'root'
})
export class VehicleModelservice {

  constructor(private http: HttpClient) { }

  GetAll(id: number) : Observable<IVehicleModel[]> {
    return this.http.get<IVehicleModel[]>
      (`https://localhost:44358/Vehicle/VehicleCategorie/${id}/VehicleModel`)
  }

  Get(id: number,Modelid: number ): Observable<IVehicleModel> {
    return this.http.get<IVehicleModel>
      (`https://localhost:44358/Vehicle/VehicleCategorie/${id}/VehicleModel/${Modelid}`)
  }

  Create(VehicleModel: IVehicleModel): Observable<IVehicleModel> {
    return this.http.post<IVehicleModel>
      (`https://localhost:44358/Vehicle/VehicleCategorie/${VehicleModel.vehicleCategorieId}/VehicleModel`, VehicleModel)
  }

  Delete(VehicleModel: IVehicleModel): Observable<string> {
    return this.http.delete<string>
      (`https://localhost:44358/Vehicle/VehicleCategorie/${VehicleModel.vehicleCategorieId}/VehicleModel/${VehicleModel.id}`);
  }

    Update(VehicleModel: IVehicleModel): Observable<IVehicleModel>{
      return this.http.put<IVehicleModel>
      (`https://localhost:44358/Vehicle/VehicleCategorie/${VehicleModel.vehicleCategorieId}/VehicleModel`,VehicleModel)
    }
}
