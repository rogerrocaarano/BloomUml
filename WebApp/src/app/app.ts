import { Component, signal } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { Canvas } from "./diagram-builder/canvas/canvas";

@Component({
    selector: "app-root",
    imports: [RouterOutlet, Canvas],
    templateUrl: "./app.html",
    styleUrl: "./app.scss",
})
export class App {
    protected readonly title = signal("bloomuml-webapp");
}
