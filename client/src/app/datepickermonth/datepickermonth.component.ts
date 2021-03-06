import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig, BsDatepickerViewMode } from 'ngx-bootstrap/datepicker';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-datepickermonth',
  templateUrl: './datepickermonth.component.html',
  styleUrls: ['./datepickermonth.component.css']
})
export class DatepickermonthComponent implements OnInit {

  @Output() selectedDate = new EventEmitter<Date>();
   obj = Date.now();
   formatDate: any;
   date1 = new Date(this.obj); // (2009, 10, 10);  // 2009-11-10
   month = this.date1.toLocaleString('default', { month: 'long' });
   datePickerValue: Date = new Date(this.obj);
  @Input() datePicker: Date = new Date(this.obj);
  dateRangePickerValue: Date[];
  range1: Date = new Date(2020, 5);
  range2: Date = new Date(2020, 8);
  minMode: BsDatepickerViewMode = 'month';

  colorTheme = 'theme-dark-blue';

  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private bsDatepickerConfig: BsDatepickerConfig, private datePipe: DatePipe) {
    this.bsDatepickerConfig.dateInputFormat = 'MMMM YYYY';
  }

  ngOnInit(): void {

    console.log(this.month);
    this.dateRangePickerValue = [this.range1, this.range2];
    this.bsConfig = Object.assign({}, {
      minMode : this.minMode,
      containerClass: this.colorTheme
    });
  }

  public onChange(date: Date) {
    // console.log(date);
    this.formatDate = this.datePipe.transform(date, 'yyyy-MM-dd');
    this.updateDate(this.formatDate);
  }

  updateDate(value: Date) {
    console.log(value);
    this.selectedDate.emit(value);
  }

}
