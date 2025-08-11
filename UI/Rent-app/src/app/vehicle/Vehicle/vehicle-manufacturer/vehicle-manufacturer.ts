import { Component, NgZone } from '@angular/core';
import { VehicleManufacturerService } from 'src/app/Service/vehicle-manufacturer-service'
import { IVehicleManufacturer } from 'src/app/interface/IVehicleManufacturer'
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-vehicle-manufacturer',
  imports: [CommonModule, FormsModule],
  templateUrl: './vehicle-manufacturer.html',
  styleUrl: './vehicle-manufacturer.css'
})

export class VehicleManufacturer {
  VehicleManufacturer: IVehicleManufacturer[] = [];
  UpdateVehicleManufacturerid: number | undefined;
  iscreateManufacturer: boolean = false;
  vehicleCreateManufacturer: IVehicleManufacturer | undefined;

  constructor(
    private VehicleManufacturerServ: VehicleManufacturerService,
    private zone: NgZone) { }

  saveManufacturer(Manufacturer: IVehicleManufacturer) {
    this.VehicleManufacturerServ.Update(Manufacturer).subscribe({
      next: () => {
        this.UpdateVehicleManufacturerid = undefined;
        this.ngOnInit();
      },
      error: (err) => { console.error('حدث خطا', err) },
    })
  }

  OnCreateManufacturer() {
    this.iscreateManufacturer = true;
    const lastId = this.VehicleManufacturer.length > 0
      ? this.VehicleManufacturer[this.VehicleManufacturer.length - 1].id
      : 0;
    this.vehicleCreateManufacturer = {
      id: lastId + 1,
      name: '',
      isActive: true
    };
  }

  saveCreateManufacturer(Manufacturer: IVehicleManufacturer) {
    this.VehicleManufacturerServ.Create(Manufacturer).subscribe({
      next: () => {
        this.iscreateManufacturer = false;
        this.zone.run(
          () => { this.ngOnInit(); })
      },
      error: (err) => {
        { console.error('حدث خطا', err) }
      },
    })
  }

  deleteManufacturer(Manufacturerid: number) {
    this.VehicleManufacturerServ.Delete(Manufacturerid).subscribe({
      next: (value: string) => {
        console.log('تم الحذف', value);
        this.zone.run(() => {
          this.ngOnInit();
        })
      },
      error: (err) => { console.error(' حدث خطا في الحذف', err) }
    })
  }

  UpdateVehicleManufacturer(Manufacturer: IVehicleManufacturer) {
    this.UpdateVehicleManufacturerid = Manufacturer.id;
  }
  
  ngOnInit(): void {
    this.VehicleManufacturerServ.GetAll().subscribe(
      (Manufacturer) => {
        this.VehicleManufacturer = Manufacturer;
      },
      (error) => { console.error('حدث خطا', error) }
    )
  }

}
