import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Purchase } from "../models/purchase";
import { PurchaseDetail } from "../models/purchase-detail";
import { SummaryStatistics } from "../models/summary-statistics";

@Injectable({
  providedIn: "root",
})
export class PurchaseService {
  private apiUrl = "https://localhost:7122/purchase";

  constructor(private http: HttpClient) {}

  getAllPurchases(): Observable<Purchase[]> {
    return this.http.get<Purchase[]>(`${this.apiUrl}/GetAllPurchases`);
  }

  getPurchaseById(id: number): Observable<PurchaseDetail> {
    return this.http.get<PurchaseDetail>(
      `${this.apiUrl}/GetPurchaseById?id=${id}`
    );
  }
  getSummaryStatistics(): Observable<SummaryStatistics> {
    return this.http.get<SummaryStatistics>(`${this.apiUrl}/summary`);
  }
}
