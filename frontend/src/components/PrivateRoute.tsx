import { Navigate, Outlet } from "react-router-dom";
import useAppSelector from "../hooks/useAppSelector"

const PrivateRoute = () => {
    const {isLoggedIn} = useAppSelector((state => state.usersReducer))
  return isLoggedIn ? <Outlet /> : <Navigate to="/login" />;
}

export default PrivateRoute