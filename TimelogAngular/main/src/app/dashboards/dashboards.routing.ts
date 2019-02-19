import { Routes } from '@angular/router';

import { Dashboard1Component } from './dashboard1/dashboard1.component';
import { Dashboard2Component } from './dashboard2/dashboard2.component';
import { TimelogSummaryComponent } from './timelog-summary/timelog-summary.component';
import { TimelogSummaryDetailsComponent } from './timelog-summary/timelog-summary-details/timelog-summary-details.component';


export const DashboardsRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'dashboard1',
        component: Dashboard1Component
      },
      {
        path: 'timelog-summary',
        component: TimelogSummaryComponent
      },
      {
        path: 'timelog-summary-details',
        component: TimelogSummaryDetailsComponent
      },
      {
        path: 'dashboard2',
        component: Dashboard2Component
      }
    ]
  }
];
