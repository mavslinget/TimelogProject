import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, Sort, MatSort } from '@angular/material';
import { TimelogSummaryDetailsComponent } from './timelog-summary-details/timelog-summary-details.component';
import { DatePipe } from '@angular/common';
import { Timelog } from "../../../domain/timelog";
import { TimelogService } from "../../../services/timelog.service";
import { Department } from "../../../domain/department";
import { Employee } from "../../../domain/employee";
import { EmployeeService } from "../../../services/employee.service";
import { DepartmentService } from "../../../services/department.service";




@Component({
  selector: 'app-timelog-summary',
  templateUrl: './timelog-summary.component.html',
  styleUrls: ['./timelog-summary.component.scss'],
  providers: [TimelogService,
    EmployeeService,
    DepartmentService,
     DatePipe]
})
export class TimelogSummaryComponent implements OnInit {
  today: Date = new Date();
  displayedColumns = ['name', 'hoursRendered', 'unreportedHours', 'department'];
  dataSource;
  timelogList: Timelog[];
  employeeList: Employee[];
  departmentList: Department[];
  // lastName: string;
  time: any;
  firstName: string;
  state: string;
  departmentName: string;
    

  constructor(private timelogService: TimelogService,
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    public dialog: MatDialog, private router: Router
  ) {
    setInterval(() => {
      this.today = new Date();
    }, 1);
   }

   ngOnInit() {
    this.loadAllTimelog();
  }

  timelogDialog(): void {

    const dialogRef = this.dialog.open(TimelogSummaryDetailsComponent, {
      width: '500px',

    });

    dialogRef.afterClosed().subscribe(result => {

      this.router.navigate(['/dashboards/timelog-summary']);
    });

  }

  loadAllTimelog() {
    this.timelogService.getTimelog().then(timelog => {
      this.timelogList = timelog;
      let tmpTimelogList = [...this.timelogList];
      this.dataSource = new MatTableDataSource<Timelog>(this.timelogList);
      // this.dataSource.paginator = this.paginator;
      // this.dataSource.sort = this.sort;
    });

    // this.employeeService.getEmployee().then(employee => {
    //   this.employeeList = employee;
    //   let tmpEmployeeList = [...this.employeeList];
    //   this.dataSource = new MatTableDataSource<Employee>(this.employeeList);
    // //   this.dataSource.paginator = this.paginator;
    // //   this.dataSource.sort = this.sort;
    // });

    // this.departmentService.getDepartment().then(department => {
    //   this.departmentList = department;
    //   let tmpDepartmentList = [...this.departmentList];
    //   this.dataSource = new MatTableDataSource<Department>(this.departmentList);
    //   // this.dataSource.paginator = this.paginator;
    //   // this.dataSource.sort = this.sort;
    // });

  }
}
