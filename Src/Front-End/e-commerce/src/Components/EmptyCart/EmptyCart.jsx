import React from "react";
import { useNavigate } from "react-router-dom";
import cart from "../../assests/cart.png";
import './emptycart.css';

const EmptyCart = () => {
  const navigate = useNavigate();
  return (
    <div className='emptyCart'>
      <img src={cart} alt="empty-cart-img" />
      <button className="btn btn-primary" onClick={() => navigate("/")}>
        Go Back to Add Some Products
      </button>
    </div>
  );
};

export default EmptyCart;
