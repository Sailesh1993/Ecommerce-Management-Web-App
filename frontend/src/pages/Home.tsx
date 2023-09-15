import React from 'react'
import { useNavigate } from 'react-router-dom'
import Navbar from '../components/Navbar'
import { Box, Button, Typography } from '@mui/material'

const Home = () => {
    const navigate = useNavigate()
  return (
    <>
        <Navbar/>
        <Box sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
            padding: 10
        }}>
            <Typography variant='h3' gutterBottom sx={{ marginBotton:10}}>
                Welcome to Ecom-Shop!
            </Typography>
            <Typography variant='body1' gutterBottom sx={{marginBottom:10}}>
                Products Available
            </Typography>
            <Button variant='contained' onClick={()=> navigate("/products")}>Products</Button>
        </Box>
    </>
  )
}

export default Home