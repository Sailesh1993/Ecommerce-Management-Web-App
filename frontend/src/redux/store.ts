import { configureStore } from "@reduxjs/toolkit";
import usersReducer from "./reducers/usersReducer";
import productsReducer from "./reducers/productsReducer";
import categorysReducer from "./reducers/categorysReducer";
import cartReducer from "./reducers/cartReducer";

const store = configureStore({
    reducer: {
        usersReducer,
        productsReducer,
        categorysReducer,
        cartReducer
    },
    preloadedState: {
        productsReducer: {
            loading: false,
            error: "",
            products: []
        },
        usersReducer: {
            loading: false,
            isLoggedIn: false,
            error: "",
            users: []
        },
        categorysReducer: {
            loading:false,
            error: "",
            categories: []
        },
        cartReducer: {
            id:'',
            creationAt: '',
            updateAt: '',
            productsInCart: []
        }
    }
})

export type GloabalState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store