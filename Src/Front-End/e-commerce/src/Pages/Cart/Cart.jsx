import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import "./cart.css";
import EmptyCart from "../../Components/EmptyCart/EmptyCart";
import { toast } from "react-toastify";
import { RemoveAllFromCart, RemoveFromCart, ShoppingCart, decreaseProduct, increaseProduct } from "../../Redux/CartSlice";
import { getCookies } from "../../Custom/useCookies";

const Cart = () => {
  const dispatch = useDispatch();
  const { products, status } = useSelector((state) => state.cart);
  const [count, setCount] = useState(0)
  const token = getCookies("token");

  console.log(products);

  const totalPrice = products.reduce(
    (a, c) => a + c.count * c.price,
    0
  );

  useEffect(() => {
    dispatch(ShoppingCart({token: token}))
  }, [])

  const removeProductHandler = (product) => {
    console.log(product);
    const updatedItems = products.filter(item => item.id !== product.id);
    this.setState({items: updatedItems});
    dispatch(RemoveFromCart({id: product.id, token: token}));
    toast.warning(`${product.product.name.slice(0, 20)} is removed from cart`, {
      autoClose: 1000,
    });
  };

  const removeAllProduct = () => {
    dispatch(RemoveAllFromCart({token: token}));
    toast.error("Your Cart is now empty", {
      autoClose: 1000,
    });
  };

  const increasedProduct = (product) => {
    setCount(product.count + 1)
    dispatch(increaseProduct({id: product.id, token: token}));
    toast.success(`${product.product.name.slice(0, 20)} is added to cart`, {
      autoClose: 1000,
    });
  };

  const decreasedProduct = (product) => {
    setCount(product.count - 1)
    dispatch(decreaseProduct({id: product.id, token: token}));
    toast.warning(`${product.product.name.slice(0, 20)} is removed from cart`, {
      autoClose: 1000,
    });
  };

  if (products.length === 0) {
    return <EmptyCart />;
  }

  return (
    <div className="cart container py-5 mt-4">
      <h2 className="py-3 text-center">Cart Page</h2>

      {products?.map((product) => {
        return (
          <div key={product.product.id} className="cartCard">
            <div>
              <img src={"data:image/png;base64," + product?.product?.image} alt="product" width="50px" />
              
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
