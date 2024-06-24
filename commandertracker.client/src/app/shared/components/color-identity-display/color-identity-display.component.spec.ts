import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorIdentityDisplayComponent } from './color-identity-display.component';

describe('ColorIdentityDisplayComponent', () => {
    let component: ColorIdentityDisplayComponent;
    let fixture: ComponentFixture<ColorIdentityDisplayComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [ColorIdentityDisplayComponent]
        }).compileComponents();

        fixture = TestBed.createComponent(ColorIdentityDisplayComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
