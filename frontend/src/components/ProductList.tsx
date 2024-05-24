import React, { useEffect, useState } from "react";
import { Product } from "../types/Product";
import useAppDispatch from "../hooks/useAppDispatch";
import { Link} from "react-router-dom";
import useAppSelector from "../hooks/useAppSelector";
import {
  fetchAllProducts,
  sortByPrice,
} from "../redux/reducers/productsReducer";
import { Box, Button, Grid, Pagination, TextField, Typography } from "@mui/material";
import { fetchAllCategories } from "../redux/reducers/categorysReducer";
import useDebounce from "../hooks/useDebounce";

const ProductList = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchAllProducts());
    dispatch(fetchAllCategories());
  }, [dispatch]);

  const [page, setPage] = useState(1);
  const [itemOffset, setItemOffset] = useState(0);
  const [itemsPerPage] = useState(4);
  const [sort, setSort] = useState<number>(0);
  const { products} = useAppSelector(
    (state) => state.productsReducer
  );
  useEffect(() => {
    if (products.length > 0) {
      setItemOffset(((page - 1) * itemsPerPage) % products.length);
    }
  }, [page]);
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

  const sortByPriceDynamic = () => {
    dispatch(sortByPrice(sort))
    setSort(sort === 0 ? 1 : 0)
  }
  return (
    <div>
      <br />
      <div>
      <Box
        sx={{
          display: "flex",
          gap: 2,
          marginBottom: 3,
          fontSize: 1,
          overflow: "auto",
        }}
      >
        {categoryList.map((item) => (
          <Button
            onClick={() => handleCategoryClick(item)}
            color="primary"
            key={item}
            sx={{ fontSize: 12 }}
          >
            {item}
          </Button>
        ))}
      </Box>
        <TextField
          id="search-product"
          label="Search Product"
          variant="filled"
          type="text"
          value={searchDebounce.search}
          onChange={searchDebounce.handleChange}
          sx={{marginBottom: 3}}
        /> 
        <Button variant="contained" size="medium" sx={{margin: 2}}onClick={sortByPriceDynamic}>
          Sort Price
        </Button>
      </div>
      <Grid container spacing={2}>
        {displayItem.map((product) => (
          <Grid item xs={12} sm={6} md={4} lg={3} key={product.id}>
            <Box
              sx={{
                border: "1px solid lightblue",
                borderRadius: "8px",
                padding: "1rem",
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "center",
                height: "400px"
              }}
            >
              <Typography variant="h6" gutterBottom>
                {product.title}
              </Typography>
              <img
                style={{
                  width: "100%",
                  height: "200px", 
                  objectFit: "cover",
                }}
                src={product.images && product.images.length > 0 ? product.images[0] : ""}
                alt={product.title}
              />
              <Typography variant="body1" gutterBottom>
                {product.price} €
              </Typography>
              <div>
                <Link to={`/products/${product.id}`}>
                  <Button variant="outlined">Details</Button>
                </Link>
              </div>
            </Box>
          </Grid>
        ))}
      </Grid>
      <Box sx={{ display: "flex", justifyContent: "center", marginTop: 4 }}>
        <Pagination count={pageCount} page={page} onChange={handleChange} />
      </Box>
    </div>
  );
};

export default ProductList;
