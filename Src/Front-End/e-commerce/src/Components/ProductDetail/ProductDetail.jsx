import React, { memo, useEffect } from "react";
import { Breadcrumb } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "react-toastify";
import Loader from "../Loader/Loader";
import "./productdetail.css";
import { ShoppingCart, addToCart, increaseProduct } from "../../Redux/CartSlice";
import { fetchProduct } from "../../Redux/ProductSlice";
import { STATUS } from "../../Helper/Status";
import { getCookies } from "../../Custom/useCookies";
import noitem from '../../assests/360_F_251955356_FAQH0U1y1TZw3ZcdPGybwUkH90a3VAhb.jpg'


const ProductDetail = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { product, status, error } = useSelector((state) => state.products);
  const { products } = useSelector((state) => state.cart);
  const token = getCookies('token')


  useEffect(() => {
    dispatch(fetchProduct(id));
    dispatch(ShoppingCart({token: token}))
  }, []);

  if (status === STATUS.LOADING) {
    return <Loader />;
  }

  if (status === STATUS.ERROR) {
    return <h2>{error}</h2>;
  }

  const productHandler = (id) => {
    const idArr = products.map(obj => obj.productId);
    const cart = products.find((cart) => cart.productId == id)
    idArr.includes(id) ? dispatch(increaseProduct({token: token, id: cart.id})) : dispatch(addToCart({token: token, data: id}))
    
    toast.success(`${product?.name.slice(0, 20)} is added to cart`, {
      autoClose: 1000,
    });
  };

  return (
    <div className="detailWrapper container py-4">
      <Breadcrumb>
        <Breadcrumb.Item onClick={() => navigate("/")}>Home</Breadcrumb.Item>
        <Breadcrumb.Item active>{product?.name}</Breadcrumb.Item>
      </Breadcrumb>

      <h1>{product?.name}</h1>

      <hr className="mb-4" />

      <div className="mainDetailWrapper">
        <div className="imageWrapper">
          <img
            src={product.image ? "data:image/png;base64," + product?.image : noitem}
            alt="product-img"
          />
        </div>

        <div className="content pt-3">
          <h4>{product?.title}</h4>
          <h6 className="text-success">
            {product?.rating?.count > 1 && "In Stock"}
          </h6>
          <h6>Category: {product?.categoryName}</h6>
          <p className="py-1">{product?.description}</p>
          <h5>Price: ${product?.price}</h5>
          <button className="btn btn-primary mt-2" onClick={() => productHandler(product.id)}>
            Add to Cart
          </button>
        </div>
      </div>
    </div>
  );
};

export default ProductDetail;
