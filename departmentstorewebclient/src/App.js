import './App.css';
import React from 'react';

import Home from './components/home';
import MyHeader from './components/header';
import MyContent from './components/content';

import {
	BrowserRouter,
	Link,
    Routes,
	Route
} from 'react-router-dom'; 

import { Container, Navbar, NavItem } from 'reactstrap';

function MyApp (props) {

    return (
        <BrowserRouter>
            <Container>
                <Navbar expand="lg" className="navheader">
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav mr-auto">
                        <NavItem>
                            <Link to={'/'} className="nav-link">Home</Link>
                        </NavItem>
                        <NavItem>
                            <Link to={'/header'} className="nav-link">Header</Link>
                        </NavItem>
                        <NavItem>
                            <Link to={'/content'} className="nav-link">Content</Link>
                        </NavItem>
                        </ul>
                    </div>
                </Navbar>
            </Container>
            <br />
            <Routes>
                <Route exact path='/' element={<Home />} />
                <Route exact path='/header' element={<MyHeader />} />
                <Route exact path='/content' element={<MyContent />} />
            </Routes>
        </BrowserRouter>
    );

    

}

export default MyApp;