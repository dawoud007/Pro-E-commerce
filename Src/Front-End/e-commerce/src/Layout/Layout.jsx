import Footer from "../Components/Footer/Footer";
import Naav from "../Components/Nav/Naav";
import "./Layout.css";
import { Outlet } from "react-router-dom";

export const Layout = () => {
  return (
    <>
      <Naav />
      <div className="layoutContainer">
        <Outlet />
        <Footer />
      </div>
    </>
  );
};
