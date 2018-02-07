import { Component } from '@angular/core';
import { UserService } from '../user/user.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private user: UserService) {

    }

    isLoggedIn = this.user.isLoggedIn();
}
