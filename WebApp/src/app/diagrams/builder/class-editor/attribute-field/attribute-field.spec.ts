import { ComponentFixture, TestBed } from "@angular/core/testing";

import { AttributeField } from "./attribute-field";

describe("AttributeField", () => {
    let component: AttributeField;
    let fixture: ComponentFixture<AttributeField>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [AttributeField],
        }).compileComponents();

        fixture = TestBed.createComponent(AttributeField);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
