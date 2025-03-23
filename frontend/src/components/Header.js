import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import logo from '../assets/footer-logo.png';

const Header = () => {
  const { isAuthenticated, logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  return (
    <header className="header">
      <div className="logo-container">
        <img src={logo} alt="Logo" className="logo" />
      </div>
      <div className="title-container">
        <h1>Entidades Gubernamentales</h1>
      </div>
      {isAuthenticated && (
        <div className="nav-links">
          <Link to="/" className="nav-link">Inicio</Link>
          <Link to="/entities/new" className="nav-link">Crear Nueva Entidad</Link>
          <button onClick={handleLogout} className="logout-button">Cerrar Sesión</button>
        </div>
      )}
    </header>
  );
};

export default Header;