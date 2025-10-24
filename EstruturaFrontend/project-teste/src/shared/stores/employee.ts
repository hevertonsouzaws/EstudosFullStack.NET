import { defineStore } from "pinia";
import { getEmployees, getEmployeeById } from "../services/EmployeeService";
import type { EmployeeDto } from "@/shared/types/Employee";

interface EmployeeState {
    employees: EmployeeDto[];
    selectedEmployee: EmployeeDto | null;
    isLoading: boolean;
    error: string | null;
}

export const useEmployeeStoreWS = defineStore('employee', {
    state: (): EmployeeState => ({
      employees: [],
      selectedEmployee: null,
      isLoading: false,
      error: null,
    }),

    getters: {
        totalActiveEmployees(state): number {
            return state.employees.length;
        },

        employeeOptions(state) {
            return state.employees.map(e => ({
                id: e.EmployeeId,
                name: e.Name    
            }));
        }
    },

    actions: {
        async fetchEmployees() {
            this.isLoading = true;
            this.error = null;

            try {
                const data = await getEmployees();

                this.employees = data;
            } catch (err) {
                this.error = ("Lista de ws´s não carregada");
                this.employees = [];

                console.error("Não deu para buscar os ws´s", err);
            } finally {
                this.isLoading = false;
            }
        },

        async fetchEmployeeById(id: number) {
            this.isLoading = true;
            this.error = null;
            this.selectedEmployee = null;

            try {
                const employeData = await getEmployeeById(id);

                this.selectedEmployee = employeData;
            } catch (err) {
                this.error = `Não temos um WS com o id ${id}`
                console.error('Erro ao buscar WS', err)
            } finally {
                this.isLoading = false;
            }

        }
    }


})