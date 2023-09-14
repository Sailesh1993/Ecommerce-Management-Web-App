import { TypedUseSelectorHook, useSelector } from "react-redux";
import { GloabalState } from "../redux/store";

const useAppSelector: TypedUseSelectorHook<GloabalState> = useSelector
export default useAppSelector