import { Component } from '@angular/core';
import { UserService } from '../user/user.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {   
    constructor(private user: UserService) {

    }
    logout() {
        this.user.logout();
    }
}
