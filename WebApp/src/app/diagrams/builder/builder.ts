import { Component } from "@angular/core";
import { Canvas } from "./canvas/canvas";
import { ClassEditor } from "./class-editor/class-editor";

@Component({
    selector: "diagrams-builder",
    imports: [Canvas, ClassEditor],
    templateUrl: "./builder.html",
    styleUrl: "./builder.scss",
})
export class Builder {}
