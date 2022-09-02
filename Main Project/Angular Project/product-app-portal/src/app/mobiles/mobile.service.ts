import { EventEmitter } from '@angular/core';
import { Mobile } from './mobile';
export class MobileService {
  mobileList: Mobile[] = [
    {
      productName: "iPhone 10",
      price: 60000, image: "https://www.bing.com/th?id=OPA.LydO4rsRo10fxw474C474&o=5&pid=21.1&w=120&h=120&rs=1&qlt=100&dpr=1"
      , description: ''
    },
    {
      productName: "iPhone 11",
      price: 70000, image: "https://www.bing.com/th?id=OPA.LydO4rsRo10fxw474C474&o=5&pid=21.1&w=120&h=120&rs=1&qlt=100&dpr=1", description: ''
    },
    {
      productName: "iPhone 12",
      price: 80000, image: "https://www.bing.com/th?id=OPA.LydO4rsRo10fxw474C474&o=5&pid=21.1&w=120&h=120&rs=1&qlt=100&dpr=1", description: '', otherImages: ["https://www.bing.com/th?id=OPA.LydO4rsRo10fxw474C474&o=5&pid=21.1&w=120&h=120&rs=1&qlt=100&dpr=1", "https://www.bing.com/th?id=OPA.LydO4rsRo10fxw474C474&o=5&pid=21.1&w=120&h=120&rs=1&qlt=100&dpr=1"]
    }
  ];
  mobileListChanged = new EventEmitter<Mobile[]>();
  constructor() { }
  getMobileList() {
    return this.mobileList;
  }
  getMobile(id: number) {
    return this.mobileList[id];
  }
  addMobile(mobile: Mobile) {
    this.mobileList.push(mobile);
    console.log(this.mobileList);
  }
  updateMobile(id: number, mobile: Mobile) {
    this.mobileList[id] = mobile;
  }
  deleteMobile(id: number) {
    this.mobileList.splice(id, 1);
    this.mobileListChanged.emit(this.mobileList);
  }
}
