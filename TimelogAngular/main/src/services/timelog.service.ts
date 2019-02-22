import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Timelog } from "../domain/timelog";

@Injectable()
export class TimelogService {
    constructor(private http: HttpClient) {} 

    getTimelog() {
        return this.http.get("https://localhost:5001/api/Timelog")
            .toPromise()
            .then(data => { return data as Timelog[] })
    }

    getTimelogInfo(id) {
        return this.http.get("https://localhost:5001/api/Timelog/" + id)
            .toPromise()
            .then(data => { return data as Timelog })
    }

    addTimelog(objEntity: Timelog) {
        return this.http.post("https://localhost:5001/api/Timelog/", objEntity)
            .toPromise()
            .then(data => { return data as Timelog })
    }

    editTimelog(id, objEntity: Timelog) {
        return this.http.put("https://localhost:5001/api/Timelog/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Timelog })
    }

    deleteTimelog(id) {
        return this.http.delete("https://localhost:5001/api/Timelog/" + id)
            .toPromise()
            .then(() => null);
    }
}