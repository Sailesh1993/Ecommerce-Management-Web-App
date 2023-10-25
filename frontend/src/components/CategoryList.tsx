import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Category } from '../types/Category'
import { useDispatch } from 'react-redux'
import { fetchAllCategories } from '../redux/reducers/categorysReducer'
import useAppDispatch from '../hooks/useAppDispatch'
import { Button } from '@mui/material'

const CategoryList = () => {
    const dispatch = useAppDispatch()
     const navigate = useNavigate()
     const [category, setCategory] = useState<Category | undefined>()   
     
     useEffect(() => {
        dispatch(fetchAllCategories())
     }, [])
  return (
    <div>
        <Button variant='contained' onClick={() => navigate('/category')}>
                Create New Product
            </Button>
    </div>
  )
}

export default CategoryList