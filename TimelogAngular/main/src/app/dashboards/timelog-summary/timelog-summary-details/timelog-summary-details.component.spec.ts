import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimelogSummaryDetailsComponent } from './timelog-summary-details.component';

describe('TimelogSummaryDetailsComponent', () => {
  let component: TimelogSummaryDetailsComponent;
  let fixture: ComponentFixture<TimelogSummaryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimelogSummaryDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimelogSummaryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
