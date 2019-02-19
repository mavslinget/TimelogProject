import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, Sort, MatSort } from '@angular/material';
import { TimelogSummaryDetailsComponent } from './timelog-summary-details/timelog-summary-details.component';


@Component({
  selector: 'app-timelog-summary',
  templateUrl: './timelog-summary.component.html',
  styleUrls: ['./timelog-summary.component.scss']
})
export class TimelogSummaryComponent implements OnInit {
  today: Date = new Date();
  displayedColumns = ['name', 'hoursRendered', 'unreportedHours', 'department'];
  dataSource;


  constructor(public dialog: MatDialog, private router: Router
  ) {
    setInterval(() => {
      this.today = new Date();
    }, 1);
   }

  ngOnInit() {
  }

  timelogDialog(): void {

    const dialogRef = this.dialog.open(TimelogSummaryDetailsComponent, {
      width: '500px',

    });

    dialogRef.afterClosed().subscribe(result => {

      this.router.navigate(['/dashboards/timelog-summary']);
    });

  }

}
