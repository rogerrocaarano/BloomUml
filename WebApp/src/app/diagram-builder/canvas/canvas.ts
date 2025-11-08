import { Component } from "@angular/core";
import { CanvasToolbar } from "../canvas-toolbar/canvas-toolbar";
import { DiagramModule } from "@syncfusion/ej2-angular-diagrams";

@Component({
    selector: "app-canvas",
    imports: [CanvasToolbar, DiagramModule],
    templateUrl: "./canvas.html",
    styleUrl: "./canvas.scss",
})
export class Canvas {}
