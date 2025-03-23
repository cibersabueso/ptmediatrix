import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useAuth } from '../context/AuthContext';

const EntityList = () => {
  const [entities, setEntities] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const { token } = useAuth();

  useEffect(() => {
    fetchEntities();
  }, [token]);

  const fetchEntities = async () => {
    try {
      const response = await axios.get('http://localhost:5000/api/governmententities', {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      setEntities(response.data);
      setLoading(false);
    } catch (err) {
      console.error('Error fetching entities:', err);
      setError('Error al cargar las entidades');
      setLoading(false);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('¿Está seguro de que desea eliminar esta entidad?')) {
      try {
        await axios.delete(`http://localhost:5000/api/governmententities/${id}`, {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
        fetchEntities();
      } catch (err) {
        console.error('Error deleting entity:', err);
        setError('Error al eliminar la entidad');
      }
    }
  };

  if (loading) return <div className="loading">Cargando...</div>;
  if (error) return <div className="error">{error}</div>;

  return (
   <div className="entity-list-container">
   <h2>Listado de Entidades Gubernamentales</h2>
   <Link to="/entities/new" className="btn-add">
     Nueva Entidad
   </Link>
   
   {entities.length === 0 ? (
     <p className="no-entities">No hay entidades registradas.</p>
   ) : (
     <div className="table-container">
       <table className="entity-table">
         <thead>
           <tr>
             <th>ID</th>
             <th>Nombre</th>
             <th>Siglas</th>
             <th>Descripción</th>
             <th>Estado</th>
             <th>Acciones</th>
           </tr>
         </thead>
         <tbody>
           {entities.map(entity => (
             <tr key={entity.id}>
               <td>{entity.id}</td>
               <td>{entity.name}</td>
               <td>{entity.acronym}</td>
               <td>{entity.description}</td>
               <td>{entity.isActive ? 'Activo' : 'Inactivo'}</td>
               <td className="actions">
                 <Link to={`/entities/edit/${entity.id}`} className="btn-edit">
                   Editar
                 </Link>
                 <button 
                   onClick={() => handleDelete(entity.id)} 
                   className="btn-delete"
                 >
                   Eliminar
                 </button>
               </td>
             </tr>
           ))}
         </tbody>
       </table>
     </div>
   )}
 </div>
);
};

export default EntityList;
    