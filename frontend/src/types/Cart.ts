export interface CartItem
{
    productId: string;
    quantity: number;
}

export interface CartCreate 
{
    cartItem: CartItem;
    userID: string;
}

export interface CartItemDetails
{
    productId: string;
    productTitle:string;
    quantity: number;
    productPrice: number;
}

export interface ShopCart
{
    totalAmount: number;
    isActive: boolean;
    cartItem: CartItemDetails[]
}