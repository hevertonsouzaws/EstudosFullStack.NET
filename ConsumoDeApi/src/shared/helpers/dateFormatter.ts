const DATE_FORMAT_OPTIONS: Intl.DateTimeFormatOptions = {
    year: 'numeric',
    month: 'short',
    day: '2-digit',
    hour: '2-digit',
    minute: '2-digit',
    hour12: false,
};

export function formateDate(isoString: string): string {
    try {
        const date = new Date(isoString);
        return new Intl.DateTimeFormat('pt-BR', DATE_FORMAT_OPTIONS).format(date);
    } catch (e) {
        console.error('Erro ao formatar data', e);
        return isoString;
    }
}