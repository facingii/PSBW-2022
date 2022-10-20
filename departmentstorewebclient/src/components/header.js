import React from 'react';
import './header.css';

class MyHeader extends React.Component {

    constructor (props) {
        super (props);

        this.state = {
            result: true
        };

        this.handle_change = this.handle_change.bind (this);
    }

    handle_change (e) {
        console.log(e.target.checked);

        this.setState ({
            result: e.target.checked
        });
    }

    render () { 
        const bgcolor = this.state.result ? 'background-ok' : 'background-fail';
        
        return (
            <div>
                <h2 className={bgcolor} >HEADER</h2>
                <label>
                    <input type="checkbox" name="mycheck" onChange={this.handle_change} />
                    It's OK?
                </label>
            </div>
        )
    }

}

export default MyHeader;