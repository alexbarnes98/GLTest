export interface SummaryStatistics {
  spendPerMonth: { [key: string]: number };
  mostExpensiveMonth: string;
  monthWithMostUnitsBought: string;
  mostExpensivePurchaseProductName: string;
  productNameWithMostUnitsBought: string;
}
