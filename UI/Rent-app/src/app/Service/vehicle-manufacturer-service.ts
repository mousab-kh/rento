import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IVehicleManufacturer } from 'src/app/interface/IVehicleManufacturer';


@Injectable({
  providedIn: 'root'
})
export class VehicleManufacturerService {

  constructor(private http: HttpClient) { }

  GetAll(): Observable<IVehicleManufacturer[]> {
    return this.http.get<IVehicleManufacturer[]>
      (`https://localhost:44358/Vehicle/VehicleManufacturer`);
  }

  Get(id: number): Observable<IVehicleManufacturer> {
    return this.http.get<IVehicleManufacturer>
      (`https://localhost:44358/Vehicle/VehicleManufacturer/${id}`);
  }

  Create(VehicleManufacturer: IVehicleManufacturer): Observable<IVehicleManufacturer> {
    return this.http.post<IVehicleManufacturer>
      (`https://localhost:44358/Vehicle/VehicleManufacturer`, VehicleManufacturer);
  }

  Delete(id: number): Observable<string>{
    return this.http.delete<string>
    (`https://localhost:44358/Vehicle/VehicleManufacturer/${id}`);
  }

  Update(VehicleManufacturer: IVehicleManufacturer): Observable<IVehicleManufacturer>{
    return this.http.put<IVehicleManufacturer>
    ('https://localhost:44358/Vehicle/VehicleManufacturer',VehicleManufacturer)
  }

}
