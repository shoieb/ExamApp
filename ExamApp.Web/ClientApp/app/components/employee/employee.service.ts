import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class EmployeeService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }
    
    getEmployees() {
        return this.http.get(this.baseUrl + 'api/Employee/GetAll');
    }

    getEmployeeById(id) {
        return this.http.get(this.baseUrl + 'api/Employee/GetById/' + id);
    }

    addOrUpdateEmployee(employee) {
        return this.http.post(this.baseUrl + "api/Employee/InsertOrUpdate/", employee);
    }

    deleteEmployee(id) {
        return this.http.delete(this.baseUrl + "api/Employee/DeleteCourse/" + id);
    }

}

