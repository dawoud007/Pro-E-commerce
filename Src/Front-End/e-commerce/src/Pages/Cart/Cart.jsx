import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import "./cart.css";
import EmptyCart from "../../Components/EmptyCart/EmptyCart";
import { toast } from "react-toastify";
import noitem from '../../assests/360_F_251955356_FAQH0U1y1TZw3ZcdPGybwUkH90a3VAhb.jpg'
import {
  RemoveAllFromCart,
  RemoveFromCart,
  ShoppingCart,
  decreaseProduct,
  increaseProduct,
} from "../../Redux/CartSlice";
import { getCookies } from "../../Custom/useCookies";

const Cart = () => {
  const dispatch = useDispatch();
  const { products, status } = useSelector((state) => state.cart);
  const [listProducts, setListProducts] = useState([]);
  const [count, setCount] = useState(0);
  const token = getCookies("token");

  console.log(products);

  const totalPrice = listProducts.reduce((a, c) => a + c.count * c.price, 0);

  useEffect(() => {
    dispatch(ShoppingCart({ token: token }));
  }, []);

  useEffect(() => {
    setListProducts(products);
  }, [products]);

  const removeProductHandler = (product) => {
    const newCarts = listProducts.filter((item) => item.id != product.id);
    setListProducts(newCarts);
    dispatch(RemoveFromCart({ id: product.id, token: token }));
    toast.warning(`${product.product.name.slice(0, 20)} is removed from cart`, {
      autoClose: 1000,
    });
  };

  const increasedProduct = (product) => {
    const cartIndex = listProducts.findIndex((item) => item.id === product.id);
    if (cartIndex !== -1) {
      const updatedCart = { ...listProducts[cartIndex], count: listProducts[cartIndex].count + 1 };
      const newList = [...listProducts];
      newList.splice(cartIndex, 1, updatedCart);
      setListProducts(newList);
    }

    dispatch(increaseProduct({ id: product.id, token: token }));
    toast.success(`${product.product.name.slice(0, 20)} is added to cart`, {
      autoClose: 1000,
    });
  };

  const decreasedProduct = (product) => {
    const cart = listProducts.find((item) => item.id === product.id);
    if (cart.count > 1) {
      const cartIndex = listProducts.findIndex((item) => item.id === product.id);
      if (cartIndex !== -1) {
        const updatedCart = { ...listProducts[cartIndex], count: listProducts[cartIndex].count - 1 };
        const newList = [...listProducts];
        newList.splice(cartIndex, 1, updatedCart);
        setListProducts(newList);
      }
    } else {
      const newCarts = listProducts.filter((item) => item.id != product.id);
      setListProducts(newCarts);
    }

    dispatch(decreaseProduct({ id: product.id, token: token }));
    toast.warning(`${product.product.name.slice(0, 20)} is removed from cart`, {
      autoClose: 1000,
    });
  };

  if (listProducts.length === 0) {
    return <EmptyCart />;
  }

  return (
    <div className="cart container py-5 mt-4">
      <h2 className="py-3 text-center">Cart Page</h2>

      {listProducts?.map((product) => {
        return (
          <div key={product.product.id} className="cartCard">
            <div>
              <img
                src={ product?.product?.image ? "data:image/png;base64," + product?.product?.image : noitem}
                alt="product"
                width="50px"
              />
            </div>

            <div>
              <h5 style={{ maxWidth: "180px" }}>
                {product?.product?.name?.slice(0, 20)}
              </h5>
              <h6>${product.price}</h6>
            </div>

            <div className="cartBtns">
              <button
                className="cartBtn fw-bold"
                onClick={() => increasedProduct(product)}
              >
                +
              </button>

              <h6>{product.count}</h6>

              <button
                className="cartBtn fw-bold"
                onClick={() => decreasedProduct(product)}
              >
                -
              </button>
            </div>

            <div>
              <h6>${(product.price * product.count).toFixed(2)}</h6>

              <button
                className="btn btn-danger"
                onClick={() => {
                  removeProductHandler(product);
                }}
              >
                remove
              </button>
            </div>
          </div>
        );
      })}

      <hr />

      <div className="mb-5 d-flex justify-content-between">
        <h5>
          Total Price: <b>${totalPrice.toFixed(2)}</b>
        </h5>
      </div>
    </div>
  );
};

export default Cart;
