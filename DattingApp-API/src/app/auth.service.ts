import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/Http';
import {map} from 'rxjs/operators'
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl ="http://localhost:5000/api/auth/"
  constructor(private http:HttpClient) { }
  login(model:any)
   {
   return this.http.post(this.baseUrl+'login',model)
            .pipe(
              map((response:any)=>{
              const user = response;
              if(user)
              {
                 localStorage.setItem('token',user.token);
              }
            })
            );
  }
  register(model:any)
   {
     debugger;
   return this.http.post(this.baseUrl+'register',model)
            .pipe(
              map((response:any)=>{
              const user = response;
              console.log(user);
              if(user)
              {              
                 localStorage.setItem('token',user.token);
              }
            }) 
            );
  }
}
