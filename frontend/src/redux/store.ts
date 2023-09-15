import { configureStore } from "@reduxjs/toolkit";
import usersReducer from "./reducers/usersReducer";
import productsReducer from "./reducers/productsReducer";

const store = configureStore({
    reducer: {
        usersReducer,
        productsReducer
    },
    preloadedState: {
        productsReducer: {
            loading: false,
            error: "",
            products: []
        },
        usersReducer: {
            loading: false,
            error: "",
            users: []
        },
    }
})

export type GloabalState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store