import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ColDef, ValueGetterParams } from 'ag-grid-community';
import { ActionButtonGridComponent } from '../action-button-grid/action-button-grid.component';
import { ImageFormatterCellComponent } from '../image-formatter-cell/image-formatter-cell.component';
import { Mobile } from '../mobile';
import { MobileService } from '../mobile.service';
@Component({
  selector: 'app-mobile-list',
  templateUrl: './mobile-list.component.html',
  styleUrls: ['./mobile-list.component.css']
})
export class MobileListComponent implements OnInit, OnDestroy {
  mobileList: Mobile[] = [];
  gridApi: any;
  frameworkComponents!: { buttonRenderer: typeof ActionButtonGridComponent; };
  constructor(private mobileService: MobileService, private router: Router, private route: ActivatedRoute) {
    console.log("MobileListComponent constructor")
  }
  public columnDefs: ColDef[] = [
    {
      field: 'productId', sortable: true, filter: true, valueGetter: this.hashValueGetter, maxWidth: 150
    },
    {
      field: 'productName', sortable: true, filter: true
    },
    {
      field: 'image', autoHeight: true,
      cellRendererFramework: ImageFormatterCellComponent
    },
    { field: 'price', sortable: true, filter: true, maxWidth: 100 },
    {
      field: 'Edit',
      cellRenderer: 'buttonRenderer', maxWidth: 100,
      cellRendererParams: {
        onClick: this.onEdit.bind(this),
        label: 'Edit',
        class: 'btn btn-warning'
      }
    }, {
      field: 'Delete', maxWidth: 200,
      cellRenderer: 'buttonRenderer',
      cellRendererParams: {
        onClick: this.onGridDelete.bind(this),
        label: 'Delete',
        class: 'btn btn-danger'
      }
    },

  ];
  ngOnInit(): void {
    this.getList();
    this.frameworkComponents = {
      buttonRenderer: ActionButtonGridComponent
    };
  }
  getList() {
    this.mobileList = this.mobileService.getMobileList();
    this.mobileService.mobileListChanged.subscribe((response) => {
      this.mobileList = response;
      this.gridApi.setRowData(this.mobileList)
    }
    )
  }
  hashValueGetter(params: ValueGetterParams) {
    return params.node ? params.node.rowIndex : null;
  }
  onDelete(id: number) {
    this.mobileService.deleteMobile(id)
  }
  onEdit(params: any) {
    this.router.navigate([`${params.index}`], { relativeTo: this.route });
  }
  onGridDelete(params: any) {
    this.mobileService.deleteMobile(params.index);
    // this.gridApi.updateRowData({ remove: [params.rowData]   });
    // this.gridApi.forEachNode((node: any) => {
    // });
    // return this.rowData;
  }
  onGridReady(params: any) {
    this.gridApi = params.api;
  }
  onRowSelect(event: any) {
    const selectedRows = this.gridApi.getSelectedRows();
    console.log(selectedRows);
    // this.router.navigate([`${event.rowIndex}`], { relativeTo: this.route });
  }

  ngOnDestroy() { }
}
