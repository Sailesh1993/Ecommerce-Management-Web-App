import React, { useEffect, useState } from "react";
import { Product } from "../types/Product";
import useAppDispatch from "../hooks/useAppDispatch";
import { Link, useNavigate } from "react-router-dom";
import useAppSelector from "../hooks/useAppSelector";
import {
  fetchAllProducts,
  sortByPrice,
} from "../redux/reducers/productsReducer";
import { Box, Button, Grid, TextField, Typography } from "@mui/material";
import { fetchAllCategories } from "../redux/reducers/categorysReducer";
import useDebounce from "../hooks/useDebounce";

/* const getFilteredList = (products: Product[], search: string) => {
    return products.filter((product) => 
        product.title.toLowerCase().includes(search.toLowerCase())
    )
} */
const ProductList = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchAllProducts());
    dispatch(fetchAllCategories());
  }, [dispatch]);
  const navigate = useNavigate();

  const [page, setPage] = useState(1);
  const [itemOffset, setItemOffset] = useState(0);
  const [itemsPerPage, setItemsPerPage] = useState(24);
  const [sort, setSort] = useState<number>(0);
  const { products, loading } = useAppSelector(
    (state) => state.productsReducer
  );
  useEffect(() => {
    if (products.length > 0) {
      setItemOffset(((page - 1) * itemsPerPage) % products.length);
    }
  }, [page]);
  const [category, setCategory] = useState<string>("show all");
  /* const [search, setSearch] = useState<string>('')
    const filterProducts = getFilteredList(products, search)
    const onSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value)
    } */
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
  };
  const searchDebounce = useDebounce<Product>(filterFunc, productsOfCategory);
  useEffect(() => {
    setPage(1);
  }, [searchDebounce.search, category]);
  const pageCount = Math.ceil(
    searchDebounce.filteredItems.length / itemsPerPage
  );
  const endOffset = itemOffset + itemsPerPage;
  const displayItem = searchDebounce.filteredItems.slice(itemOffset, endOffset);
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value);
  };

  const sortByPriceDynamic = () => {
    dispatch(sortByPrice(sort));
    setSort(sort === 0 ? 1 : 0);
  };
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
          id="filled-basic"
          label="Filled"
          variant="filled"
          type="text"
          value={searchDebounce.search}
          placeholder="Search Product"
          onChange={searchDebounce.handleChange}
        />
        <Button variant="contained" size="large" onClick={sortByPriceDynamic}>
          Sort Price
        </Button>
      </div>
      
      <div>
        <Button variant="contained" onClick={() => navigate("/newProduct")}>
          Create New Product
        </Button>
        <Button variant="contained" onClick={() => navigate("/updateProduct")}>
          Update Product
        </Button>
        <Button variant="contained" onClick={() => navigate("/deleteProduct")}>
          Delete Product
        </Button>
        <Button variant="contained" onClick={() => navigate("/newcategory")}>
          Create New Category
        </Button>
      </div>
      <br />
      <Grid container spacing={2}>
        {displayItem.map((product) => (
          <Grid item xs={4} key={product.id}>
            <Box
              sx={{
                border: "1px solid lightblue",
                borderRadius: "8px",
                padding: "1rem",
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "center",
              }}
            >
              <Typography variant="h6" gutterBottom>
                {product.title}
              </Typography>
              <img
                width={640 * 0.75}
                height={640 * 0.75}
                src={
                  product.images && product.images.length > 0
                    ? product.images[0]
                    : ""
                }
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
    </div>
  );
};

export default ProductList;
