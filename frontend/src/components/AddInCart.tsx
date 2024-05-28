import useAppDispatch from "../hooks/useAppDispatch"
import useAppSelector from "../hooks/useAppSelector"
import { Product } from "../types/Product"
import ProductsInCart from "../types/ProductsInCart"
import ShoppingCart from "../types/ShoppingCart"
import { addProduct, removeProduct } from "../redux/reducers/shoppingCartReducer"
import { Button } from "@mui/material"
import { GridAddIcon, GridRemoveIcon } from "@mui/x-data-grid"
import { useMemo } from "react"

interface AddInCartProps{
    product: Product
}
const AddInCart = ({product} : AddInCartProps) => {
    const dispatch = useAppDispatch()
    const shoppingCart = useAppSelector(state => state.shoppingCartReducer)
    const isProductInCart = (shoppingCart: ShoppingCart, product: Product) => 
    shoppingCart.productsInCart.some((item: ProductsInCart) => item.product.title === product.title)

    useMemo(()=> {
        return isProductInCart(shoppingCart, product)
    }, [product, shoppingCart])

    const handleProductAddClick = ()=> {
        dispatch(addProduct(product))
    }
    
    const handleProductRemoveClick = () =>{
        dispatch(removeProduct(product.id))
    }
  return (
    <div>
    <Button onClick={handleProductAddClick}>
      <GridAddIcon />
    </Button>
    <Button onClick={handleProductRemoveClick}>
      <GridRemoveIcon />
    </Button>
  </div>
  )
}

export default AddInCart