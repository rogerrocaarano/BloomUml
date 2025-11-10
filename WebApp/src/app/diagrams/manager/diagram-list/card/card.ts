import { Component, Input } from "@angular/core";
import { DiagramListItemModel } from "../diagram-list-item.model";
import { MatCardModule } from "@angular/material/card";

@Component({
    selector: "diagram-list-card",
    imports: [MatCardModule],
    templateUrl: "./card.html",
    styleUrl: "./card.scss",
})
export class Card {
    private _data: DiagramListItemModel = {
        id: "default-id",
        name: "Name",
        owner: "Owner",
        modifiedDateTime: new Date(Date.now())
    };

    public get data(): DiagramListItemModel {
        return this._data;
    }
    
    @Input()
    set details(value: Partial<DiagramListItemModel>) {
        this._data = { ...this._data, ...value };
    }
}
