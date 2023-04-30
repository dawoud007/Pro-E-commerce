import React, { useState } from "react";
import ProductList from "../../Components/ProductList/ProductList";
import Slider from "../../Components/Slider/Slider";
import Caterogry from "../../Components/Category/Caterogry";
import './Home.css'

const Home = () => {
  const [category, setCategory] = useState('')
  return (
    <div className='mainWrapper'>
      <Slider />
      <Caterogry setCategory={setCategory} />
      <ProductList category={category} />
    </div>
  );
};

export default Home;
