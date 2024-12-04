import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDeckToPlaygroupFormDialogComponent } from './add-deck-to-playgroup-form-dialog.component';

describe('AddDeckToPlaygroupFormDialogComponent', () => {
  let component: AddDeckToPlaygroupFormDialogComponent;
  let fixture: ComponentFixture<AddDeckToPlaygroupFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddDeckToPlaygroupFormDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddDeckToPlaygroupFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
