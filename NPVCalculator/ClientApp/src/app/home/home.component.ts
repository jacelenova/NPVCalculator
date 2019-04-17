import { Component, OnInit, ViewChild } from '@angular/core';
import { Form, NgForm } from '@angular/forms';
import { NPVQuery } from '../classes/npvquery';
import { NPVService } from '../services/npv.service';
import { CashFlow } from '../classes/cash-flow';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    @ViewChild('npvForm') npvForm: NgForm;
    form: Form;
    npvQuery: NPVQuery;
    x = 4.045;

    constructor(private npvService: NPVService) {}

    ngOnInit() {
        this.npvQuery = new NPVQuery();
        this.npvQuery.cashFlows.push(new CashFlow());
    }

    addCashFlow(): void {
        this.npvQuery.cashFlows.push(new CashFlow());
    }

    computeNPV(): void {
        for (const i in this.npvForm.controls) {
            if (this.npvForm.controls[i]) {
                this.npvForm.controls[i].markAsTouched();
            }
        }

        if (this.npvForm.valid) {
            this.npvQuery.id = 0;
            this.npvQuery.cashFlows.forEach(cf => {
                cf.id = 0;
            });
            this.npvQuery.queryResults.length = 0;
            this.npvService.computeNPV(this.npvQuery).subscribe(res => {
                this.npvQuery = res;
            });
        }
    }

    removeCashFlow(index: number): void {
        if (this.npvQuery.cashFlows.length > 1)  {
            this.npvQuery.cashFlows.splice(index, 1);
        }
    }

    roundNumber(value: number, decimals: number = 0): number {
        return Number(Math.round(Number(value + 'e' + decimals)) + 'e-' + decimals);
    }
}
