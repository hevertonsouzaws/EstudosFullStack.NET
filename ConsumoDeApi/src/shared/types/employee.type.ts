export interface IEmployee {
    employeeId: 0;
    name: string;
    position: string;
    photo: string;
    isActive: boolean;
    createdAt: string;
}

export interface IEmployeeStoreState {
    employees: IEmployee[];
    inactiveEmployees: IEmployee[];
    positionFilter: string;
    isLoading: boolean;
    error: string | null;
}

