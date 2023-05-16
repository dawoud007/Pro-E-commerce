import React from "react";
import cat1 from "../../assests/cat1.webp";
import cat2 from "../../assests/cat2.webp";
import cat3 from "../../assests/cat3.webp";
import cat4 from "../../assests/cat4.webp";
import cat5 from "../../assests/cat5.png";
import './category.css'

const Caterogry = ({ setCategory }) => {
  const Categories = [
    {
      img: cat5,
      name: "",
      title: "All",
      id: 0,
    },
    {
      img: cat1,
      name: "electronics",
      title: "electronics",
      id: 1,
    },
    {
      img: cat2,
      name: "jewelery",
      title: "jewelery",
      id: 2,
    },
    {
      img: cat3,
      name: "men's clothing",
      title: "men's clothing",
      id: 3,
    },
    {
      img: cat4,
      name: "women's clothing",
      title: "women's clothing",
      id: 4,
    },
  ];
  return (
    <div className="pt-5 container">

      <h3 className="py-2">Shop by Caterogry</h3>

      <div className='categoryWrapper'>

        {Categories.map((Category) => {
          return (

            <div key={Category.id} className="category" onClick={() => setCategory(Category.name)} style={{
              background: `linear-gradient(rgba(20,20,20, 0.3),rgba(20,20,20, .3)), url(${Category.img}) no-repeat`,
              backgroundSize: "cover",
              backgroundPosition: "center",
            }} >

              <h5 className="text-white px-3">
                {Category.title.toUpperCase()}
              </h5>

            </div>

          );
        })}

      </div>

    </div>
  );
};

export default Caterogry;
