import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any = {};
  constructor(private auth:AuthService) { }

  ngOnInit() {
  }
  login(){
    console.log(this.model);
    this.auth.login(this.model).subscribe(next => { console.log("login success")}, error => {console.log(error)});
    
  }
  loggedIn(){
    const token = localStorage.getItem('token');
    return !!token;
  }
  loggedOut(){
    localStorage.removeItem('token');
    console.log('Logged Out')
  }
}
