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
        console.log(evt.target.name + ": " + evt.target.value);
    }

    handleSubmit() {
        console.log("login=" + this.state.login + "&password=" + this.state.password + "");
        var body = new FormData();
        body.set("login", this.state.login);
        body.set("password", this.state.password);
        fetch('api/Auth/token', {
            method: 'POST',
            headers: new Headers({
                'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8', // <-- Specifying the Content-Type
            }),
            body: body 
        }).then(response => {
            response.json()
            }).then(data => {
                if (data.message) {
                } else {
                    localStorage.setItem("token", data.jwt)
                }
            })
        console.log(localStorage.token);
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
