import { StyledEngineProvider } from '@mui/material'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Login from './pages/Login'
import Register from './pages/Register'
import Home from './pages/Home'
import Products from './pages/Products'
import SingleProduct from './pages/SingleProduct'
import UsersList from './pages/UsersList'
import Profile from './pages/Profile'

const App = () => {
  return (
    <div>
      <StyledEngineProvider>
        <BrowserRouter>
          <Routes>
            <Route path='/' element={<Home/>} />
            <Route path='/products/:id' element={<SingleProduct/>} />
            <Route path='/products' element={<Products/>} />
            <Route path='/users' element={<UsersList/>} />
            <Route path='/login' element={<Login/>}/>
            <Route path='/register' element={<Register/>}/>
            <Route path='/profile' element={<Profile />}/>

          </Routes>
        </BrowserRouter>
      </StyledEngineProvider>
    </div>
  )
}

export default App