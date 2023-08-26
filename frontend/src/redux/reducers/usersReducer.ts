import { createAsyncThunk } from "@reduxjs/toolkit"
import { User } from "../../types/User"
import axios from "axios"

interface UserReducer {
    users : User[]
    currentUser: User
    loading: boolean
    error: string
}

const initialState: UserReducer = {
  users:[],
  loading: false,
  error: ""
}

interface FetchQuery {
  page: number
  perPage: number
}

export const fetchAllUser = createAsyncThunk(
  "fetchAllUsers",
  async({
    page,perPage
  }: FetchQuery) => {
   try {
    const result = await axios.get<User[]>(`http://localhost:5031/api/v1/users`)
   } catch (error) {
    
   }
  }
)