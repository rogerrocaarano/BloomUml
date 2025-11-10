import { Component } from "@angular/core";
import { DiagramModule } from "@syncfusion/ej2-angular-diagrams";
import { Toolbar } from "./toolbar/toolbar";

@Component({
    selector: "builder-canvas",
    imports: [DiagramModule, Toolbar],
    templateUrl: "./canvas.html",
    styleUrl: "./canvas.scss",
})
export class Canvas {}
