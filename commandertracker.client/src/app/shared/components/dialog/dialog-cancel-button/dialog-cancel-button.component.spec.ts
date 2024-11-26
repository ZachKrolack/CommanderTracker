import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCancelButtonComponent } from './dialog-cancel-button.component';

describe('DialogCancelButtonComponent', () => {
  let component: DialogCancelButtonComponent;
  let fixture: ComponentFixture<DialogCancelButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogCancelButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogCancelButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
