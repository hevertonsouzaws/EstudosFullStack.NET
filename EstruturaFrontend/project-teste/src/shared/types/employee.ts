export interface StatusTypeDto {
    StatusTypeId: number;
    Description: string;
}

export interface StatusDto {
    StatusId: number;
    CustomText: string | null;
    UpdateAt: string;
    DisplayText: string | null;
    StatusType: StatusTypeDto;
}

export interface EmployeeDto {
    EmployeeId: number;
    Name: string;
    Position: string;
    Photo: string;
    CreatedAt: string;
    IsActive: boolean;
    Status: StatusDto;
}