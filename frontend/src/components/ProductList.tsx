import React, { useEffect, useState } from 'react'
import { Product } from '../types/Product'
import useAppDispatch from '../hooks/useAppDispatch'
import { Link, useNavigate } from 'react-router-dom'
import useAppSelector from '../hooks/useAppSelector'
import { fetchAllProducts, sortByPrice } from '../redux/reducers/productsReducer'
import { Box, Button, Grid, TextField, Typography } from '@mui/material'

const getFilteredList = (products: Product[], search: string) => {
    return products.filter((product) => 
        product.title.toLowerCase().includes(search.toLowerCase())
    )
}
const ProductList = () => {
    const dispatch = useAppDispatch()
    const navigate = useNavigate()

    const [sort, setSort] = useState<number>(0)
    const {products, loading, error } = useAppSelector((state) => state.productsReducer)
    const [search, setSearch] = useState<string>('')
    const filterProducts = getFilteredList(products, search)
    const onSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value)
    }

    useEffect(() => {
        dispatch(fetchAllProducts())
    }, [])

    const sortByPriceDynamic = () => {
        dispatch(sortByPrice(sort))
        setSort(sort === 0 ? 1 : 0)
    }
  return (
    <div>
        <br/>
        <div>
            <TextField id="filled-basic" label="Filled" variant="filled" type="text" value={search} placeholder="Search" onChange= {onSearchChange} />
            <Button variant='contained'  size="large" onClick={sortByPriceDynamic}>Sort Price
            </Button>
        </div>
        <div>
            <Button variant='contained' onClick={() => navigate('/newProduct')}>
                Create New Product
            </Button>
            <Button variant='contained' onClick={() => navigate('/updateProduct')}>
                Update Product
            </Button>
            <Button variant='contained' onClick={() => navigate('/deleteProduct')}>
                Delete Product
            </Button>
        </div>
        <br/>
        <Grid container spacing={2}>
            {filterProducts.map((product) => (
                <Grid item xs={4} key={product.id}>
                    <Box sx={{
                        border: '1px solid lightblue',
                        borderRadius: '8px',
                        padding: '1rem',
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        justifyContent: 'center'
                    }}>
                        <Typography variant='h6' gutterBottom>
                            {product.title}
                        </Typography>
                        <img width={640 * 0.75} height={640 * 0.75} 
                            src={product.images && product.images.length > 0 ? product.images[0]:''} alt={product.title} />
                        <Typography variant='body1' gutterBottom>
                            {product.price} €
                        </Typography>
                        <div>
                            <Link to={`/products/${product.id}`}>
                                <Button variant='outlined'>Details</Button>
                            </Link>
                        </div>
                    </Box>
                </Grid>
            ))}
        </Grid>
    </div>
  )
}

export default ProductList