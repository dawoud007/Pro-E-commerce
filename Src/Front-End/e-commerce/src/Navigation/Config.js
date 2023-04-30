import { useContext } from "react";
import { AuthContext } from "../Custom/useAuth";
import { Layout } from "../Layout/Layout";
import { ABOUT, CART, ERROR, PRODUCT, ROOT, WISHLIST } from "./Paths";
import Home from "../Pages/Home/Home";
import ProductDetail from "../Components/ProductDetail/ProductDetail";
import About from "../Pages/About/About";
import Cart from "../Pages/Cart/Cart";
import WishList from "../Pages/WishList/WishList";
import ErrorPage from "../Pages/ErrorPage/ErrorPage";

const {currentUser} = useContext(AuthContext);

const ProtectedRoute = ({ children }) => {
    if (!currentUser) {
      return <Navigate to="/" />;
    }
    return children;
  };

  const router = createBrowserRouter([
    {
      path: ROOT,
      element: (
        <ProtectedRoute>
          <Layout />
        </ProtectedRoute>
      ),
      children: [
        {
          path: ROOT,
          element: Home,
        },
        {
          path: PRODUCT,
          element: ProductDetail,
        },
        {
          path: ABOUT,
          element: About,
        },
        {
          path: CART,
          element: Cart,
        },
        {
          path: WISHLIST,
          element: WishList,
        },
        {
          path: ERROR,
          element: ErrorPage,
        },
      ],
    },
  ]);
