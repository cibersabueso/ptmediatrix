import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { useAuth } from '../context/AuthContext';

const EntityForm = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const { token } = useAuth();
  const isEditing = !!id;

  const [formData, setFormData] = useState({
    name: '',
    acronym: '',
    description: '',
    address: '',
    phoneNumber: '',
    email: '',
    website: '',
    isActive: true
  });
  const [loading, setLoading] = useState(isEditing);
  const [error, setError] = useState('');

  useEffect(() => {
    if (isEditing) {
      fetchEntity();
    }
  }, [id]);

  const fetchEntity = async () => {
    try {
      const response = await axios.get(`http://localhost:5000/api/governmententities/${id}`, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      setFormData(response.data);
      setLoading(false);
    } catch (err) {
      console.error('Error fetching entity:', err);
      setError('Error al cargar los datos de la entidad');
      setLoading(false);
    }
  };

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData({
      ...formData,
      [name]: type === 'checkbox' ? checked : value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');

    try {
      if (isEditing) {
        await axios.put(`http://localhost:5000/api/governmententities/${id}`, formData, {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
      } else {
        await axios.post('http://localhost:5000/api/governmententities', formData, {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
      }
      navigate('/');
    } catch (err) {
      console.error('Error saving entity:', err);
      setError('Error al guardar la entidad');
    }
  };

  if (loading) return <div className="loading">Cargando...</div>;

  return (
    <div className="entity-form-container">
      <h2>{isEditing ? 'Editar Entidad' : 'Crear Nueva Entidad'}</h2>
      {error && <div className="error-message">{error}</div>}
      <form onSubmit={handleSubmit} className="entity-form">
        <div className="form-group">
          <label htmlFor="name">Nombre</label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="acronym">Siglas</label>
          <input
            type="text"
            id="acronym"
            name="acronym"
            value={formData.acronym}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="description">Descripción</label>
          <textarea
            id="description"
            name="description"
            value={formData.description}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="address">Dirección</label>
          <input
            type="text"
            id="address"
            name="address"
            value={formData.address}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="phoneNumber">Teléfono</label>
          <input
            type="text"
            id="phoneNumber"
            name="phoneNumber"
            value={formData.phoneNumber}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="email">Correo Electrónico</label>
          <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="website">Sitio Web</label>
          <input
            type="url"
            id="website"
            name="website"
            value={formData.website}
            onChange={handleChange}
          />
        </div>
        <div className="form-group checkbox">
          <label>
            <input
              type="checkbox"
              name="isActive"
              checked={formData.isActive}
              onChange={handleChange}
            />
            Activo
          </label>
        </div>
        <div className="form-buttons">
          <button type="submit" className="btn-save">Guardar</button>
          <button type="button" className="btn-cancel" onClick={() => navigate('/')}>Cancelar</button>
        </div>
      </form>
    </div>
  );
};

export default EntityForm;