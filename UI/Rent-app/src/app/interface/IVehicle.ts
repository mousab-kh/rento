import { FuelType } from "./enumFuelType"


export interface IVehicle {
  id: number;
  vehicleModelId: number;
  year: number;
  vehicleManufacturerId: number;
  licensePlateNumber: string;
  fuelTypes: FuelType;
  branchId: number;
}

