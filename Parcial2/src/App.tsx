import React, { useState } from 'react';
import './App.css'

async function postData(url = '', data = {}) {
  console.log('Enviando datos:', data); // Imprime los datos que se envían
  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });
  const responseData = await response.json();
  console.log('Respuesta del servidor:', responseData); // Imprime la respuesta del servidor
  return responseData;
}

const App = () => {
  const [nombreCurso, setNombreCurso] = useState('');
  const [creditos, setCreditos] = useState('');
  const [descripcion, setDescripcion] = useState('');

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    const data = {
      nombreCurso,
      creditos,
      descripcion
    };
    const response = await postData('https://test-deploy-12.onrender.com/cursos/', data);
    console.log(response);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label htmlFor="nombreCurso">Nombre Curso:
          <input
            type="text"
            id="nombreCurso"
            value={nombreCurso}
            onChange={(e) => setNombreCurso(e.target.value)}
          />
        </label><br /><br />
        <label htmlFor="creditos">Creditos:
          <input
            type="text"
            id="creditos"
            value={creditos}
            onChange={(e) => setCreditos(e.target.value)}
          />
        </label><br /><br />
        <label htmlFor="descripcion">Descripcion:
          <input
            className='input3'
            type="text"
            id="descripcion"
            value={descripcion}
            onChange={(e) => setDescripcion(e.target.value)}
          />
        </label><br /><br />
        <button type="submit">Guardar</button>
        <button type="button" onClick={() => {
          setNombreCurso('');
          setCreditos('');
          setDescripcion('');
        }}>Limpiar</button>
      </form>
    </div>
  );
};

export default App;