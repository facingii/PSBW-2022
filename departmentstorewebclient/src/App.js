import './App.css';
import React, { useState } from 'react';

import Home from './components/home';
import EmployeesManagement from './components/employees/employeesManagement';
import AddEmployee from './components/employees/addEmployee';
import EditEmployee from './components/employees/editEmployee';
import UsersManagement from './components/users/UsersManagement';
import Login from './components/login/login';

import {
	BrowserRouter,
	Link,
    Routes,
	Route,
    useParams
} from 'react-router-dom'; 

import { Container, Navbar, NavItem } from 'reactstrap';

function MyApp (props) {
    const [edad, actualizaEdad] = useState (22);
    const [color, cambiaColor] = useState ('black');

    // necessary hack due to new version of rect-router doesn't pass
    // url params as props 
    const Wrapper = (props) => {
        const params = useParams ();


        return (
            <EditEmployee {...{...props, match: {params}}}/>
        )
    }

    return (

        <BrowserRouter>
            <Container style={{maxWidth: '100%'}} >
                <Navbar expand="lg" className="navheader">
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav mr-auto">
                        <NavItem>
                            <Link to={'/'} className="nav-link">Home</Link>
                        </NavItem>
                        <NavItem>
                            <Link to={'/employeesManagement'} className="nav-link">Employees Management</Link>
                        </NavItem>
                        <NavItem>
                            <Link to={'/usersManagement'} className="nav-link">Users Managements</Link>
                        </NavItem>
                        </ul>
                    </div>
                </Navbar>
            </Container>
            <br />
            <Routes>
                <Route exact path='/' element={<Home />} />
                <Route exact path='/employeesManagement' element={<EmployeesManagement myColor={color} myEdad={edad} />} />
                <Route exact path='/addEmployee' element={<AddEmployee replace to='employeesManagement' cambiaColor={cambiaColor} actualizaEdad={actualizaEdad} />} />
                <Route exact path='/edit/:id' element={<Wrapper />} replace to='employeesManagement' />
                <Route exact path='/usersManagement' element={<UsersManagement />} />
                <Route exact path='/login' element={<Login />} />
            </Routes>
        </BrowserRouter>

    );

}

export default MyApp;