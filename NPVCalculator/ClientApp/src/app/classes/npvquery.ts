import { QueryResult } from './query-result';
import { CashFlow } from './cash-flow';

export class NPVQuery {
    id = 0;
    initialInvestment = 0;
    lowerBoundRate = 0;
    upperBoundRate = 0;
    rateIncrement = 0;
    cashFlows: Array<CashFlow> = new Array<CashFlow>();
    queryResults: Array<QueryResult> = new Array<QueryResult>();
}
