import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { EmployeeService } from './employee.service';

@Component({
    selector: 'employee',
    templateUrl: './employee.component.html'
})
export class EmployeeComponent {
    public employees: Employee[];

    constructor(private employee: EmployeeService) {
        this.getEmployees();
    }

    getEmployees() {        
        this.employee.getEmployees().subscribe(result => {
            console.log(result.json());
            this.employees = result.json() as Employee[];
        }, error => console.error(error));
    }

    deleteEmployee(id) {
        var ans = confirm("Do you want to delete employee");
        if (ans) {
            this.employee.deleteEmployee(id).subscribe(result => {
                this.getEmployees();
            }, error => console.error(error));
        }
    }
}

interface Employee {
    id: string;
    name: string;
    email: string;
    attendance: string;
    overTime: number;
}
