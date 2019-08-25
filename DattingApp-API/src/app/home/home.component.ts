import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }
  registerMode = false;
  ngOnInit() {
  }
  toggleRegister(){
    this.registerMode = !this.registerMode;
  }
  onCancel(value:boolean){
    debugger;
    console.log('Inside Parrent value ='+value)
    this.registerMode = value;
  }
}
