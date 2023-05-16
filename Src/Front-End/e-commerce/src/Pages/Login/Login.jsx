import React, { useContext, useEffect, useState } from "react";
import "./Login.css";
import { AuthContext } from "../../context/authContext";
import { Link, useNavigate } from "react-router-dom";
import Loader from "../../Components/Loader/Loader";

function Login() {
  const { login, currentUser, loading } = useContext(AuthContext);
  const [username, setUsername] = useState();
  const [password, setPassword] = useState();
  const navigate = useNavigate();

  const handleLogin = (e) => {
    e.preventDefault();
    login({ userName: username, password: password });
  };

  useEffect(() => {
    currentUser?.token && navigate("/");
  }, [currentUser]);

  if (loading) {
    return <Loader />;
  }

  return (
    <div className="login">
      <div className="card">
        <div className="left">
          <h1>TI&BT</h1>
          <p>
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero cum,
            alias totam numquam ipsa exercitationem dignissimos, error nam,
            consequatur.
          </p>
          <span>Don't you have an account?</span>
          <Link to="/register">
            <button>Register</button>
          </Link>
        </div>
        <div className="right">
          <h1>Login</h1>
          <form onSubmit={handleLogin}>
            <input
              type="text"
              placeholder="Username"
              onChange={(x) => setUsername(x.target.value)}
            />
            <div>
              {currentUser?.errorMessages?.map((errorMsg) => {
                return <>{errorMsg.includes("username") ? errorMsg : null}</>;
              })}
            </div>
            <input
              type="password"
              placeholder="Password"
              onChange={(x) => setPassword(x.target.value)}
            />
            <div>
              {currentUser?.errorMessages?.map((errorMsg) => {
                return <>{errorMsg.includes("password") ? errorMsg : null}</>;
              })}
            </div>
            <button type="submit">Login</button>
            <div>
              {currentUser?.errorMessages?.map((errorMsg) => {
                return <>{errorMsg.includes("email") ? errorMsg : null}</>;
              })}
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Login;
