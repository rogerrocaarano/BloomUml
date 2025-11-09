import { Component } from "@angular/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

@Component({
    selector: "app-class-name-field",
    imports: [MatFormFieldModule, MatInputModule],
    templateUrl: "./class-name-field.html",
    styleUrl: "./class-name-field.scss",
})
export class ClassNameField {}
