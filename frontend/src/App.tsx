import { StyledEngineProvider } from '@mui/material'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Register from './pages/Register'
import Home from './pages/Home'
import Products from './pages/Products'
import SingleProduct from './pages/SingleProduct'
import UsersList from './pages/UsersList'
import Profile from './pages/Profile'
import ShoppingCartPage from './pages/ShoppingCartPage'
import SignIn from './components/SignIn'

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
            <Route path='/login' element={<SignIn/>}/>
            <Route path='/register' element={<Register/>}/>
            <Route path='/profile' element={<Profile />}/>
            <Route path='/cart' element={<ShoppingCartPage />}/>

          </Routes>
        </BrowserRouter>
      </StyledEngineProvider>
    </div> 
  )
}

export default App