import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true };

      fetch('api/v1/world/Countries/all')
      .then(response => response.json())
      .then(data => {
        this.setState({ forecasts: data, loading: false });
      });
  }

  static renderForecastsTable (forecasts) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Code</th>
            <th>Name</th>
            <th>Continent</th>
                    <th>Region</th>
                    <th>Surface Area</th>
                    <th>Independence year</th>
                    <th>Population</th>
                    <th>Life expectancy</th>
                    <th>Gross National Product</th>
                    <th>Gross National Product old</th>
                    <th>Local name</th>
                    <th>Government form</th>
                    <th>Head of state</th>
                    <th>Capital</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
                    <tr key={forecast.code}>
                        <td>  {forecast.code}  </td>
                        <td><Link to={{ pathname: '/cities', state: { foo: forecast.name } }}> {forecast.name} </Link></td>
                        <td>{forecast.continent}</td>
                        <td>{forecast.region}</td>
                        <td>{forecast.surfacearea}</td>
                        <td>{forecast.indepyear}</td>
                        <td>{forecast.population}</td>
                        <td>{forecast.lifeexpectancy}</td>
                        <td>{forecast.gnp}</td>
                        <td>{forecast.gnpold}</td>
                        <td>{forecast.localname}</td>
                        <td>{forecast.governmentform}</td>
                        <td>{forecast.headofstate}</td>
                        <td>{forecast.capital}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1>Countries</h1>
        {contents}
      </div>
    );
  }
}
