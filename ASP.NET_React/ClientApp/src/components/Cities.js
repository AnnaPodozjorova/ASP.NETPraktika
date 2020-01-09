import React, { Component } from 'react';

export class Cities extends Component {
    static displayName = Cities.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        const { foo } = this.props.location.state;
        console.log(foo);
        fetch('api//v1/world/Countries/' + foo +'/city/all')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
        this.DeleteCityByID = this.DeleteCityByID.bind(this);
    }

    DeleteCityByID(CityId) {
        if (window.confirm('Are you sure?')) {
            fetch('api/Cities/' + CityId, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        } 
    }
    
    static renderForecastsTable(forecasts,del) {
    
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>District</th>
                        <th>Country Code</th>
                        <th>Population</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.id}>
                            <td>{forecast.name}</td>
                            <td>{forecast.countrycode}</td>
                            <td>{forecast.district}</td>
                            <td>{forecast.population}</td>
                            <td>
                                <button className="btn btn-primary" onClick={() => del(forecast.id)}>Delete</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

   
    render() {
    
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Cities.renderForecastsTable(this.state.forecasts, this.DeleteCityByID);

        return (
            <div>
                <h1>Cities</h1>
                {contents}
            </div>
        );
    }
}
