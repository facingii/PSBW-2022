import { useState } from "react";
import axios from "axios";
import { 
    FormGroup,
    Button, 
    Input,
    Alert,
    Form,
    Label 
} from "reactstrap";

import './login.css';
import { useLocation, useNavigate } from "react-router-dom";

const Login = (props) => {
	const location = useLocation ();
	const navigate = useNavigate ();

	const USERS_ENDPOINT_BASEPATH = process.env.REACT_APP_USERS_ENDPOINT_BASEPATH;
	const USERS_ENDPOINT_AUTHENTICATE = process.env.REACT_APP_USERS_ENDPOINT_AUTHENTICATE;
    
    const [estado, guardarEstado] = useState (
		{
			UserName: '',
			Password: '',
			error: false,
			prev: location.state.from
		}
	); 

    const doLogin = () => {
		debugger;
		axios.post (USERS_ENDPOINT_BASEPATH + USERS_ENDPOINT_AUTHENTICATE,
		{
			"firstName": "",
			"lastName": "",
			"userName": estado.UserName,
			"password": estado.Password,
			"token": ""
		},
		{
			headers: {
				'Content-type': 'application/json'
			}
		}).then (
			(response) => {
				if (response.status === 200) {
					const json = response.data;
					localStorage.setItem("ACCESS_TOKEN", json.token);
					navigate (estado.prev);
				}
			},
			(error) => {
				if (error.response.status === 400) {
					guardarEstado (prevState =>
						{
							return (
								{
									...prevState,
									error: true
								}	
							)
						}
					);
				}
				console.log("Exception " + error);
			}
		);
	}

	const handleChange = (e) => {
		const name = e.target.name;
		const val = e.target.value;

		guardarEstado (prevState =>
			{
				return (
					{
						...prevState,
						[name]: val
					}
				);
			}
		);
	}

	return (
		<div>
            <Alert
                isOpen={estado.error}
                color="danger"
                toggle={() => {guardarEstado ( prevState => { return ( {...prevState, error: false} )})}}
            >
                User or Password Incorrect!
            </Alert>
            <div className="Login">
                <Form>
                    <FormGroup>
                        <Label>Usuario</Label>
                        <Input name="UserName" type="text" onChange={handleChange} value={estado.UserName} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Contraseña</Label>
                        <Input type="password" name="Password" onChange={handleChange} value={estado.namePassword} />
                    </FormGroup>
                    <Button block type="button" onClick={doLogin}>
                        login
                    </Button>
                </Form>
            </div>
		</div>
	);
}


export default Login;
