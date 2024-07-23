import { Routes } from "@angular/router";
import { PurchaseListComponent } from "./components/purchase-list/purchase-list.component";
import { SummaryStatisticsComponent } from "./components/summary-statistics/summary-statistics.component";

export const routes: Routes = [
  { path: "", redirectTo: "/purchases", pathMatch: "full" },
  { path: "purchases", component: PurchaseListComponent },
  { path: "summary", component: SummaryStatisticsComponent },
];
