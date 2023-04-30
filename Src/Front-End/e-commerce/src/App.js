import "./App.scss";
import Naav from "./Components/Nav/Naav";
import Home from "./Pages/Home/Home";
import Cart from "./Pages/Cart/Cart";
import Footer from "./Components/Footer/Footer";
import ErrorPage from "./Pages/ErrorPage/ErrorPage";
import ProductDetail from "./Components/ProductDetail/ProductDetail";
import About from "./Pages/About/About";

import { Navigate, Outlet, Route, RouterProvider, Routes, createBrowserRouter } from "react-router-dom";
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from "react-toastify";
import { useContext } from "react";
import { AuthContext } from "./context/authContext";
import Login from "./Pages/Login/Login";
import Register from "./Pages/Register/Register";
import { ABOUT, CART, ERROR, PRODUCT, ROOT } from "./Navigation/Paths";

function App() {

  const { currentUser } = useContext(AuthContext);

  const Layout = () => {
    return (
      <div >
        <Naav />
        <div style={{ display: "flex", flexDirection: "column"}}>
          <Outlet />
          <Footer />
        </div>
      </div>
    );
  };

  const ProtectedRoute = ({ children }) => {
    if (!currentUser?.token) {
      return <Navigate to="/login" />;
    }

    return children;
  };

  const router = createBrowserRouter([
    {
      path: "/",
      element: (
        <ProtectedRoute>
          <Layout />
        </ProtectedRoute>
      ),
      children: [
        {
          path: ROOT,
          element: <Home />,
        },
        {
          path: PRODUCT,
          element: <ProductDetail />,
        },
        {
          path: ABOUT,
          element: <About />,
        },
        {
          path: CART,
          element: <Cart />,
        },
        {
          path: ERROR,
          element: <ErrorPage />,
        },
      ],
    },
    {
      path: "/login",
      element: <Login />,
    },
    {
      path: "/register",
      element: <Register />,
    },
  ]);

  return (
    <div className="App">
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
