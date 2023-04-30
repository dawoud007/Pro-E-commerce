import React from "react";
import './Footer.css'
const Footer = () => {
  const year = new Date().getFullYear();
  return (
    <div className='footer'>
      Copyright © {year} - Designed By 
      <span onClick={() => window.location.replace('https://github.com/Micheal-Soliman')}>Micheal Soliman</span>
    </div>
  );
};

export default Footer;
