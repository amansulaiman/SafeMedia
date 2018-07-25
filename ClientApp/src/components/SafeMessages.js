import React, { Component } from 'react';
import { Button, Col, Panel } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class SafeMessages extends Component {
  displayName = SafeMessages.name

  constructor(props) {
    super(props);
    this.state = {
      id: '',
      accessToken: '',
      groups: []
    }

    this.viewMessages = this.viewMessages.bind(this);
  }

  componentDidMount() {
    this.setState({
      id: this.props.id,
      accessToken: this.props.accessToken,
      groups: this.props.groups.data
    });
  }

  viewMessages(event) {
    event.preventDefault();

    // here I'm only logging the clicked group id to the console
    // I'll use the id to query the graph API and fetch the groups message
    // Using this endpoint 
    // https://graph.facebook.com/v2.10/${this.state.id}/${event.target.dataset.groupid}/feed?access_token=${this.state.accessToken}
    console.log(this.state.id);
    console.log(event.target.dataset.groupid);
    console.log(this.state.accessToken);
  }

  render() {
    return (
      <div>
        <h2 style={{ fontSize: 28, fontFamily: "Patua One, cursive", color:"#4189C7"}}>Here is a list of all your groups click view messages to read group feed</h2>
        {this.state.groups.map((group) => {
          return (
            <Col key={group.id} sm={6} style={{marginTop: '10px'}}>
              <Panel bsStyle="primary">
                <Panel.Heading style={{height: '70px'}}>
                  <Panel.Title componentClass="h3">{group.name}</Panel.Title>
                </Panel.Heading>
                <Panel.Body style={{height: '60px', textAlign: 'center'}}>
                  <Button data-groupid={group.id} bsStyle='success' bsSize="small" disabled={false} onClick={this.viewMessages}>VIEW MESSAGES <FontAwesomeIcon icon="arrow-right"/></Button>
                </Panel.Body>
              </Panel>
            </Col>
          );
        })}
      </div>
    );
  }
}