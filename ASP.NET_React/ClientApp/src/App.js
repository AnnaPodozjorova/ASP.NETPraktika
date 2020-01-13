import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Registration } from './components/Registration';
import { Cities } from './components/Cities';
import { InsertDataForm } from './components/InsertDataForm';
import { AddNewCity } from './components/AddNewCity';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/registration' component={Registration} />
            <Route path='/countries' component={FetchData} />
            <Route path='/cities' component={Cities} />
            <Route path='/edit-city' component={InsertDataForm} />
            <Route path='/add-city' component={AddNewCity} />
      </Layout>
    );
  }
}
