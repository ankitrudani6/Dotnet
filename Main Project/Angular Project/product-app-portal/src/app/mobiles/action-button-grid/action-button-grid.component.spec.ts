import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionButtonGridComponent } from './action-button-grid.component';

describe('ActionButtonGridComponent', () => {
  let component: ActionButtonGridComponent;
  let fixture: ComponentFixture<ActionButtonGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionButtonGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionButtonGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
