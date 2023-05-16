import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { STATUS } from "../Helper/Status";
const base_url = "http://localhost:5001/Cart";


const initialState = {
  products: [],
  status: "",
};



export const addToCart = createAsyncThunk("cart/post", async (payload) => {
  console.log(payload);
  try {
    console.log(payload.data);
    const data = { "productId": payload.data.id }
    console.log(data);
    const response = await axios.post(`${base_url}/Post`, data, {
      headers: {
        Authorization: `Bearer ${payload.token}`
      }
    })
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error);
    return error.message
  }
});

export const ShoppingCart = createAsyncThunk("cart/shoppingcart", async (payload) => {
  console.log(payload);
  try {
    const response = await axios.get(`${base_url}/ShoppingCart`, {
      headers: {
        Authorization: `Bearer ${payload.token}`
      }
    })
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error);
    return error.message
  }
});

export const RemoveFromCart = createAsyncThunk("cart/removefromcart", async (payload) => {
  console.log(payload);
  try {
    const response = await axios.post(`${base_url}/RemoveFromCart?CartID=${payload.id}`, {
      headers: {
        Authorization: `Bearer ${payload.token}`
      }
    })
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error);
    return error.message
  }
});

export const RemoveAllFromCart = createAsyncThunk("cart/removeAllfromCart", async (payload) => {
  console.log(payload);
  try {
    const response = await axios.post(`${base_url}/removeAllfromCart`, {
      headers: {
        Authorization: `Bearer ${payload.token}`
      }
    })
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error);
    return error.message
  }
});

export const increaseProduct = createAsyncThunk("cart/increaseproduct", async (payload) => {
  console.log(payload);
  try {
    const response = await axios.post(`${base_url}/Plus?cartId=${payload.id}`, {
      headers: {
        Authorization: `Bearer ${payload.token}`
      }
    })
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error);
    return error.message
  }
});

export const decreaseProduct = createAsyncThunk("cart/decreaseproduct", async (payload) => {
  console.log(payload);
  try {
    const response = await axios.post(`${base_url}/Minus?cartId=${payload.id}`, {
      headers: {
        Authorization: `Bearer ${payload.token}`
      }
    })
    console.log(response.data);
    return response?.data
  } catch (error) {
    console.log(error);
    return error.message
  }
});

export const CartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(addToCart.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(addToCart.fulfilled, (state, action) => {
        state.products.push(action.payload);
        state.status = STATUS.IDLE;
      })
      .addCase(addToCart.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
    // /////////////////////////////////////////////////////
      .addCase(ShoppingCart.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(ShoppingCart.fulfilled, (state, action) => {
        state.products = action.payload;
        state.status = STATUS.IDLE;
      })
      .addCase(ShoppingCart.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
    // /////////////////////////////////////////////////////
      .addCase(RemoveFromCart.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(RemoveFromCart.fulfilled, (state, action) => {
        // state.cart = action.payload;
        state.status = STATUS.IDLE;
      })
      .addCase(RemoveFromCart.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
    // /////////////////////////////////////////////////////
      .addCase(RemoveAllFromCart.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(RemoveAllFromCart.fulfilled, (state, action) => {
        state.status = STATUS.IDLE;
      })
      .addCase(RemoveAllFromCart.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
    // /////////////////////////////////////////////////////
      .addCase(increaseProduct.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(increaseProduct.fulfilled, (state, action) => {
        state.status = STATUS.IDLE;
      })
      .addCase(increaseProduct.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
    // /////////////////////////////////////////////////////
      .addCase(decreaseProduct.pending, (state, action) => {
        state.status = STATUS.LOADING;
      })
      .addCase(decreaseProduct.fulfilled, (state, action) => {
        // state.cart = action.payload;
        state.status = STATUS.IDLE;
      })
      .addCase(decreaseProduct.rejected, (state, action) => {
        state.error = action.payload
        state.status = STATUS.ERROR;
      })
    // /////////////////////////////////////////////////////
  },
});


export default CartSlice.reducer;
