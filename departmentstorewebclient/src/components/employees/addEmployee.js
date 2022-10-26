import { Navigate, useLocation } from "react-router-dom";

const AddEmployee = ({token}) => {
    const location = useLocation ();

    if (token === '') {
        return (
            <Navigate to = '/login' state = {{from: location.pathname}} />
        );
    }

    return (
        <h1>Add Employee</h1>
    );

}

export default AddEmployee;