import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { STATUS } from "../Helper/Status";
const base_url = "http://localhost:5001/Product";

const initialState = {
  status: "",
  products: [],
  productsByCategory: [],
  product: {},
  error: "",
};

export const fetchProducts = createAsyncThunk("products/getprodcuts", async () => {
  try {
    const response = await axios.get(`${base_url}/Get`)
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error.message);
    return error.message
  }
});

export const fetchProductsByCategory = createAsyncThunk("products/getprodcutsbycategory", async (payload) => {
  try {
    const response = await axios.get(`${base_url}/FetchProductsByCategory?category=${payload}`)
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error.message);
    return error.message
  }
});

export const fetchProduct = createAsyncThunk("products/getprodcut", async (payload) => {
  try {
    const response = await axios.get(`${base_url}/Get/${payload}`)
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error.message);
    return error.message
  }
});

const productSlice = createSlice({
  name: "products",
  initialState,
  extraReducers: (builder) => {
    builder
      .addCase(fetchProducts.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(fetchProducts.fulfilled, (state, action) => {
        state.products = action.payload;
        state.status = STATUS.IDLE;
      })
      .addCase(fetchProducts.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
      // /////////////////////////////////////////////////////
      .addCase(fetchProductsByCategory.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(fetchProductsByCategory.fulfilled, (state, action) => {
        state.products = action.payload;
        state.status = STATUS.IDLE;
      })
      .addCase(fetchProductsByCategory.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
      // //////////////////////////////////////////////////////////
      .addCase(fetchProduct.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(fetchProduct.fulfilled, (state, action) => {
        state.product = action.payload;
        state.status = STATUS.IDLE;
      })
      .addCase(fetchProduct.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      });
  },
});


export default productSlice.reducer;
