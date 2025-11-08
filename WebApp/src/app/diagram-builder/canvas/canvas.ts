import { Component } from "@angular/core";
import { CanvasToolbar } from "../canvas-toolbar/canvas-toolbar";
import { DiagramModule } from "@syncfusion/ej2-angular-diagrams";
import { CanvasClassEditor } from "../canvas-class-editor/canvas-class-editor";

@Component({
    selector: "app-canvas",
    imports: [CanvasToolbar, DiagramModule, CanvasClassEditor],
    templateUrl: "./canvas.html",
    styleUrl: "./canvas.scss",
})
export class Canvas {}
