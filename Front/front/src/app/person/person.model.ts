export interface Person {
    businessEntityID: number;
    name: string;
}
export interface ResponsePerson {
    success: boolean;
    data: Person[];
}