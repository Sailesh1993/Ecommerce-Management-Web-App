import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { Category, NewCategory } from "../../types/Category";

interface CategoryReducer {
    loading: boolean
    error: string
    categories: Category []
}
const initialState: CategoryReducer = {
    loading: false,
    error: "",
    categories: [],
}

export const fetchAllCategories = createAsyncThunk(
    "fetchAllCategories",
    async() => {
        try {
            const result = await axios.get<Category[]>("https://saileshecom-app.azurewebsites.net/api/v1/categorys")
            console.log(result)
            return result.data
            
        } catch (e) {
            const error = e as AxiosError
            return error.message
        }
    }
)
export const createNewCategory = createAsyncThunk(
    "createNewCategory",
    async(category: NewCategory) => {
        try {
            const result = await axios.post<Category>("https://saileshecom-app.azurewebsites.net/api/v1/categorys", category)
            return result.data
        } catch (e) {
            const error = e as AxiosError
            if(error.response)
            {
                return JSON.stringify(error.response.data)
            }
            return error.message
        }
    }
)

const categorySlice = createSlice({
    name: "categories",
    initialState,
    reducers: {
        cleanUpCategoryReducer: (state) => {
            return initialState
        },
        createNewCategory: (state, action: PayloadAction<Category>) => {
            state.categories.push(action.payload)
        }
    },
    extraReducers: (build) => {
        build
            .addCase(fetchAllCategories.pending, (state, action) => {
                state.loading = true
            })
            .addCase(fetchAllCategories.rejected, (state, action) => {
                state.loading = false
                state.error = "Cannot perform this action, please try again"
            })
            .addCase(fetchAllCategories.fulfilled, (state, action) => {
                state.loading = false
                if(typeof action.payload === "string") {
                    state.error = action.payload
                }
                else {
                    state.categories = action.payload
                }
                state.loading = false
            })
            .addCase(createNewCategory.fulfilled, (state, action) => {
                if( typeof action.payload ==="string") {
                    state.error = action.payload
                } else {
                    state.categories.push(action.payload)
                }
                state.loading = false
            })
    }
})

const categorysReducer = categorySlice.reducer
export const {
    cleanUpCategoryReducer
} = categorySlice.actions

export default categorysReducer