import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { PurchaseService } from "../../services/purchase.service";
import { Purchase } from "../../models/purchase";
import { PurchaseDetailComponent } from "../purchase-detail/purchase-detail.component";
import { PurchaseDetail } from "../../models/purchase-detail";

@Component({
  selector: "app-purchase-list",
  standalone: true,
  imports: [CommonModule, HttpClientModule, PurchaseDetailComponent],
  templateUrl: "./purchase-list.component.html",
  styleUrls: ["./purchase-list.component.scss"],
})
export class PurchaseListComponent implements OnInit {
  purchases: Purchase[] = [];
  selectedPurchase: PurchaseDetail | null = null;

  constructor(private purchaseService: PurchaseService) {}

  ngOnInit(): void {
    this.purchaseService.getAllPurchases().subscribe((data) => {
      this.purchases = data;
    });
  }

  selectPurchase(purchase: Purchase): void {
    this.purchaseService.getPurchaseById(purchase.id).subscribe((data) => {
      this.selectedPurchase = data;
      console.log(this.selectedPurchase);
    });
  }
}
