import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatepickermonthComponent } from './datepickermonth.component';

describe('DatepickermonthComponent', () => {
  let component: DatepickermonthComponent;
  let fixture: ComponentFixture<DatepickermonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatepickermonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatepickermonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
