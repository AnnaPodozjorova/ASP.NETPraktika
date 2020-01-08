import React, { Component } from 'react';

export class Cities extends Component {
    static displayName = Cities.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        const { foo } = this.props.location.state;
        fetch('api/v1/world/Countries/'+ foo +'/city/all')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });

         this.FuncDelete = this.FuncDelete.bind(this);
        this.FuncEdit = this.FuncEdit.bind(this);
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Country Code</th>
                        <th>District</th>
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
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Cities.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1>Cities</h1>
                {contents}
            </div>
        );
    }
}
