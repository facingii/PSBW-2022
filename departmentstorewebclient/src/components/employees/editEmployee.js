import React from "react";

class EditEmployee extends React.Component {

    constructor (props) {
        super (props);
        this.id = props.match.params.id;
    }

    render () {
        return (<h1>Edit Info of Employee No: {this.id}</h1>)
    }

}

export default EditEmployee;