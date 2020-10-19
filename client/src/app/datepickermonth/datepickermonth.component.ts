import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig, BsDatepickerViewMode } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-datepickermonth',
  templateUrl: './datepickermonth.component.html',
  styleUrls: ['./datepickermonth.component.css']
})
export class DatepickermonthComponent implements OnInit {

  datePickerValue: Date = new Date(2020, 7);
  dateRangePickerValue: Date[];
  range1: Date = new Date(2020, 5);
  range2: Date = new Date(2020, 8);
  minMode: BsDatepickerViewMode = 'month';

  colorTheme = 'theme-dark-blue';

  bsConfig: Partial<BsDatepickerConfig>;

  constructor() {
  }

  ngOnInit(): void {
    this.dateRangePickerValue = [this.range1, this.range2];
    this.bsConfig = Object.assign({}, {
      minMode : this.minMode,
      containerClass: this.colorTheme
    });
  }

}
