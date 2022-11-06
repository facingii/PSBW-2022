import { useState } from "react";
import { Navigate, useLocation, useNavigate } from "react-router-dom";
import axios from "axios";

import { 
    Col,
    Form,
    FormGroup,
    Button,
    Input,
    Label,
    Container,
    Alert
} from "reactstrap";

const AddEmployee = ({token}) => {
    const location = useLocation ();
    const navigate = useNavigate ();
    
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
            token: token,
            isSubmitted: false,
            error: false
        }
    );

    const editEndpoint = process.env.REACT_APP_EMPLOYEES_ENDPOINT_BASEPATH;
    const editTemplate = process.env.REACT_APP_EMPLOYEES_ENDPOINT_GET_ALL; 

    function add (e) {
        let url = editEndpoint + editTemplate;

        let data = {
            empNo: fields.empNo,
            firstName: fields.firstName,
            lastName: fields.lastName,
            birthDate: fields.birthDate,
            gender: fields.gender,
            hireDate: fields.hireDate,
        }

        axios.post (url, JSON.stringify (data), {
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
                    isSubmitted: false
                }
            );
        }).catch (reason => {
            updateState (
                {
                    error: true
                }
            )
        })
    }

    function cancel (e) {
        navigate ('/employeesManagement');
    }

    function handleChange (e) {
        updateFields (
            {
                ...fields,
                [e.target.name]: e.target.value
            }
        );
    }

    if (token === '') {
        return (
            <Navigate to = '/login' state = {{from: location.pathname}} />
        );
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
                            <Label for="name" sm={2}>Employee No.</Label>
                            <Col sm={2}>
                                <Input type="text" name="empNo" onChange={handleChange} value={fields.empNo} />
                            </Col>
                        </FormGroup>
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
                            <Label for="name" sm={2}>Gender</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="text" name="gender" value={fields.gender} onChange={handleChange} />
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

export default AddEmployee;