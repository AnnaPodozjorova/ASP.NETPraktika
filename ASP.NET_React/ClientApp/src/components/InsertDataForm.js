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
       
    }

    handleChange(evt) {
        this.setState({
            [evt.target.name]: evt.target.value 
            
        }); console.log(evt.target.name +": " +evt.target.value);
    }

    handleSubmit(event) {
        console.log("success");
        const { cityid } = this.props.location.state;
        console.log(cityid);
        fetch('api//Cities' + cityid, {
            method: 'PUT',
            body: JSON.stringify({
                id: cityid,
                name: event.target.name.value,
                countrycode: event.target.countrycode.value,
                district: event.target.district.value,
                population: event.target.population.value
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        }).then(response => {
            return response.json()
        }).then(json => {
            console.log(json)
            this.setState({
                 json
            });
            })



      //  alert('Отправленное имя: ' + this.state.value);
      //  event.preventDefault();
    }

    render() {
        return (

            <div className="input-panel">
                <span className="form-caption">Edit city:</span>
                <div>
                    <label className="field-name">Name:<br />
                        <input value={this.state.name} name="name" maxLength="40" required onChange={this.handleChange} placeholder="name" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Country code:<br />
                        <input value={this.state.countrycode} name="countrycode" maxLength="40" required onChange={this.handleChange} placeholder="country code" />
                    </label>
                </div>
                <div>
                    <label className="field-name">District:<br />
                        <input value={this.state.district} name="district" maxLength="4" pattern="[0-9]{1,4}" onChange={this.handleChange} placeholder="district" />
                    </label>
                </div>
                <div>
                    <label className="field-name">Population:<br />
                        <input value={this.state.population} name="population" maxLength="2" pattern="[a-z|A-Z]{2}" onChange={this.handleChange} placeholder="population" />
                    </label>
                </div>
                <br />

                <button onClick={() => this.handleSubmit}>Update</button>
            </div>
        );
    }
}