import { Component } from '@angular/core';
import { IVehicleCategorie } from 'src/app/interface/IVehicleVehicleCategorie';
import { VehicleCategorieService } from 'src/app/Service/vehicle-categorie-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgZone } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-vehicle-categorie',
  imports: [CommonModule, FormsModule],
  templateUrl: './vehicle-categorie.html',
  styleUrl: './vehicle-categorie.css'
})
export class VehicleCategorie {
  vehiclecategories: IVehicleCategorie[] = [];
  selectedCategory: IVehicleCategorie | null = null;
  categoryUpdateid: number | undefined;
  categorycreate:IVehicleCategorie| undefined;
  createMode: boolean = false;

  constructor(
    private vehiclecategoriesServ: VehicleCategorieService,
    private zone: NgZone,
    private router : Router ) {
  }

  ngOnInit(): void {
    this.vehiclecategoriesServ.GetAllVehicleCategorie().subscribe(
      (vehicles) => {
        this.vehiclecategories = vehicles;
      },
      (error) => { console.error('حدث خطأ:', error); }
    )

  }

  onRowSelect(category: IVehicleCategorie) {
    this.selectedCategory = category;
    this.router.navigate([`Vehicle/VehicleCategorie/${category.id}/VehicleModel`]);
  }

  onRowUpdate(category: IVehicleCategorie) {
    this.categoryUpdateid = category.id;
  }

 onRowSave(category: IVehicleCategorie) {
  this.vehiclecategoriesServ.UpdateVehicleCategorie(category).subscribe(
    () => {
      console.log("✅ تم الحفظ بنجاح");
    },
    (error) => {
      console.error("❌ خطأ في الحفظ", error);
    }
  );
  this.categoryUpdateid=undefined;
}


onRowCreate() {
  this.createMode = true;
  this.categorycreate = {
    id: this.vehiclecategories[this.vehiclecategories.length - 1].id+1,
    name: '',
    isActive: true
  };
}

Rowcreate(categorycreate: IVehicleCategorie) {
  this.vehiclecategoriesServ.CreateVehicleCategorie(categorycreate).subscribe({
    next: (createdCategory) => {
      this.vehiclecategories.push(createdCategory); // ✅ أضف العنصر الجديد للمصفوفة
      this.createMode = false;
      this.categorycreate = undefined;
      console.log("✅ تم إنشاء الفئة");
      setTimeout(() => {
      this.zone.run(() => {
      this.ngOnInit() //"✅ تم التحديث داخل NgZone";
    });
  }, 1000);
    },
    error: (err) => {
      console.error("❌ خطأ أثناء الإنشاء", err);
    }
  });
}

  onRowDelete(id: number) {
    this.vehiclecategoriesServ.DeleteVehicleCategorie(id).subscribe({
      next: () => {
        console.log("✅ تم الحذف بنجاح");
        // مثال: حذف العنصر من المصفوفة:
        this.vehiclecategories = this.vehiclecategories.filter(c => c.id !== id);
      },
      error: (err) => {
        console.error("❌ حدث خطأ أثناء الحذف:", err);
      },
      complete: () => {
        console.log("🟢 العملية انتهت.");
      }
    });
  }


}





