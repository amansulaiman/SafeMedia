import React, { Component } from 'react';
import Facebook from './auth/Facebook';
import './App.css';
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {faGithub} from '@fortawesome/free-brands-svg-icons'
import {faBug, faComments, faEdit, faDotCircle} from '@fortawesome/free-solid-svg-icons'
library.add(faGithub,faBug, faComments,faEdit,faDotCircle);
export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Facebook />
    );
  }
}