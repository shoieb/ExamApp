import { Component, Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

@Injectable()
export class UserService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private _router: Router) { }
    
    getUser(user) {
        return this.http.post(this.baseUrl + 'api/User/GetUser/', user);
    }

    logout() {
        if ((typeof window !== "undefined")) {
            localStorage.removeItem("user");
            this._router.navigate(['/login']);
        }        
    }
    
    isLoggedIn() {
        if ((typeof window !== "undefined")) {
            if (localStorage.getItem("user") !== null) {
                return true;
            }
        }        
        return false;
    }

    isManager() {
        if ((typeof window !== "undefined")) {
            var user = localStorage.getItem("user");
            if (user !== null) {
                var manager = JSON.parse(user).role;
                if (manager === "manager") {
                    return true;
                }
            }
        }
        return false;
    }

    checkCredentials() {
        if ((typeof window !== "undefined")) {
            if (localStorage.getItem("user") === null) {
                this._router.navigate(['/login']);
            }
        }         
    }
}

