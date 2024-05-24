import Navbar from '../components/Navbar'
import { Box, Button, Typography } from '@mui/material'
import SignIn from '../components/SignIn'
import { useNavigate } from 'react-router-dom';

const Home = () => {
  const navigate = useNavigate();

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
        </Box>
    </>
  )
}

export default Home