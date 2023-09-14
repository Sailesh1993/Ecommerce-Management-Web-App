import { configureStore } from "@reduxjs/toolkit";
import usersReducer from "./reducers/usersReducer";

const store = configureStore({
    reducer: {
        usersReducer,
    },
    preloadedState: {
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