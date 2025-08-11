import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking',
  imports: [],
  templateUrl: './booking.html',
  styleUrl: './booking.css'
})
export class Booking {

  constructor(private router: Router) {}

  chooseBranch(){
    this.router.navigate(['Branch'])
  }
  chooseCar(){
    //this.router.navigate(['Vehicle/VehicleCategorie'])
    this.router.navigate(['Vehicle/VehicleCategorie'])
  }
  choosePayment(){}
}
