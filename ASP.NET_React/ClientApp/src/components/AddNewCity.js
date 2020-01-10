import React from 'react'

export class AddNewCity extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            id: null,
            name: '',
            countrycode: '',
            district: '',
            population: ''
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(evt) {
        this.setState({
            [evt.target.name]: evt.target.value

        }); console.log(evt.target.name + ": " + evt.target.value);
    }

    handleSubmit(event) {
        console.log("success");
        fetch('api/Cities', {
            method: 'POST',
            body: JSON.stringify({
                id: this.state.id,
                name: this.state.name,
                countrycode: this.state.countrycode,
                district: this.state.district,
                population: this.state.population
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        }).then(response => {
            return response.json()
        }).then(json => {
            console.log(json)
            this.setState({
                id: json,
                name: json,
                countrycode: json,
                district: json,
                population: json
            });
        })
    }

    render() {
        return (

            <div className="input-panel">
                <span className="form-caption">Add city:</span>
                <div>
                    <label className="field-name">ID:<br />
                        <input value={this.state.id} name="id"  required onChange={this.handleChange} placeholder="id" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Name:<br />
                        <input value={this.state.name} name="name" required onChange={this.handleChange} placeholder="name" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Country code:<br />
                        <input value={this.state.countrycode} name="countrycode" required onChange={this.handleChange} placeholder="country code" />
                    </label>
                </div>
                <div>
                    <label className="field-name">District:<br />
                        <input value={this.state.district} name="district" onChange={this.handleChange} placeholder="district" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Population:<br />
                        <input value={this.state.population} name="population" pattern="[a-z|A-Z]{2}" onChange={this.handleChange} placeholder="population" />
                    </label>
                </div>
                <br />
                <button className="btn btn-primary" onClick={() => this.handleSubmit()}>Submit</button>
            </div>
        );
    }
}