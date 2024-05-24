import Button from "@mui/material/Button"
import { useNavigate } from "react-router-dom"
import '../styles/navbar.css'


const Navbar = ()=> {
    const navigate = useNavigate()

    return (
        <nav className="navbar"> 
      <div className="navbar-brand"> 
        <h1 onClick={() => navigate('/')}>G-SHOP</h1> 
      </div>
      <ul className="nav-links"> 
        <li>
          <Button variant="contained" onClick={() => navigate('/')}>Home</Button>
        </li>
        <li>
          <Button variant="contained" onClick={() => navigate('/products')}>Products</Button>
        </li>
        <li>
          <Button variant="contained" onClick={() => navigate('/cart')}>
            Cart
          </Button>
        </li>
        <li>
          <Button variant="contained" onClick={() => navigate('/register')}>Register</Button>
        </li>
        <li>
          <Button variant="contained" onClick={() => navigate('/login')}>Login</Button>
        </li>
        <li>
          <Button variant="contained" onClick={() => navigate('/profile')}>Profile</Button>
        </li>
      </ul>
    </nav>
    )
}

export default Navbar