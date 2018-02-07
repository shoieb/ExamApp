import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';
import { UserService } from '../user/user.service';

@Component({
    selector: 'addemployee',
    templateUrl: './employee.add.component.html'
})

export class addemployeeComponent implements OnInit {

    employeeForm: FormGroup;
    title: string = "Create";
    id: string;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private employee: EmployeeService, private user: UserService, private _router: Router) {

        this.user.checkCredentials();

        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }
        this.employeeForm = this._fb.group({
            id: '00000000-0000-0000-0000-000000000000',
            name: ['', [Validators.required]],
            email: ['', [Validators.required]],
            attendance: ['', [Validators.required]],
            overTime: 0
        })
    }
    
    ngOnInit() {
        if (this.id.length > 0) {
            this.title = "Edit";
            this.employee.getEmployeeById(this.id)
                .subscribe(result => {
                    var data = result.json();
                    this.employeeForm.setValue({
                        id: this.id,
                        name: data.name,
                        email: data.email,
                        attendance: data.attendance,
                        overTime: data.overTime
                    });
                }, error => console.error(error));
        }
    }

    save() {
        if (!this.employeeForm.valid) {
            return;
        }

        this.employee.addOrUpdateEmployee(this.employeeForm.value).subscribe((data) => {
            this._router.navigate(['/employee']);
            }, error => console.error(error));
    }

    cancel() {
        this._router.navigate(['/employee']);
    }
    
    get name() { return this.employeeForm.get('name'); }
    get email() { return this.employeeForm.get('email'); }
    get attendance() { return this.employeeForm.get('attendance'); }
    get overTime() { return this.employeeForm.get('overTime'); }

}