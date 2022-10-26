import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

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

function EditEmployee ({token}) {
    const location = useLocation ();
    const navigate = useNavigate ();
    
    const [fields, updateFields] = useState (
        {
            firstName: '',
            lastName: '',
            birthDate: '',
            hireDate: '',
        }
    );

    const [states, updateStates] = useState (
        {
            isSubmitted: false,
            error: false
        }
    );

    useEffect (() => {
        //fetch data
    }, []);
    
    function handleChange (e) {
        updateFields (
            {
                [e.name]: e.value
            }
        );
    }

    function add (e) {
        //put data
    }

    function cancel (e) {
        navigate ('/employeesManagement');
    }


    if (token === '') {
        return (
            <Navigate to = '/login' state={{from: location.pathname}} />
        )
    }

    return (
        <Container className="App">
                <h4 className="PageHeading">Enter employee infomation</h4>
                <Alert 
                    isOpen={states.isSubmitted} 
                    color={!states.error ? "success" : "warning"}
                    toggle={() => updateStates ({ isSubmitted: false })}
                >
                    {!states.error ? "Information was saved!" : "An error occurs while trying to update information"}
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