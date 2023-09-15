import { Category } from "./Category";


export interface Product {
    id: string,
    title: string,
    images: string,
    description: string,
    price: number,
    category: Category
}

export interface NewProduct {
    title: string,
    images: string,
    description: string,
    price: number,
    category: Category
}

export interface ProductUpdate {
    id: string
    update:
    {
        title: string,
        images: string,
        description: string,
        price: number,
    },
    category: Category
}