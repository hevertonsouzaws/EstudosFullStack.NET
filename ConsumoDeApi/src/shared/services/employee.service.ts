import { api } from "./config/api.config";
import type { IEmployee } from "@/shared/types/employee.type";

export async function fetchEmployees(): Promise<IEmployee[]> {
    try {
        const response = await api.get<IEmployee[]>('/api/employee')

        return response.data;
    } catch (error) {
        console.error('Service Error: Falha ao buscar funcionários', error)
        throw new Error('Não foi possível carregar a lista de funcionários. Verifique a conexão')
    }
}

export async function fetchInactiveEmployees(): Promise<IEmployee[]> {
    try {
        const response = await api.get<IEmployee[]>('/api/employee/inactive')

        return response.data;
    } catch (error) {
        console.error('Service Error: Falha ao buscar funcionários inativos', error)
        throw new Error('Não foi possível carregar a lista de funcionários inativos. Verifique a conexão')
    }
}