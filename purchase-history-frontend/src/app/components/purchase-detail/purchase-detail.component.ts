import { Component, Input } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PurchaseDetail } from "../../models/purchase-detail";

@Component({
  selector: "app-purchase-detail",
  standalone: true,
  imports: [CommonModule, PurchaseDetailComponent],
  templateUrl: "./purchase-detail.component.html",
  styleUrls: ["./purchase-detail.component.scss"],
})
export class PurchaseDetailComponent {
  @Input() public purchase!: PurchaseDetail;
}
