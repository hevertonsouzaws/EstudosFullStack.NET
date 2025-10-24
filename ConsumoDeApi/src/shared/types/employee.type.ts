export interface IEmployee {
    employeeId: 0;
    name: string;
    position: string;
    photo: string;
    isActive: boolean;
}

export interface IEmployeeStoreState {
    employees: IEmployee[];
    inactiveEmployees: IEmployee[];
    isLoading: boolean;
    error: string | null;
}

