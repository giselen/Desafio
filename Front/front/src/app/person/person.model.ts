export interface Person {
    businessEntityID: number;
    name: string;
}
export interface RootObject {
    success: boolean;
    data: Person[];
}