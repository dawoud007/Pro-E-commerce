import React, { useContext, useEffect } from "react";
import { Nav, Navbar } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import "./naav.scss";
import { AiOutlineShoppingCart } from "react-icons/ai";
import { FiLogOut } from "react-icons/fi";
import { AuthContext } from "../../context/authContext";
import { getCookies } from "../../Custom/useCookies";
import { ShoppingCart } from "../../Redux/CartSlice";

const Naav = () => {
  const { products } = useSelector((state) => state.cart);
  const { logout } = useContext(AuthContext);
  const token = getCookies("token");
  const dispatch = useDispatch()
  useEffect(() => {
    dispatch(ShoppingCart({ token: token }));
  }, []);
  return (
    <>
      <Navbar expand="lg" className="navBar fixed-top">
        <Navbar.Brand>
          <NavLink to="/" className="navLink text-uppercase">
            TI&BT
          </NavLink>
        </Navbar.Brand>

        <Navbar.Collapse id="navbarScroll">
          <Nav className="ms-auto my-2 my-lg-0">
            <NavLink to="/" className="menuLink">
              Home
            </NavLink>

            <NavLink to="/about" className="menuLink">
              About
            </NavLink>

            <NavLink to="/cart" className="navLink cartIcon">
              <AiOutlineShoppingCart size={25} />{" "}
              <div className="cartLength">
                <h6>{products?.length}</h6>
              </div>
            </NavLink>
            <FiLogOut
              className="cartIcon"
              title="Log out"
              onClick={() => logout()}
              size={25}
              style={{color: "white", cursor: "pointer"}}
            />
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    </>
  );
};

export default Naav;
