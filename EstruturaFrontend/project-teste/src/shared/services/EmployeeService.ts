import { get } from "lodash";
import type { EmployeeDto } from "@/shared/types/Employee";
import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7208",
    headers: {
        'Content-Type': 'application/json'
    },
});

export async function getEmployees(): Promise<EmployeeDto[]> {
    try {
        const response = await api.get<EmployeeDto[]>('/api/employee');
        return response.data;
    } catch (error) {
        console.log('API não encontrada')
        throw error;
    }
}

export async function getEmployeeById(id: number): Promise<EmployeeDto> {
       try {
        const response = await api.get<EmployeeDto>(`/api/employee/${id}`);
        return response.data;
    } catch (error) {
        console.log('API não encontrada')
        throw error;
    }
}
