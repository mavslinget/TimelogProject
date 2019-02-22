import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Department } from "../domain/department";

@Injectable()
export class DepartmentService {
    constructor(private http: HttpClient) {} 

    getDepartment() {
        return this.http.get("https://localhost:5001/api/Department")
            .toPromise()
            .then(data => { return data as Department[] })
    }

    getDepartmentInfo(id) {
        return this.http.get("https://localhost:5001/api/Department/" + id)
            .toPromise()
            .then(data => { return data as Department })
    }

    addDepartment(objEntity: Department) {
        return this.http.post("https://localhost:5001/api/Department/", objEntity)
            .toPromise()
            .then(data => { return data as Department })
    }

    editDepartment(id, objEntity: Department) {
        return this.http.put("https://localhost:5001/api/Department/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Department })
    }

    deleteEmployee(id) {
        return this.http.delete("https://localhost:5001/api/Department/" + id)
            .toPromise()
            .then(() => null);
    }
}