import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import './NavMenu.css';
export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>SafeMedia</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
              <FontAwesomeIcon icon="edit"/> Safe Write
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/safegroups'}>
              <NavItem>
              <FontAwesomeIcon icon="comments"/> Safe Groups
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/reporthatespeech'}>
              <NavItem>
                <FontAwesomeIcon icon="bug"/> Report Hate Speech 
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/dataprivacy'}>
              <NavItem>
                <FontAwesomeIcon icon="database"/> Data Privacy 
              </NavItem>
            </LinkContainer>
              <NavItem href="/api-docs" target="_blank">
                <FontAwesomeIcon icon="dot-circle"/> API
              </NavItem>
            <NavItem href="https://github.com/amansulaiman/SafeMedia" target="_blank">
              <FontAwesomeIcon icon={['fab', 'github']}/> Contibute
            </NavItem>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
