import './App.css';
import React, { useState } from 'react';

import Home from './components/home';
import EmployeesManagement from './components/employees/employeesManagement';
import AddEmployee from './components/employees/addEmployee';
import EditEmployee from './components/employees/editEmployee';
import UsersManagement from './components/users/UsersManagement';
import Login from './components/login/login';

import {
	Link,
    Routes,
	Route,
    useParams
} from 'react-router-dom'; 

import { Container, Navbar, NavItem } from 'reactstrap';

import { useIdleTimer } from 'react-idle-timer';

function MyApp (props) {
    const [token, setToken] = useState ('');
    useIdleTimer ({onIdle, onActive, timeout: 1000 * 60 * 1});
        
    // necessary hack due to new version of rect-router doesn't pass
    // url params as props 
    const Wrapper = (props) => {
        const params = useParams ();

        return (
            <EditEmployee {...{...props, match: {params}}}/>
        )
    }

    function onActive (e) {}

    function onIdle (e) {
        console.log("User is idle");
        logout ();
    }

    function logout () { 
        setToken ('');
        window.location.reload (false);
    }

    return (
        <React.Fragment>
            <Container style={{maxWidth: '100%'}} >
                <Navbar expand="lg" className="navheader">
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav">
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
                    {
                        token !== '' 
                        ? <Link className='nav-link float-end' onClick={logout}>Logout</Link>
                        : <React.Fragment></React.Fragment>
                    }                        
                </Navbar>
            </Container>
            <br />
            <Routes>
                <Route path='/' element={<Home />} />
                <Route exact path='/employeesManagement' element={<EmployeesManagement token={token} />} />
                <Route exact path='/addEmployee' element={<AddEmployee token={token} replace to='employeesManagement' />} />
                <Route exact path='/edit/:id' element={<Wrapper token={token} />} replace to='employeesManagement' />
                <Route exact path='/usersManagement' element={<UsersManagement />} />
                <Route exact path='/login' element={<Login setToken={setToken} />} />
            </Routes>
        </React.Fragment>
    );

}

export default MyApp;