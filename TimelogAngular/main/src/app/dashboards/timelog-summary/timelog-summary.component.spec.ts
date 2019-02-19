import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimelogSummaryComponent } from './timelog-summary.component';

describe('TimelogSummaryComponent', () => {
  let component: TimelogSummaryComponent;
  let fixture: ComponentFixture<TimelogSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimelogSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimelogSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
