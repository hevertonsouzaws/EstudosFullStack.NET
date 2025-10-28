import { fetchEmployees, fetchInactiveEmployees } from "../services/employee.service";
import type { IEmployee, IEmployeeStoreState } from "../types/employee.type";
import { defineStore } from "pinia";

export const useEmployeeStore = defineStore('employee', {
    state: (): IEmployeeStoreState => ({
        employees: [],
        inactiveEmployees: [],
        positionFilter: '',
        isLoading: false,
        error: null,
    }),

    getters: {
        totalEmployees: (state) => state.employees.length,

        filteredEmployees: (state) => {
            if (!state.positionFilter) {
                return state.employees;
            }

            const filterLower = state.positionFilter.toLowerCase();

            return state.employees.filter(employee =>
                employee.position.toLowerCase().includes(filterLower)
            );
        },

        uniquePositions: (state) => {
            const positions = state.employees.map(e => e.position);
            return [...new Set(positions)].sort();
        }
    },


    actions: {
        async loadEmployees() {
            this.isLoading = true;
            this.error = null;

            try {
                const data: IEmployee[] = await fetchEmployees();

                this.employees = data;
            } catch (e: any) {
                this.error = e.message || 'Erro desconhecido ao buscar dados'
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
                this.inactiveEmployees = data;
            } catch (e: any) {
                this.error = e.message || 'Erro desconhecido ao buscar dados';
                this.inactiveEmployees = [];
            } finally {
                this.isLoading = false;
            }
        },
        setPositionFilter(position: string) {
            this.positionFilter = position;
        }

    },
});

