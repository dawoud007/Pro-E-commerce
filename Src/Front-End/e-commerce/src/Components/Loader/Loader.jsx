import React from "react";
import Spinner from 'react-bootstrap/Spinner';
import './Loader.css'

const Loader = () => {
  return (
    <div className="spinner">
      <Spinner animation="border" role="status">
        <span className="visually-hidden">Loading...</span>
      </Spinner>
    </div>
  );
};

export default Loader;
