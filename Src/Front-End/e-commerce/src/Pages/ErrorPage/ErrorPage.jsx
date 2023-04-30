import React from "react";
import notfound from "../../assests/notfound.png";
import { useNavigate } from "react-router-dom";
import './errorpage.css'

const ErrorPage = () => {
  const navigate = useNavigate()
  return (
    <div className='error'>
      <img src={notfound} alt="Not found" />
      <button className="btn btn-primary" onClick={() => navigate("/")}>
        Go Back to Home
      </button>
    </div>
  );
};

export default ErrorPage;
