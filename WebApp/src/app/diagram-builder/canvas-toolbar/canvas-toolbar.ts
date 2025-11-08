import { Component } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatToolbar } from "@angular/material/toolbar";

@Component({
    selector: "app-canvas-toolbar",
    imports: [MatButtonModule, MatToolbar],
    templateUrl: "./canvas-toolbar.html",
    styleUrl: "./canvas-toolbar.scss",
})
export class CanvasToolbar {}
