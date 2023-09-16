import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { Product } from '../types/Product'
import { Box, Button, Typography } from '@mui/material'

const ProductDetails = () => {
    const navigate = useNavigate()
    const { id } = useParams()
    const[product, setProduct] = useState<Product | undefined>()
    const [error, setError] = useState("")

    useEffect(() => {
        axios.get(`https://saileshecom-app.azurewebsites.net/api/v1/products/${id}`)
            .then((response) => {
                (setProduct(response.data))
            })
            .catch((error) => {
                setError(error.message)
            })
    }, [id])
  return (
    <Box sx={{
        padding: '1rem',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center'
    }}>
        <Typography variant="h3" gutterBottom>{product?.title}</Typography>
        <img width={640 * 0.75} height={640 * 0.75} src={product?.images[0]}/>
        <Typography variant='subtitle1' gutterBottom>{product?.description}</Typography>
        <Typography variant='body2' gutterBottom>{product?.price}</Typography>
        <Button variant="contained" onClick={() => navigate("/products")}>Back</Button>
    </Box>
  )
}

export default ProductDetails