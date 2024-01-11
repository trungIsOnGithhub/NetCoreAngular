import { Component } from "@angular/core";

@Component({
    selector: 'property-card',
    templateUrl: 'property-card.component.html',
    styleUrls: ['property-card.component.css']
})
export class PropertyCardComponent {
    PropertyInfo : any = {
        "id": 1,
        "type": "flat",
        "price": 299900
    }
}