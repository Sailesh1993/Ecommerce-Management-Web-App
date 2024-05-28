import { TableCell, TableRow } from "@mui/material"
import ProductsInCart from "../types/ProductsInCart"

interface ShoppingCartInRow{
    productsInCart: ProductsInCart
}
const ShoppingCartRow = ({productsInCart}: ShoppingCartInRow) => {
  return (
    <TableRow>
        <TableCell>{productsInCart.product.id}</TableCell>
        <TableCell>{productsInCart.product.title}</TableCell>
        <TableCell>{productsInCart.product.price}</TableCell>
        <TableCell align="right">{productsInCart.amount* productsInCart.product.price}</TableCell>
    </TableRow>
  )
}

export default ShoppingCartRow