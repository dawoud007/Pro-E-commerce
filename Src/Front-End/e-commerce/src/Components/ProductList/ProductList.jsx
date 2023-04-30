import React, { useEffect, useState } from "react";
import { Container } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import ProductCard from "../ProductCard/ProductCard";
import Loader from "../Loader/Loader";
import { BiSearch } from "react-icons/bi";
import {
  fetchProducts,
  fetchProductsByCategory,
} from "../../Redux/ProductSlice";
import "./productlist.css";
import { STATUS } from "../../Helper/Status";

const ProductList = ({ category }) => {
  const [showSearch, setShowSearch] = useState(false);
  const [searchValue, setSearchValue] = useState("");
  const dispatch = useDispatch();
  const { products, status, error } = useSelector((state) => state.products);

  useEffect(() => {
    !category && dispatch(fetchProducts());
    category && dispatch(fetchProductsByCategory(category));
  }, [category]);

  if (status === STATUS.LOADING) {
    return <Loader />;
  }

  if (status === STATUS.ERROR) {
    return <h2>{error}</h2>;
  }

  return (
    <div className="productListWrapper" id="product-list">
      <Container>
        <div className="searchWrapper">
          <div>
            <h3>Shop by Collection</h3>
            <p>
              Each season, we collaborate with world class designers to create a
              collection inspired by natural world.
            </p>
          </div>

          <div>
            {showSearch && (
              <input
                type="text"
                className="searchBar"
                value={searchValue}
                onChange={(e) => setSearchValue(e.target.value)}
                placeholder="Search Product"
              />
            )}
            <BiSearch size={25} onClick={() => setShowSearch(!showSearch)} />
          </div>
        </div>

        <div className="productList">
          {products
            ?.filter((item) =>
              item.name.toLowerCase().includes(searchValue.toLowerCase())
            )
            ?.map((product) => {
              return <ProductCard key={product?.id} product={product} />;
            })}
        </div>
      </Container>
    </div>
  );
};

export default ProductList;
