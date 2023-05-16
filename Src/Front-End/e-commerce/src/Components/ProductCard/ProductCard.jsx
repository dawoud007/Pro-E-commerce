import { Button, Card } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import './productCard.css'
import { toast } from "react-toastify";
import { addToCart, increaseProduct } from "../../Redux/CartSlice";
import { getCookies } from "../../Custom/useCookies";
import noitem from '../../assests/360_F_251955356_FAQH0U1y1TZw3ZcdPGybwUkH90a3VAhb.jpg'

const ProductCard = ({ product }) => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const token = getCookies('token')
  const { products } = useSelector((state) => state.cart);



  const productHandler = (id) => {
    const idArr = products.map(obj => obj.productId);
    const cart = products.find((cart) => cart.productId == id)
    idArr.includes(id) ? dispatch(increaseProduct({token: token, id: cart.id})) : dispatch(addToCart({token: token, data: id}))
    
    toast.success(`${product?.name.slice(0, 20)} is added to cart`, {
      autoClose: 1000,
    });
  };

  return (
    <div>
      <Card className='productCard'>
        
        <Card.Img
          onClick={() => navigate(`/products/${product?.id}`)}
          src={ product.image ? 'data:image/png;base64,' + product?.image : noitem}
          className='cardImg'
        />

        <Card.Body>
          <Card.Title>{product?.name.slice(0, 20)}</Card.Title>
          <Card.Text>${product?.price}</Card.Text>
          <Button className='commonBtn' onClick={() => productHandler(product.id)}>
            ADD TO CART
          </Button>
        </Card.Body>

      </Card>
    </div>
  );
};

export default ProductCard;
