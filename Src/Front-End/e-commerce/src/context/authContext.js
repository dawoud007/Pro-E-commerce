import axios from "axios";
import { createContext, useEffect, useState } from "react";
import { setCookies } from "../Custom/useCookies";

export const AuthContext = createContext();

const base_url = 'http://localhost:5002/api/v1/Authentication'

export const AuthContextProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useState(
    JSON.parse(localStorage.getItem("user")) || null
  );
  const [loading, setLoading] = useState(false)
  const login = async (data) => {
    try {
      setLoading(true)
      const response = await axios.post(`${base_url}/Login`, data)
      setCookies('token', response.data.token, 1)
      setCurrentUser(response.data);
      console.log(response.data);
      setLoading(false)
    } catch (error) {
      setLoading(false)
      console.log(error.response.data);
      setCurrentUser(error.response.data);
    }
  };
  const register = async (data) => {
    try {
      setLoading(true)
      const response = await axios.post(`${base_url}/Register`, data)
      setCurrentUser(response.data);
      console.log(response.data);
      setLoading(false)
    } catch (error) {
      setLoading(false)
      console.log(error.response.data);
      setCurrentUser(error.response.data);
    }
  };
  const logout = async () => {
    setCookies('token', '', 1)
    setCurrentUser(null);
  };

  useEffect(() => {
    localStorage.setItem("user", JSON.stringify(currentUser));
  }, [currentUser]);

  return (
    <AuthContext.Provider value={{ currentUser, login, logout, register, loading }}>
      {children}
    </AuthContext.Provider>
  );
};