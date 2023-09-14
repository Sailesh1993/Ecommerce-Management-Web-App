import React, { useState } from 'react'
import useAppDispatch from '../hooks/useAppDispatch'
import { useNavigate } from 'react-router-dom';
import { createNewUser } from '../redux/reducers/usersReducer';
import { Box, Button, TextField, Typography } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';

const SignUp = () => {
    const dispatch = useAppDispatch()
    const navigate = useNavigate()

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [firstName, setFirstName] = useState("")
    const [lastName, setLastName] = useState("")
    const [username, setUsername] = useState("")
    const [avatar, setAvatar] = useState("")
    const [address, setAddress] = useState("")
    const [city, setCity] = useState("")
    const [postalCode, setPostalCode] = useState("")
    const [country, setCountry] = useState("")
    const [phoneNumber, setPhoneNumber] = useState("")

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        dispatch(createNewUser({email, password,
            firstName, lastName, username, avatar, address, 
            city, postalCode, country, phoneNumber}))
            navigate("/")
    }
  return (
    <div data-testid="signup">
        <form onSubmit={e => handleSubmit(e)}>
            <Box sx={{
                padding: '1rem',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center',
            }}>
                <Typography variant='h3' gutterBottom>Register</Typography>
                <Typography variant='body1' gutterBottom>First Name:</Typography>
                <TextField id="outlined-basic" label="First Name" variant='outlined' type='text'
                    value={firstName} onChange={(e)=> setFirstName(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>First Name:</Typography>
                <TextField id="outlined-basic" label="Last Name" variant='outlined' type='text'
                    value={lastName} onChange={(e)=> setLastName(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Email:</Typography>
                <TextField id="outlined-basic" label="Email" variant='outlined' type='email'
                    value={email} onChange={(e)=> setEmail(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Password:</Typography>
                <TextField id="outlined-basic" label="Password" variant='outlined' type='password'
                    value={password} onChange={(e)=> setPassword(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Username:</Typography>
                <TextField id="outlined-basic" label="Username" variant='outlined' type='text'
                    value={username} onChange={(e)=> setUsername(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Avatar:</Typography>
                <TextField id="outlined-basic" label="Avartar" variant='outlined' type='text'
                    value={avatar} onChange={(e)=> setAvatar(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Address:</Typography>
                <TextField id="outlined-basic" label="Address" variant='outlined' type='text'
                    value={address} onChange={(e)=> setAddress(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>City:</Typography>
                <TextField id="outlined-basic" label="City" variant='outlined' type='text'
                    value={city} onChange={(e)=> setCity(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Postal Code:</Typography>
                <TextField id="outlined-basic" label="PostalCode" variant='outlined' type='text'
                    value={postalCode} onChange={(e)=> setPostalCode(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Country:</Typography>
                <TextField id="outlined-basic" label="Country" variant='outlined' type='text'
                    value={country} onChange={(e)=> setCountry(e.target.value)} /><br/>
                <Typography variant='body1' gutterBottom>Phone Number:</Typography>
                <TextField id="outlined-basic" label="Phone Number" variant='outlined' type='number'
                    value={phoneNumber} onChange={(e)=> setPhoneNumber(e.target.value)} /><br/>
                <Button variant='contained' type='submit' endIcon={<SendIcon/>}>Submit</Button>

            </Box>

        </form>
    </div>
  )
}

export default SignUp