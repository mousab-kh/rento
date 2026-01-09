import { Routes } from '@angular/router';
import { Update } from './branches/update/update';
import { Branches } from './branches/Branches/branches';
import { Create } from './branches/create/create';
import { BranchWorkingHours } from './BranchWorkingHours/BranchWorkingHours/BranchWorkingHours';
import { Booking } from 'src/app/booking/booking'
import { Vehicle } from 'src/app/vehicle/Vehicle/vehicle'
import { VehicleCategorie } from './vehicle/Vehicle/vehicle-categorie/vehicle-categorie';
import { VehicleManufacturer } from './vehicle/Vehicle/vehicle-manufacturer/vehicle-manufacturer';
import { VehicleModels } from './vehicle/Vehicle/vehicle-categorie/vehicle-models/vehicle-models';

export const routes: Routes = [
    { path: '', redirectTo: 'booking', pathMatch: 'full' },
    { path: 'Branch/:id/edit', component: Update },
    { path: 'Branch', component: Branches },
    { path: 'Branch/Create', component: Create },
    { path: 'Branch/:branchid/BranchWorkingHour', component: BranchWorkingHours },
    { path: 'booking', component: Booking },
    { path: 'Vehicle', component: Vehicle },
    { path: 'Vehicle/VehicleCategorie', component: VehicleCategorie },
    { path: 'Vehicle/VehicleManufacturer', component: VehicleManufacturer },
    { path: 'Vehicle/VehicleCategorie/:id/VehicleModel', component: VehicleModels }
];
