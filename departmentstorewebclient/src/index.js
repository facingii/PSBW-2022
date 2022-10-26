//import React, { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';
import MyApp from './App';

import 'bootstrap/dist/css/bootstrap.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  
    //<StrictMode>
        <MyApp MyData={{x: 1, y: 2}} />
    //</StrictMode>
  
);

