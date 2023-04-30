import { Button, Card } from "react-bootstrap";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import './productCard.css'
import { toast } from "react-toastify";
import { addToCart } from "../../Redux/CartSlice";
import { getCookies } from "../../Custom/useCookies";

const ProductCard = ({ product }) => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const token = getCookies('token')


  const addProduct = () => {
    dispatch(addToCart(product));
    toast.success(`${product?.title.slice(0, 20)} is added to cart`, {
      autoClose: 1000,
    });
  };

  return (
    <div>
      <Card className='productCard'>
        
        <Card.Img
          onClick={() => navigate(`/products/${product?.id}`)}
          src={'data:image/png;base64,' + product?.image}
          className='cardImg'
        />

        <Card.Body>
          <Card.Title>{product?.name.slice(0, 20)}</Card.Title>
          <Card.Text>${product?.price}</Card.Text>
          <Button className='commonBtn' onClick={() => {dispatch(addToCart({token: token, data: product}))}}>
            ADD TO CART
          </Button>
        </Card.Body>

      </Card>
    </div>
  );
};

export default ProductCard;
