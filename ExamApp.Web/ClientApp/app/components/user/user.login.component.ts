import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UserService } from './user.service';
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './user.login.component.html'
})
export class userLoginComponent {
    loginForm: FormGroup;

    constructor(private _fb: FormBuilder, private user: UserService, private _router: Router) {
        if (this.user.isLoggedIn()) {
            this._router.navigate(['/employee']);
        }
        this.loginForm = this._fb.group({
            userName: ['', [Validators.required]],
            password: ['', [Validators.required]]
        })
    }
    login() {
        if (!this.loginForm.valid) {
            return;
        }
        this.user.getUser(this.loginForm.value).subscribe(result => {
            if ((typeof window !== "undefined")) {
                localStorage.setItem("user", JSON.stringify(result.json()));
            }            
            this._router.navigate(['/employee']);
        }, error => {
            alert("User not found!");
        });
    }
}