import React, { Component } from 'react';


export class Registration extends Component {


    static displayName = Registration.name;
    constructor(props) {
        super(props);
        this.state = {
            login: '',
            password: '',
            role: 'user'
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(evt) {
        this.setState({
            [evt.target.name]: evt.target.value

        });
        console.log(evt.target.name + ": " + evt.target.value);
    }

    handleSubmit() {
        fetch('api/Auth/register', {
            method: 'POST',
            body: JSON.stringify({
                Login: this.state.login,
                Password: this.state.password,
                Role: "user"
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        }).then(response => {
            return response.json()
        }).then(json => {
            console.log(json);
            this.setState({
                login: json,
                password: json
            });
        })
    }

    render() {
        return (
            <div className="input-panel">
                <span className="form-caption">Registration:</span>
                <div>
                    <label className="field-name">Login:<br />
                        <input value={this.state.login} name="login" required onChange={this.handleChange} placeholder="login" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Password:<br />
                        <input value={this.state.password} name="password" required onChange={this.handleChange} placeholder="password" />
                    </label>
                </div>
                <button className="btn btn-primary" onClick={() => this.handleSubmit()}>Submit</button>
            </div>
        );
    }
}
