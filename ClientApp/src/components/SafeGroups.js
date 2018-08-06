import React, { Component } from 'react';
import { Col, Panel } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';

export class SafeGroups extends Component {
  displayName = SafeGroups.name

  constructor(props) {
    super(props);
    this.state = {
      id: '',
      accessToken: '',
      groups: []
    }
  }

  componentDidMount() {
    this.setState({
      id: this.props.id,
      accessToken: this.props.accessToken,
      groups: this.props.groups.data
    });
  }

  render() {
    // check if user belongs to any group on Facebook
    if (this.state.groups !== undefined && this.state.groups.length !== 0) {
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
                    <Link to={{
                        pathname: `/safegroups/${group.id}`,
                        referrer: {
                          userId: this.state.id,
                          groupId: group.id,
                          token: this.state.accessToken
                        }
                      }}
                      >
                      VIEW MESSAGES <FontAwesomeIcon icon="arrow-right"/></Link>
                  </Panel.Body>
                </Panel>
              </Col>
            );
          })}
        </div>
      );
    } else {
      return (
        <div>
          <h2 style={{ fontSize: 28, fontFamily: "Patua One, cursive", color:"#4189C7"}}>It seems you didn't belong to any group on Facebook.</h2>
        </div>
      );
    }
  }
}