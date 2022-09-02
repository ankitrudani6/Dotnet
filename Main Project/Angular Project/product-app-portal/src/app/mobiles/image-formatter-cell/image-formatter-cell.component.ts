import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-image-formatter-cell',
  templateUrl: './image-formatter-cell.component.html',
  styleUrls: ['./image-formatter-cell.component.css']
})
export class ImageFormatterCellComponent implements OnInit {
  params: any;

  constructor() { }
  agInit(params: any) {
    this.params = params;
  }
  ngOnInit(): void {
  }

}
