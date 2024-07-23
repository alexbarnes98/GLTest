// src/app/components/summary-statistics/summary-statistics.component.ts
import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Chart } from "chart.js/auto";
import { PurchaseService } from "../../services/purchase.service";
import { SummaryStatistics } from "../../models/summary-statistics";

@Component({
  selector: "app-summary-statistics",
  standalone: true,
  imports: [CommonModule],
  templateUrl: "./summary-statistics.component.html",
  styleUrls: ["./summary-statistics.component.scss"],
})
export class SummaryStatisticsComponent implements OnInit {
  mostExpensiveMonth!: string;
  monthWithMostUnitsBought!: string;
  mostExpensivePurchaseProductName!: string;
  productNameWithMostUnitsBought!: string;

  constructor(private purchaseService: PurchaseService) {}

  ngOnInit(): void {
    this.purchaseService
      .getSummaryStatistics()
      .subscribe((data: SummaryStatistics) => {
        this.mostExpensiveMonth = data.mostExpensiveMonth;
        this.monthWithMostUnitsBought = data.monthWithMostUnitsBought;
        this.mostExpensivePurchaseProductName =
          data.mostExpensivePurchaseProductName;
        this.productNameWithMostUnitsBought =
          data.productNameWithMostUnitsBought;
        this.createChart(data);
      });
  }

  createChart(data: SummaryStatistics): void {
    const ctx = document.getElementById("summaryChart") as HTMLCanvasElement;
    new Chart(ctx, {
      type: "bar",
      data: {
        labels: Object.keys(data.spendPerMonth),
        datasets: [
          {
            label: "Spend Per Month",
            data: Object.values(data.spendPerMonth),
            backgroundColor: "rgba(75, 192, 192, 0.2)",
            borderColor: "rgba(75, 192, 192, 1)",
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }
}
