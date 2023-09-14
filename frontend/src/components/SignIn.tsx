import { useState } from "react"
import useAppDispatch from "../hooks/useAppDispatch"
import { useNavigate } from "react-router-dom"
import { login } from "../redux/reducers/usersReducer"
import { Box, Button, TextField, Typography } from "@mui/material"
import SendIcon from '@mui/icons-material/Send';

const SignIn = ()=> {
    const dispatch = useAppDispatch()
    const navigate = useNavigate()

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        dispatch(login({email, password}))
        navigate("/profile")
    }

    return(
        <div data-testid="signin">
            <form onSubmit={e => handleSubmit(e)}>
                <Box sx={{
                    padding: '1rem',
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    justifyContent: 'center',
                }}>
                <Typography variant="h3" gutterBottom>Login</Typography>
                <Typography variant="body1" gutterBottom>E-Mail:</Typography>
                <TextField id="outlined-basic" label="Email" variant="outlined" type="email" value={email} onChange={(e) => 
                    setEmail(e.target.value)}/><br/>
                <Typography variant="body1" gutterBottom>Password:</Typography>
                <TextField id="outlined-basic" label="Password" variant="outlined" type="text" value={password} onChange={(e) => 
                    setPassword(e.target.value)}/><br/>
                    <Button variant="contained" type="submit" endIcon={<SendIcon />}>Submit</Button>
                </Box>
            </form>
        </div>
    )
}

export default SignIn