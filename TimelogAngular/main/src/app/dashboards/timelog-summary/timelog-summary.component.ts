import { Component, OnInit, ViewChild, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, Sort, MatSort, MatPaginator } from '@angular/material';
import { TimelogSummaryDetailsComponent } from './timelog-summary-details/timelog-summary-details.component';
import { Department } from '../../../domain/department';
import { DepartmentService } from '../../../services/department.service';
import { EmployeeService } from '../../../services/employee.service';
import { Employee } from '../../../domain/employee';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';




@Component({
  selector: 'app-timelog-summary',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './timelog-summary.component.html',
  styleUrls: ['./timelog-summary.component.scss'],
  providers: [DepartmentService, EmployeeService]
})

export class TimelogSummaryComponent implements OnInit {
  today: Date = new Date();
  displayedColumns = ['name', 'hoursRendered', 'unreportedHours', 'department'];
  dataSource;
  totalRecords: number = 0;
  selectDepartment: Department;
  departmentList: Department[];
  employeeList: Employee[];
  selectEmployee: Employee;
  searchEmployee: string = "";
  indexOfEmployee: number = 0;
  indexOfDepartment: number = 0;
  employeeLogsForm: FormGroup;
  employeeID: number;

  constructor(private fb: FormBuilder, public dialog: MatDialog, private router: Router,
    private route: ActivatedRoute,
    private departmentService: DepartmentService, private employeeService: EmployeeService) {
    setInterval(() => {
      this.today = new Date();
    }, 1);
  }
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    // this.employeeLogsForm = this.fb.group({
    //   'departmentName': new FormControl(''),
    //   'fullName': new FormControl('')
    // });
    const id = +this.route.snapshot.paramMap.get('id');
    this.getEmployee();
    

    this.loadAllEmployees();
  }

  populate(): void {
    this.employeeLogsForm.setValue({
      lastName: '',
      firstName: '',
      middleName: '',
      departmentName: '',

    })
  }

  getEmployee() {
    this.employeeService.getEmployeeInfo(this.employeeID).then(
      x => {
        this.employeeLogsForm.setValue({
          lastName: x.lastName,
          firstName: x.firstName,
          middleName: x.middleName,
          departmentName: x.departmentName
        })
      }
    )
  }

  timelogDialog(id): void {

    const dialogRef = this.dialog.open(TimelogSummaryDetailsComponent, {
      width: '500px',
    });
    let instance = dialogRef.componentInstance;
    let tmpEmployeeList = [...this.employeeList];
    // let tmpDepartmentList = [...this.departmentList];
    instance.employeeID = id;

    dialogRef.afterClosed().subscribe(result => {
      this.loadAllEmployees();
      this.router.navigate(['/dashboards/timelog-summary']);
    });

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
      this.dataSource.paginator = this.paginator;
    });
  }

  applyFilter(filterValue: string) {

    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  paginate($event) {
    this.employeeService.getEmployeewithPagination($event.first, $event.rows, this.searchEmployee).then(result => {
      this.totalRecords = result.totalRecords;
      this.employeeList = result.results;
      console.log(this.totalRecords);
    })
  }

  searchEmployeeLogs() {
    if (this.searchEmployee.length != 1) {
      this.loadAllEmployees();
    }
  }

  public convertToPDF() {
    var data = document.getElementById('contentToConvert');
    html2canvas(data).then(canvas => {
      // Few necessary setting options  
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth / canvas.width;
      var heightLeft = imgHeight;

      const contentDataURL = canvas.toDataURL('image/png', 1.0)
      let pdf = new jspdf('p', 'mm', 'a4'); // A4 size page of PDF  
      // let pdf = new jspdf('p', 'pt', [canvas.width, canvas.height]); // A4 size page of PDF  
      var position = 0;
      pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight);
      pdf.save('timelogs.pdf'); // Generated PDF   
    });
  }


}