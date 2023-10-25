import { configureStore } from "@reduxjs/toolkit";
import usersReducer from "./reducers/usersReducer";
import productsReducer from "./reducers/productsReducer";
import categorysReducer from "./reducers/categorysReducer";

const store = configureStore({
    reducer: {
        usersReducer,
        productsReducer,
        categorysReducer
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
            categorys: []
        }
    }
})

export type GloabalState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store