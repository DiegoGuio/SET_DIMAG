import './App.css';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import LoginView from './Componentes/LoginView';
import HomePage from './Componentes/HomePage';


function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<LoginView/>}/>
        <Route path='/home' element={<HomePage/>}/>
      </Routes>
    </Router>
  );
}

export default App;
