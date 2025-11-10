import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Card } from "./card/card";
import { DiagramListItemModel } from "./diagram-list-item.model";

@Component({
    selector: "manager-diagram-list",
    imports: [CommonModule, Card],
    templateUrl: "./diagram-list.html",
    styleUrl: "./diagram-list.scss",
})
export class DiagramList {
    private _data: DiagramListItemModel[] = [];

    public get data(): DiagramListItemModel[] {
        return this._data;
    }

    set data(value: DiagramListItemModel[]) {
        this._data = value;
    }
}
