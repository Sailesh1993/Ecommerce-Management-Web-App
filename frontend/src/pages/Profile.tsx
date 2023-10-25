import useAppSelector from '../hooks/useAppSelector'
import Navbar from '../components/Navbar'
import { Box, Typography } from '@mui/material'

const Profile = () => {
    const currentUser = useAppSelector((state) => state.usersReducer.currentUser)
  return (
    <>
        <Navbar />
        <Box sx={{
            padding: '1rem',
            display:'flex',
            flexDirection:'column',
            alignItems:'center',
            justifyContent:'center'
        }}>
            <Typography variant='h3' gutterBottom>Profile</Typography>
            <Typography variant='body1' gutterBottom>Welcome:{currentUser?.firstName }</Typography>
            <Typography variant='body1' gutterBottom>Welcome:{currentUser?.email }</Typography>
            <img width={320} height={320} src='currentUser?.avatar' alt='avatar' />
        </Box>
    </>
  )
}

export default Profile