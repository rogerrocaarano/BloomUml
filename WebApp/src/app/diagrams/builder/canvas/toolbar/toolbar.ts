import { Component } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatToolbar } from "@angular/material/toolbar";

@Component({
    selector: "canvas-toolbar",
    imports: [MatButtonModule, MatToolbar],
    templateUrl: "./toolbar.html",
    styleUrl: "./toolbar.scss",
})
export class Toolbar {}
