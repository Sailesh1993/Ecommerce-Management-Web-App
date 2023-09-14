import { StyledEngineProvider } from '@mui/material'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Login from './pages/Login'
import Register from './pages/Register'

const App = () => {
  return (
    <div>
      <StyledEngineProvider>
        <BrowserRouter>
          <Routes>
            <Route path='/login' element={<Login/>}/>
            <Route path='/register' element={<Register/>}/>
          </Routes>
        </BrowserRouter>
      </StyledEngineProvider>
    </div>
  )
}

export default App