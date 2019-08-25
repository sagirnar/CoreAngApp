import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model:any = {}

 @Output() registerCancel = new EventEmitter<boolean>();
  constructor(private auth:AuthService) { }

  ngOnInit()
  {
    
  }

  register()
  {
    console.log(this.model)
    this.auth.register(this.model).subscribe(
      next => {console.log('user is created ')},errResponse => {        
        console.log(errResponse)}
    );
  }

  cancel()
  {   
    this.registerCancel.emit(false);
  }

}
