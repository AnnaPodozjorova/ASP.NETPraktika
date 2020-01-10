import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Cities } from './components/Cities';
import { InsertDataForm } from './components/InsertDataForm';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
            <Route path='/countries' component={FetchData} />
            <Route path='/cities' component={Cities} />
            <Route path='/edit-city' component={InsertDataForm} />
      </Layout>
    );
  }
}
