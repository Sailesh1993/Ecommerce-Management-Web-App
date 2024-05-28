import React, { useEffect, useState } from "react";
import { Product } from "../types/Product";
import useAppDispatch from "../hooks/useAppDispatch";
import useAppSelector from "../hooks/useAppSelector";
import {
  fetchAllProducts, sortProductsByPrice
} from "../redux/reducers/productsReducer";
import { Box, Button, Container, Grid, Input, Pagination} from "@mui/material";
import { fetchAllCategories } from "../redux/reducers/categorysReducer";
import useDebounce from "../hooks/useDebounce";
import Loading from "../pages/Loading";
import ArrowDropDownIcon from "@mui/icons-material/ArrowDropDown"
import ArrowDropUpIcon from "@mui/icons-material/ArrowDropUp"
import GridProducts from "./GridProducts";

const ProductList = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchAllProducts());
    dispatch(fetchAllCategories());
  }, [dispatch]);

  const [page, setPage] = useState(1);
  const [itemOffset, setItemOffset] = useState(0);
  const [itemsPerPage] = useState(4);
  const [priceSort, setPriceSort] = useState<boolean>(true);
  const { products, loading} = useAppSelector(
    (state) => state.productsReducer
  );
  useEffect(() => {
    if (products.length > 0) {
      setItemOffset(((page - 1) * itemsPerPage) % products.length);
    }
  }, [page, itemsPerPage, products.length]);
  const [category, setCategory] = useState<string>("show all");
  const { categories } = useAppSelector((state) => state.categorysReducer);
  const categoryList = categories.map((item) => item.name);
  categoryList.push("Show all");
  const handleCategoryClick = (item: string) => setCategory(item);
  const productsOfCategory = products.filter((item) =>
    category === "Show all"
      ? item
      : item.category.name === category
      ? item
      : null
  );

  const filterFunc = (filter: string, products: Product[]): Product[] => {
    return products.filter((item) =>
      item.title.toLowerCase().includes(filter.toLowerCase())
    );
  }
  const searchDebounce = useDebounce<Product>(filterFunc, productsOfCategory)
  useEffect(() => {
    setPage(1);
  }, [searchDebounce.search, category])
  const pageCount = Math.ceil(
    searchDebounce.filteredItems.length / itemsPerPage
  );
  const endOffset = itemOffset + itemsPerPage
  const displayItem = searchDebounce.filteredItems.slice(itemOffset, endOffset)
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value)
  }
  if(loading) return <Loading />
  const sortByPriceHandler = () => {
    priceSort
      ? dispatch(sortProductsByPrice("asc"))
      : dispatch(sortProductsByPrice("dsc"))
    setPriceSort((state) => !state)
  };
  return (
    <Container
      maxWidth="lg"
      sx={{
        padding: "6em 0",
        minHeight: "80vh",
        display: "flex",
        flexDirection: "column",
      }}
    >
      <Box sx={{ display: "flex", gap: 2, marginBottom: 3, fontSize: 1, overflow: "auto" }}>
        {categoryList.map((item) => (
          <Button
            onClick={() => handleCategoryClick(item)}
            
            color="primary"
            key={item}
            sx={{ fontSize: 12}}
          >
            {item}
          </Button>
        ))}
      </Box>
      <Box sx={{ display: "flex", gap: 2, marginBottom: 3 }}>
        <Input
        fullWidth
          onChange={searchDebounce.handleChange}
          value={searchDebounce.search}
          placeholder="Search Product"
          sx={{ maxWidth: 950 }}
        />
        <Button
          onClick={sortByPriceHandler}
          variant="outlined"
          color="primary"
        >
          {" "}
          Sort by price{" "}
          {priceSort ? <ArrowDropUpIcon /> : <ArrowDropDownIcon />}
        </Button>
      </Box>
      <Grid
        container
        spacing={2}
        sx={{
          marginTop: 8,
          marginBottom: 4,
        }}
      >
        {displayItem.map((item) => (
          <GridProducts key={item.id} product={item} />
        ))}
      </Grid>
      <Pagination
        page={page}
        count={pageCount}
        onChange={(e, value) => handleChange(e, value)}
        sx={{
          alignSelf: "center",
        }}
      />
    </Container>
  );
};

export default ProductList;
