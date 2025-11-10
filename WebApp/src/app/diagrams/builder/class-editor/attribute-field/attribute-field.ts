import { Component } from "@angular/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

@Component({
    selector: "class-editor-attribute-field",
    imports: [MatFormFieldModule, MatInputModule],
    templateUrl: "./attribute-field.html",
    styleUrl: "./attribute-field.scss",
})
export class AttributeField {}
