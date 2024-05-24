import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { NewUser, User, UserCredential, UserUpdate } from "../../types/User";
import axios, { AxiosError } from "axios";

interface UserReducer {
  users: User[],
  isLoggedIn: boolean,
  currentUser?: User,
  loading: boolean,
  error: string
}

const initialState: UserReducer = {
  users: [],
  isLoggedIn: false,
  loading: false,
  error: "",
}

interface FetchQuery {
  page: number;
  perPage: number;
}

export const fetchAllUsers = createAsyncThunk(
  "fetchAllUsers",
  async ({ page, perPage }: FetchQuery) => {
    try {
      const result = await axios.get<User[]>(
        `https://saileshecom-app.azurewebsites.net/api/v1/users`
      );
      return result.data;
    } catch (e) {
      const error = e as AxiosError;
      return error;
    }
  }
);

export const login = createAsyncThunk(
  "login",
  async (credentials: UserCredential, { rejectWithValue }) => {
    try {
      
      const response = await axios.post('https://saileshecom-app.azurewebsites.net/api/v1/auth/login', credentials);
      localStorage.setItem("token", response.data);

      const userResponse = await axios.get('https://saileshecom-app.azurewebsites.net/api/v1/auth/profile', {
        headers: {
          Authorization: `Bearer ${response.data}`,
        },
      })
      return userResponse.data;
    } catch (e) {
      const error = e as AxiosError
      if (error.response && error.response.status === 401) {
       
        return rejectWithValue("Invalid email or password");
      }
      return rejectWithValue(error.message)
    }
  }
)

export const createNewUser = createAsyncThunk(
  "createNewUser", 
  async (user: NewUser) => {
    try {
      const result = await axios.post<User>(
        "https://saileshecom-app.azurewebsites.net/api/v1/users/", user)
      console.log(result.data)
      return result.data
    } catch (e) {
        const error = e as AxiosError
        throw new Error(error.message)
    }
  }
)

const userSlice = createSlice({
  name: "users",
  initialState,
  reducers: {
    createUser: (state, action: PayloadAction<User>) => {
      state.users.push(action.payload)
    },
    updateUserReducer: (state, action: PayloadAction<User[]>) => {

    },
    emptyUserReducer: (state) => {
      state.users = []
    },
    updateOneUser: (state, action: PayloadAction<UserUpdate>) => {
      const users = state.users.map(user => {
        if(user.id === action.payload.id) {
          return { ...user, ...action.payload.update}
        }
        return user
      })
      return {
        ...state,
        users
      }
    },
    sortByEmail: (state, action: PayloadAction<"asc" | "desc">) => {
      if(action.payload === "asc") {
        state.users.sort((a,b) => a.email.localeCompare(b.email))
      }
      else {
        state.users.sort((a,b) => b.email.localeCompare(a.email))
      }
    },
    logout: (state) => {
      state.isLoggedIn = false;
      state.currentUser = undefined;
      localStorage.removeItem("token");
    },
  },
  extraReducers: (build) => {
    build
      .addCase(fetchAllUsers.fulfilled, (state, action) => {
        if(action.payload instanceof AxiosError) {
          state.error = action.payload.message
        }
        else{
          state.users = action.payload
        }
        state.loading = false
      })
      .addCase(fetchAllUsers.pending, (state, action) => {
        state.loading = true
      })
      .addCase(fetchAllUsers.rejected, (state, action) => {
        state.error = "Cannot fetch data"
      })
      .addCase(createNewUser.fulfilled, (state, action) => {
        state.loading = false
        state.users.push(action.payload)
      })
      .addCase(createNewUser.pending, (state, action) => {
        state.loading = true
      })
      .addCase(createNewUser.rejected, (state, action) => {
        state.error = "Failed to create new user!" 
      })
      .addCase(login.pending, (state) => {
        state.loading = true;
        state.error = ""
    })
    .addCase(login.fulfilled, (state, action) => {
        state.loading = false;
        state.error = ""
        state.isLoggedIn = true
        state.currentUser = action.payload
    })
    .addCase(login.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
    })
  }
})

const usersReducer = userSlice.reducer
export const 
{
  createUser,
  updateUserReducer,
  emptyUserReducer,
  updateOneUser,
  sortByEmail,
  logout
} = userSlice.actions
export default usersReducer