import Button from "@mui/material/Button";
import { useNavigate } from "react-router-dom";
import "../styles/navbar.css";
import useAppSelector from "../hooks/useAppSelector";
import useAppDispatch from "../hooks/useAppDispatch";
import { logout } from "../redux/reducers/usersReducer";


const Navbar = () => {
  const { isLoggedIn } = useAppSelector((state) => state.usersReducer);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const  handleLogout = () => {
    dispatch(logout())
    navigate('/')
  }

  return (
    <nav className="navbar">
      <div className="navbar-brand">
        <h1 onClick={() => navigate("/")}>G-SHOP</h1>
      </div>
      <ul className="nav-links">
      {isLoggedIn ? (
          <>
            <li>
              <Button variant="contained" onClick={() => navigate("/products")}>
                Products
              </Button>
            </li>
            <li>
              <Button variant="contained" onClick={() => navigate("/cart")}>
                Cart
              </Button>
            </li>
            <li>
              <Button variant="contained" onClick={handleLogout}>
                Logout
              </Button>
            </li>
          </>
        ) : (
          <>
            <li>
              <Button variant="contained" onClick={() => navigate("/login")}>
                Login
              </Button>
            </li>
            <li>
              <Button variant="contained" onClick={() => navigate("/register")}>
                Register
              </Button>
            </li>
          </>
        )}
      </ul>
    </nav>
    
  )
}

export default Navbar;
