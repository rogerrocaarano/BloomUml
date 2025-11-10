import { ComponentFixture, TestBed } from "@angular/core/testing";

import { DiagramList } from "./diagram-list";

describe("DiagramList", () => {
    let component: DiagramList;
    let fixture: ComponentFixture<DiagramList>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [DiagramList],
        }).compileComponents();

        fixture = TestBed.createComponent(DiagramList);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
