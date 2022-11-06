import axios from "axios";
import { useEffect, useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";

import { Navigate } from "react-router-dom";

import { 
    Container,
    FormGroup,
    Col,
    Input,
    Button,
    Form,
    Label,
    Alert
} from "reactstrap";

function EditEmployee (props) {
    const location = useLocation ();
    const navigate = useNavigate ();
    const params = useParams ();

    const [fields, updateFields] = useState (
        {
            empNo: '',
            firstName: '',
            lastName: '',
            gender: '',
            birthDate: '',
            hireDate: ''
        }
    );
    
    const [state, updateState] = useState (
        {
            token: props.token,
            isSubmitted: false,
            error: false
        }
    );

    const editEndpoint = process.env.REACT_APP_EMPLOYEES_ENDPOINT_BASEPATH;
    const editTemplate = process.env.REACT_APP_EMPLOYEES_ENDPOINT_GET_ALL; 

    useEffect (() => {
        
        let url = editEndpoint + editTemplate + "/" + params.id

        axios.get (url, {
            headers: {
                'Accept': 'application/json',
                'Content-type': 'application/json',
                'Authorization': 'Bearer ' + props.token
            }
        })
        .then (response => {
            if (response.status === 200) {
                updateFields (
                    {
                        empNo: response.data.empNo,
                        firstName: response.data.firstName,
                        lastName: response.data.lastName,
                        birthDate: response.data.birthDate.substr (0, 10),
                        hireDate: response.data.hireDate.substr (0, 10)
                    }
                )
            } else {
                updateState (
                    {
                        error: true
                    }
                )
            }
        });


    }, [params, editEndpoint, editTemplate, props.token]);
    
    function handleChange (e) {
        updateFields (
            {
                ...fields,
                [e.target.name]: e.target.value
            }
        );
    }

    function add (e) {
        let url = editEndpoint + editTemplate + "/" + params.id

        let data = {
            firstName: fields.firstName,
            lastName: fields.lastName,
            gender: 'F',
            birthDate: fields.birthDate,
            hireDate: fields.hireDate
        }
        
        axios.put (url, JSON.stringify (data), {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + state.token
            }
        })
        .then (response => {
            if (response.status === 200) {
                updateState (
                    {
                        isSubmitted: true
                    }
                );

                return;
            }

            updateState (
                {
                    error: true,
                }
            );
        }).catch (reason => {
            updateState ({
                error: true
            })
        })
    }

    function cancel (e) {
        navigate ('/employeesManagement');
    }


    if (fields.token === '') {
        return (
            <Navigate to = '/login' state={{from: location.pathname}} />
        )
    }

    return (
        <Container className="App">
                <h4 className="PageHeading">Enter employee infomation</h4>
                <Alert 
                    isOpen={state.isSubmitted} 
                    color={!state.error ? "success" : "warning"}
                    toggle={() => updateState ({ isSubmitted: false })}
                >
                    {!state.error ? "Information was saved!" : "An error occurs while trying to update information"}
                </Alert>
                <Form className="form">
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>First Name</Label>
                            <Col sm={2}>
                                <Input type="text" name="firstName" onChange={handleChange} value={fields.firstName} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Last Name</Label>
                            <Col sm={2}>
                                <Input type="text" name="lastName" onChange={handleChange} value={fields.lastName} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Birth Date</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="date" name="birthDate" value={fields.birthDate} onChange={handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Hire Date</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="date" name="hireDate" onChange={handleChange} value={fields.hireDate} />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}>
                            </Col>
                            <Col sm={1}>
                                <Button color="primary" onClick={add}>Submit</Button>
                            </Col>
                            <Col sm={1}>
                                <Button color="secondary" onClick={cancel} >Cancel</Button>
                            </Col>
                            <Col sm={5}>
                            </Col>
                        </FormGroup>
                    </Col>
                </Form>
            </Container>
    );

}

export default EditEmployee;