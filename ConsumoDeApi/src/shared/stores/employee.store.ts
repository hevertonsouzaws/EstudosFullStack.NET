import { fetchEmployees, fetchInactiveEmployees } from "../services/config/employee.service";
import type { IEmployee, IEmployeeStoreState } from "../types/employee.type";
import { defineStore } from "pinia";

export const useEmployeeStore = defineStore('employee', {
    state: (): IEmployeeStoreState => ({
        employees: [],
        inactiveEmployees: [],
        isLoading: false,
        error: null,
    }),

    getters: {
        totalEmployees: (state) => state.employees.length
    },

    actions: {
        async loadEmployees() {
            this.isLoading = true;
            this.error = null;

            try {
                const data: IEmployee[] = await fetchEmployees();

                this.employees = data ;
            } catch (e: any) {
                this.error =e.message || 'Erro desconhecido ao buscar dados'
                this.employees = [];
            } finally {
                this.isLoading = false;
            }
        },
        async loadInactiveEmployees() {
            this.isLoading = true;
            this.error = null;

            try {
                const data: IEmployee[] = await fetchInactiveEmployees();
                this.inactiveEmployees = data ;
            } catch (e: any) {
                this.error =e.message || 'Erro desconhecido ao buscar dados';
                this.inactiveEmployees = [];
            } finally {
                this.isLoading = false;
            }
        },
    },
});

