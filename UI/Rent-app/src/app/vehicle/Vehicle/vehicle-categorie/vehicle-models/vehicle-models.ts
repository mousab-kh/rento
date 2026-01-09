import { Component } from '@angular/core';
import { IVehicleModel } from 'src/app/interface/IVehicleModel'
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VehicleModelservice } from 'src/app/Service/vehicle-models-service'
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vehicle-models',
  imports: [CommonModule, FormsModule],
  templateUrl: './vehicle-models.html',
  styleUrl: './vehicle-models.css'
})
export class VehicleModels {
  VehicleModels: IVehicleModel[] = [];
  updateVehicleModelsid: number | undefined;
  iscreateVehicleModel: boolean = false;
  createVehicleModel: IVehicleModel | undefined;

  constructor(
    private VehicleModelserv: VehicleModelservice,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    const categoryId = this.route.snapshot.paramMap.get('id');
    this.VehicleModelserv.GetAll(Number(categoryId)).subscribe({
      next: (value) => { this.VehicleModels = value; },
      error: (err) => { console.error('خطا' + err) }
    })
  }

  editModel(VehicleModel:IVehicleModel){
   this.updateVehicleModelsid=VehicleModel.id;
  }

  deleteModel(VehicleModel :IVehicleModel) {
    this.VehicleModelserv.Delete(VehicleModel).subscribe({
      next: ()=>{console.log('تم الحذف')},
      error: (err)=>{console.error('خطا' + err) }
     
  })
       this.VehicleModels.length
  }

  updateVehicleModel(VehicleModel : IVehicleModel){
    this.VehicleModelserv.Update(VehicleModel).subscribe({
      next: ()=>{
        this.updateVehicleModelsid=undefined;
      },
      error: (err)=>{console.error('خطا' + err) }
    })
  }

}
