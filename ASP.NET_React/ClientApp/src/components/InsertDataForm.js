import React from 'react'

export class InsertDataForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            countrycode: '',
            district: '',
            population: ''
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
       const { cityid } = this.props.location.state;
    }

    handleChange(evt) {
        this.setState({
            [evt.target.name]: evt.target.value 
            
        });
    }

    handleSubmit() {
        const { cityid } = this.props.location.state;
        this.props.history.go(-1);
        fetch('api//Cities/' + cityid, {
            method: 'PUT',
            body: JSON.stringify({
                id: cityid,
                name: this.state.name,
                countrycode: this.state.countrycode,
                district: this.state.district,
                population: this.state.population
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        }).then(response => {
            return response.json()
        }).then(json => {
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
                <span className="form-caption">Edit city:</span>
                <div>
                    <label className="field-name">Name:<br />
                        <input value={this.state.name} name="name"  required onChange={this.handleChange} placeholder="name" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Country code:<br />
                        <input value={this.state.countrycode} name="countrycode" maxLength="3" required onChange={this.handleChange} placeholder="country code" />
                    </label>
                </div>
                <div>
                    <label className="field-name">District:<br />
                        <input value={this.state.district} name="district"  onChange={this.handleChange} placeholder="district" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Population:<br />
                        <input value={this.state.population} name="population"  onChange={this.handleChange} placeholder="population" />
                    </label>
                </div>
                <br />
                <button className="btn btn-primary" onClick={() => this.handleSubmit()}>Submit</button>
            </div>
        );
    }
}