import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig, BsDatepickerViewMode } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-datepickermonth',
  templateUrl: './datepickermonth.component.html',
  styleUrls: ['./datepickermonth.component.css']
})
export class DatepickermonthComponent implements OnInit {

   obj = Date.now();
   date1 = new Date(this.obj); // (2009, 10, 10);  // 2009-11-10
   month = this.date1.toLocaleString('default', { month: 'long' });
  datePickerValue: Date = new Date(this.obj);
  dateRangePickerValue: Date[];
  range1: Date = new Date(2020, 5);
  range2: Date = new Date(2020, 8);
  minMode: BsDatepickerViewMode = 'month';

  colorTheme = 'theme-dark-blue';

  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private bsDatepickerConfig: BsDatepickerConfig) {
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

}
