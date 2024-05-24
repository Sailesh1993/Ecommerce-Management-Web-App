import Navbar from '../components/Navbar'
import { Box, Typography } from '@mui/material'
import SignIn from '../components/SignIn'

const Home = () => {

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
                Welcome to G-SHOP!
            </Typography>
            <SignIn/>
        </Box>
    </>
  )
}

export default Home