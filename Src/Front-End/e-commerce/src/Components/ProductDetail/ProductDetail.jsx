import React, { memo, useEffect } from "react";
import { Breadcrumb } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "react-toastify";
import Loader from "../Loader/Loader";
import "./productdetail.css";
import { addToCart } from "../../Redux/CartSlice";
import { fetchProduct } from "../../Redux/ProductSlice";
import { STATUS } from "../../Helper/Status";

const ProductDetail = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { product, status, error } = useSelector((state) => state.products);

  useEffect(() => {
    dispatch(fetchProduct(id));
  }, []);

  if (status === STATUS.LOADING) {
    return <Loader />;
  }

  if (status === STATUS.ERROR) {
    return <h2>{error}</h2>;
  }

  const productHandler = () => {
    dispatch(addToCart(product));
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
            src={"data:image/png;base64," + product?.image}
            alt="product-img"
          />
        </div>

        <div className="content pt-3">
          <h4>{product?.title}</h4>
          <h6 className="text-success">
            {product?.rating?.count > 1 && "In Stock"}
          </h6>
          <h6>Category: {product?.category}</h6>
          <p className="py-1">{product?.description}</p>
          <h5>Price: ${product?.price}</h5>
          <button className="btn btn-primary mt-2" onClick={productHandler}>
            Add to Cart
          </button>
        </div>
      </div>
    </div>
  );
};

export default ProductDetail;
