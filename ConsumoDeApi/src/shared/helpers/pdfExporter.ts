import jsPDF from "jspdf";
import 'jspdf-autotable';
import { formateDate } from "./dateFormatter";
import type { IEmployee } from "../types/employee.type";

interface ExportColumn {
    header: string;
    dataKey: string;
}

export function exportEmployeesToPDF(employees: IEmployee[], title:string = 'Relatório de funcionários') {
    const doc = new jsPDF('p', 'mm', 'a4');

    const columns: ExportColumn[] = [
        {header: 'ID', dataKey:'employeeId' as keyof IEmployee},
        {header: 'Nome', dataKey:'name' as keyof IEmployee},
        {header: 'Cargo', dataKey:'position' as keyof IEmployee},
        {header: 'Criação', dataKey:'createdAt' as keyof IEmployee},
    ];

    const mappedData = employees.map(emp => ({
        employeeId: emp.employeeId,
        name: emp.name,
        position: emp.position,
        createdAt: formateDate(emp.createdAt),
    }));

    doc.text(title, 14, 15);

    (doc as any).autoTable({
        head: [columns.map(col => col.header)],
        body: mappedData.map((data: Record<string, any>) => 
        columns.map(col => data[col.dataKey])
    ),
        startY: 20,
    });

    doc.save('relatorio_funcionarios.pdf');
}