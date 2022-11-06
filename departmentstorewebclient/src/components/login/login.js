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

const Login = ({setToken}) => {
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
		let endpoint = USERS_ENDPOINT_BASEPATH + USERS_ENDPOINT_AUTHENTICATE;
		let payload = {
			username: estado.UserName,
			password: estado.Password
		};

		axios.post (endpoint, payload,
		{
			headers: {
				'Content-Type': 'application/json; charset=utf-8'
			}
		}).then (
			(response) => {
				if (response.status === 200) {
					const json = response.data;

					if (json.token === '') {
						guardarEstado (prevState => {
							return (
								{
									...prevState,
									error: true
								}
							)
						}); 
					}

					setToken (json.token);
					navigate (estado.prev);
				}

				if (response.status === 401 || response.status === 204) {
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
			},
			(error) => {
				if (error.response.status === 400 || error.response.status === 401) {
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
				
				//console.log("Exception " + error);
			}
		).catch (error => {
			//console.log (error);
		});
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
