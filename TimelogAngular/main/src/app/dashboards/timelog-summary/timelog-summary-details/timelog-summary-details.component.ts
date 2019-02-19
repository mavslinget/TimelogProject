import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, Sort, MatSort } from '@angular/material';

@Component({
  selector: 'app-timelog-summary-details',
  templateUrl: './timelog-summary-details.component.html',
  styleUrls: ['./timelog-summary-details.component.scss']
})
export class TimelogSummaryDetailsComponent implements OnInit {
  displayedColumns = ['date', 'unreportedReason'];
  dataSource;

  constructor() { }

  ngOnInit() {
  }

}
