import { StyledEngineProvider } from '@mui/material'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Login from './pages/Login'

const App = () => {
  return (
    <div>
      <StyledEngineProvider>
        <BrowserRouter>
          <Routes>
            <Route path='/login' element={<Login/>}/>
          </Routes>
        </BrowserRouter>
      </StyledEngineProvider>
    </div>
  )
}

export default App