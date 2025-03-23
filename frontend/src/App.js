import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/Login';
import EntityList from './components/EntityList';
import EntityForm from './components/EntityForm';
import Header from './components/Header';
import { AuthProvider, useAuth } from './context/AuthContext';
import './App.css';

const ProtectedRoute = ({ children }) => {
  const { isAuthenticated } = useAuth();
  return isAuthenticated ? children : <Navigate to="/login" />;
};

function App() {
  return (
    <AuthProvider>
      <Router>
        <div className="app">
          <Header />
          <div className="container">
            <Routes>
              <Route path="/login" element={<Login />} />
              <Route path="/" element={
                <ProtectedRoute>
                  <EntityList />
                </ProtectedRoute>
              } />
              <Route path="/entities/new" element={
                <ProtectedRoute>
                  <EntityForm />
                </ProtectedRoute>
              } />
              <Route path="/entities/edit/:id" element={
                <ProtectedRoute>
                  <EntityForm />
                </ProtectedRoute>
              } />
            </Routes>
          </div>
        </div>
      </Router>
    </AuthProvider>
  );
}

export default App;