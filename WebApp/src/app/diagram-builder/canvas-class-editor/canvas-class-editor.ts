import { Component, signal } from "@angular/core";
import { ClassNameField } from "./class-name-field/class-name-field";
import { AttributeField } from "./attribute-field/attribute-field";
import { MethodField } from "./method-field/method-field";
import { MatToolbar } from "@angular/material/toolbar";
import { MatAnchor } from "@angular/material/button";

@Component({
    selector: "app-canvas-class-editor",
    imports: [
        ClassNameField,
        AttributeField,
        MethodField,
        MatToolbar,
        MatAnchor,
    ],
    templateUrl: "./canvas-class-editor.html",
    styleUrl: "./canvas-class-editor.scss",
})
export class CanvasClassEditor {
    protected attributes = signal<number[]>([]);
    protected methods = signal<number[]>([]);

    protected addAttribute() {
        this.attributes.update((attrs) => [...attrs, attrs.length]);
    }

    protected addMethod() {
        this.methods.update((methods) => [...methods, methods.length]);
    }
}
