import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, Sort, MatSort } from '@angular/material';
import { Department } from '../../../../domain/department';
import { DepartmentService } from '../../../../services/department.service';
import { EmployeeService } from '../../../../services/employee.service';
import { Employee } from '../../../../domain/employee';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';



@Component({
  selector: 'app-timelog-summary-details',
  templateUrl: './timelog-summary-details.component.html',
  styleUrls: ['./timelog-summary-details.component.scss'],
  providers: [EmployeeService, DepartmentService]
})
export class TimelogSummaryDetailsComponent implements OnInit {
  displayedColumns = ['date', 'unreportedReason'];
  dataSource;
  selectDepartment: Department;
  departmentList: Department[];
  employeeList: Employee[];
  selectEmployee: Employee;
  searchEmployee: string = "";
  employeeID: number;
  departmentID: number;



  constructor(private fb: FormBuilder, public dialog: MatDialog, private router: Router,
    private departmentService: DepartmentService, private employeeService: EmployeeService) { }

  ngOnInit() {
    this.loadAllEmployees();
  }

  loadAllEmployees() {
    this.selectEmployee = {} as Employee;
    this.selectDepartment = {} as Department;
    this.employeeService.getEmployee().then(employees => {
      this.employeeList = employees;
      this.departmentService.getDepartment().then(departments => {
        this.departmentList = departments;
        for (var i = 0; i < this.employeeList.length; i++) {
          this.employeeList[i].departmentName = this.departmentList.find(x => x.departmentID == this.employeeList[i].departmentID).departmentName;
        }

      });
      this.dataSource = new MatTableDataSource<Employee>(this.employeeList);
      // this.dataSource.paginator = this.paginator;
    });
  }

}
