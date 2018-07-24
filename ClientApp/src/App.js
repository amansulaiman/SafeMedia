import React, { Component } from 'react';
import Facebook from './auth/Facebook';
import './App.css';
import { library } from '@fortawesome/fontawesome-svg-core';
import {faGithub} from '@fortawesome/free-brands-svg-icons'
import {faBug, faComments, faEdit, faDotCircle, faArrowRight, faDatabase, faUserSecret} from '@fortawesome/free-solid-svg-icons'
library.add(faGithub,faBug, faComments,faEdit,faDotCircle,faArrowRight,faDatabase, faUserSecret);
export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Facebook />
    );
  }
}