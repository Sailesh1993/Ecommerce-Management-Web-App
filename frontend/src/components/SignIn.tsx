import { useState } from "react"
import useAppDispatch from "../hooks/useAppDispatch"
import { useNavigate } from "react-router-dom"
import { login } from "../redux/reducers/usersReducer"
import { Box, Button, CircularProgress, TextField, Typography } from "@mui/material"
import SendIcon from '@mui/icons-material/Send';

const SignIn = ()=> {
    const dispatch = useAppDispatch()
    const navigate = useNavigate()

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [error, setError] = useState("")
    const [loading, setLoading] = useState(false)

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        setError("")
        setLoading(true)
        try {
            const resultAction = await dispatch(login({email, password}))
            if(login.fulfilled.match(resultAction))
            {
              setLoading(false)
              navigate("/profile")
            }
            else
            {
              if(resultAction.payload)
              {
                setError(resultAction.payload as string);
              }
              else
              {
                setError("Login failed. Please check your credentials.");
              }
              setLoading(false);
            }
            
            
        } catch (error) {
            setLoading(false)
            setError("An unexpected error occurred. Please try again.");
        } 
    }

    return(
        <div data-testid="signin">
            <form onSubmit={(e) => handleSubmit(e)}>
                <Box sx={{
                    padding: '1rem',
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    justifyContent: 'center',
                }}>
                <Typography variant="h3" gutterBottom>Login</Typography>
                <Typography variant="body1" gutterBottom>E-Mail:</Typography>
                <TextField id="email" label="Email" variant="outlined" type="email" value={email} onChange={(e) => 
                    setEmail(e.target.value)}/><br/>
                <Typography variant="body1" gutterBottom>Password:</Typography>
                <TextField id="password" label="Password" variant="outlined" type="password" value={password} onChange={(e) => 
                    setPassword(e.target.value)}/>{loading ? (
                        <CircularProgress sx={{ mt: 2 }} />
                      ) : (
                        <Button
                          variant="contained"
                          type="submit"
                          endIcon={<SendIcon />}
                          sx={{ mt: 2 }}
                        >
                          Submit
                        </Button>
                      )}
                      {error && (
                        <Typography variant="body2" color="error" sx={{ mt: 2 }}>
                          {error}
                        </Typography>
                      )}
                </Box>
            </form>
        </div>
    )
}

export default SignIn