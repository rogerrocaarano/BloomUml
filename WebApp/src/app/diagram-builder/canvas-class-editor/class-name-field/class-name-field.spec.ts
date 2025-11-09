import { ComponentFixture, TestBed } from "@angular/core/testing";

import { ClassNameField } from "./class-name-field";

describe("ClassNameField", () => {
    let component: ClassNameField;
    let fixture: ComponentFixture<ClassNameField>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [ClassNameField],
        }).compileComponents();

        fixture = TestBed.createComponent(ClassNameField);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
