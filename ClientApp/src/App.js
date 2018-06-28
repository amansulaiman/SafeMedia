import React, { Component } from 'react';
import Facebook from './auth/Facebook';
import './App.css';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Facebook />
    );
  }
}