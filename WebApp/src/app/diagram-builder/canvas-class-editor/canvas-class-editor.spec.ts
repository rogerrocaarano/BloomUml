import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CanvasClassEditor } from './canvas-class-editor';

describe('CanvasClassEditor', () => {
  let component: CanvasClassEditor;
  let fixture: ComponentFixture<CanvasClassEditor>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CanvasClassEditor]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CanvasClassEditor);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
