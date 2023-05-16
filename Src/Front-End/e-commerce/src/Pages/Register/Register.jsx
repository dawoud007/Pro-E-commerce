import React, { useContext, useEffect, useState } from "react";
import "./Register.css";
import { Link, useNavigate } from "react-router-dom";
import { AuthContext } from "../../context/authContext";

function Register() {
  const [username, setUsername] = useState()
  const [name, setName] = useState()
  const [email, setEmail] = useState()
  const [password, setPassword] = useState()
  const [gender, setGender] = useState()
  const navigate = useNavigate()
  const {register, currentUser} = useContext(AuthContext)
  
  const handleSubmit = (e) => {
    e.preventDefault()
    register({name: name, email: email, password: password, userName: username, gender: Number(gender)})
  }

  useEffect(() => {
    currentUser?.isSuccess && navigate('/')
  }, [currentUser])

  return (
    <div className="register">
      <div className="card">
        <div className="left">
          <h1>TI&BT</h1>
          <p>
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero cum,
            alias totam numquam ipsa exercitationem dignissimos, error nam,
            consequatur.
          </p>
          <span>Do you have an account?</span>
          <Link to="/login">
            <button>Login</button>
          </Link>
        </div>
        <div className="right">
          <h1>Register</h1>
          <form onSubmit={handleSubmit}>
            <input type="text" placeholder="Username" onChange={(x) => setUsername(x.target.value)} />
            <div>{currentUser?.errorMessages.map((errorMsg) => {
              return(
                <>{errorMsg.includes("Username") ? errorMsg : null}</>
              )
            })}</div>
            <input type="email" placeholder="Email" onChange={(x) => setEmail(x.target.value)} />
            <div>{currentUser?.errorMessages.map((errorMsg) => {
              return(
                <>{errorMsg.includes("Email") ? errorMsg : null}</>
              )
            })}</div>
            <input type="password" placeholder="Password" onChange={(x) => setPassword(x.target.value)} />
            <input type="text" placeholder="Name" onChange={(x) => setName(x.target.value)} />
            <select onChange={(x) => setGender(x.target.value)}>
              <option value={null}>Select Gender</option>
              <option value={0}>Male</option>
              <option value={1}>Female</option>
            </select>
            <button type='submit' >Register</button>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Register;
