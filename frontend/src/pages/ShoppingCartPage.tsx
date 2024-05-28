import useAppSelector from '../hooks/useAppSelector'
import CartEmpty from '../components/CartEmpty'
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material'
import Navbar from '../components/Navbar'
import ShoppingCartRow from '../components/ShoppingCartRow'

const ShoppingCartPage = () => {
    const shoppingCart = useAppSelector(state => state.shoppingCartReducer)
    const productsInCart = shoppingCart.productsInCart
    if(productsInCart.length === 0) return <CartEmpty />
  return (
    <>
    <Navbar />
   <TableContainer component={Paper} sx={{
    padding: '6em 0',
    minHeight: '90vh'
   }}>
    <Table>
        <TableHead>
            <TableRow>
                <TableCell>ID</TableCell>
                <TableCell>Title</TableCell>
                <TableCell>Price</TableCell>
                <TableCell align='right'>Quantity</TableCell>
            </TableRow>
        </TableHead>
        <TableBody>
            {productsInCart.map(product => <ShoppingCartRow key={product.product.id} productsInCart={product} />)}
        </TableBody>
    </Table>

   </TableContainer> 
    </>
    
  )
}

export default ShoppingCartPage