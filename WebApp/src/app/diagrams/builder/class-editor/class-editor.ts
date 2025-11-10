import { Component, signal } from "@angular/core";
import { NameField } from "./name-field/name-field";
import { AttributeField } from "./attribute-field/attribute-field";
import { MethodField } from "./method-field/method-field";
import { MatToolbar } from "@angular/material/toolbar";
import { MatAnchor } from "@angular/material/button";

@Component({
    selector: "builder-class-editor",
    imports: [NameField, AttributeField, MethodField, MatToolbar, MatAnchor],
    templateUrl: "./class-editor.html",
    styleUrl: "./class-editor.scss",
})
export class ClassEditor {
    protected attributes = signal<number[]>([]);
    protected methods = signal<number[]>([]);

    protected addAttribute() {
        this.attributes.update((attrs) => [...attrs, attrs.length]);
    }

    protected addMethod() {
        this.methods.update((methods) => [...methods, methods.length]);
    }
}
