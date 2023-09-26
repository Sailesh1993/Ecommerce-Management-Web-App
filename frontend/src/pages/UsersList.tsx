import React, { useEffect } from 'react'
import useAppSelector from '../hooks/useAppSelector'
import { fetchAllUsers } from '../redux/reducers/usersReducer'
import Navbar from '../components/Navbar'
import useAppDispatch from '../hooks/useAppDispatch'

const UsersList = () => {
    const {users, loading, error} = useAppSelector(state => state.usersReducer)
    const dispatch = useAppDispatch()
    useEffect(() => {
        dispatch(fetchAllUsers({ page: 1, perPage : 20}))
    }, [])
  return (
    <>
        <Navbar />
        {users.map(user => (
            <li key={user.id}>
                <p>{user.firstName} {user.lastName} : {user.email}</p>
            </li>
        ))}
        <a href='/'>
            <button>Home</button>
        </a>
    </>
  )
}

export default UsersList