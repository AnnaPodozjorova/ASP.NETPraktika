import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props);
        this.state = {
            login: '',
            password: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(evt) {
        this.setState({
            [evt.target.name]: evt.target.value

        });
    }

    handleSubmit() {
        fetch('api/Auth/token', {
            method: 'POST',
            headers: {
                "Content-type": "application/json; charset=UTF-8",
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                Login: this.state.login,
                Password: this.state.password,
                Role: "user"
            })
        }).then(function (result) {
            result.text().then(function (data) {
                localStorage.setItem("token", data);
                });
            });
    }

  render () {
      return (
          <div className="input-panel">
              <span className="form-caption">Login:</span>
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
