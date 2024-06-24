import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorIdentitySelectorComponent } from './color-identity-selector.component';

describe('ColorIdentitySelectorComponent', () => {
    let component: ColorIdentitySelectorComponent;
    let fixture: ComponentFixture<ColorIdentitySelectorComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [ColorIdentitySelectorComponent]
        }).compileComponents();

        fixture = TestBed.createComponent(ColorIdentitySelectorComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
