export interface User{
    id:number
    email: string
    password: string
    role: "user" | "admin"
    firstName : string
    lastName : string
    username: string
    avatar : string
    address : string
    city: string
    postalCode: string
    phoneNumber: string
}

export interface UserCredential {
    email: string
    password: string
}

export interface UserUpdate{
    id: number
    update: Omit<User, "id">
}

export interface NewUser{
    id:number
    email: string
    password: string
    firstName : string
    lastName : string
    username: string
    avatar : string
    address : string
    city: string
    postalCode: string
    phoneNumber: string
}