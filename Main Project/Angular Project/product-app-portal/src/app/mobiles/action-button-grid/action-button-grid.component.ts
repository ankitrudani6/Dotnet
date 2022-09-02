import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MobileService } from '../mobile.service';

@Component({
  selector: 'app-action-button-grid',
  templateUrl: './action-button-grid.component.html',
  styleUrls: ['./action-button-grid.component.css']
})
export class ActionButtonGridComponent implements OnInit {
  params: any;
  label: string = '';
  class: string = '';

  constructor(private mobileService: MobileService, private router: Router, private route: ActivatedRoute) { }
  agInit(params: any) {
    this.params = params;
    this.label = this.params.label;
    this.class = this.params.class;
  }
  ngOnInit(): void {
  }
  onClick(event: any) {
    if (this.params.onClick instanceof Function) {
      // put anything into params u want pass into parents component
      debugger
      const params = {
        event: event,
        rowData: this.params.node.data,
        index: this.params.rowIndex
        // ...something
      };

      this.params.onClick(params);
    }
  }
}
