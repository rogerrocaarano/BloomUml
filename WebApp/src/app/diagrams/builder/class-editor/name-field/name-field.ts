import { Component } from "@angular/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

@Component({
    selector: "class-editor-name-field",
    imports: [MatFormFieldModule, MatInputModule],
    templateUrl: "./name-field.html",
    styleUrl: "./name-field.scss",
})
export class NameField {}
