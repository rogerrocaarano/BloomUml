import { ComponentFixture, TestBed } from "@angular/core/testing";

import { MethodField } from "./method-field";

describe("MethodField", () => {
    let component: MethodField;
    let fixture: ComponentFixture<MethodField>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [MethodField],
        }).compileComponents();

        fixture = TestBed.createComponent(MethodField);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
