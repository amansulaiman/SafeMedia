import React, { Component } from 'react';
import { Redirect } from 'react-router';
import { Form, FormGroup, FormControl, Button, Row, Col, Panel } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Notifications, {notify} from 'react-notify-toast';
export class Home extends Component {
  displayName = Home.name

  constructor(props) {
    super(props);
    this.state = {
      value: '',
      bsStyle: 'default',
      disabled: true,
      hateSpeechConfidance: 0,
      isHateSpeech: false,
      language: '',
      languageConfidance: 0,
      suggestion: '',
      changeRoute: false,
      placeholder: 'Have anything in your mind? Write it here'
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.reportHateSpeech = this.reportHateSpeech.bind(this);
  }

  handleChange(event) {
    const sentimentText = event.target.value.replace(' ', '%20');

    if (sentimentText.length > 0) {
      Promise.resolve((async () => {
        return await fetch(`/api/SentimentAnalysis?sentiment=${sentimentText}`).then(res => res.json());
      })()).then(data => {
        this.setState({
          hateSpeechConfidance: data.hateSpeechConfidance,
          isHateSpeech: data.isHateSpeech,
          language: data.language,
          languageConfidance: data.languageConfidance,
          suggestion: data.suggestion
        });
      })
    }
    
    if (event.target.value.length > 0 && this.state.isHateSpeech === false) {
      this.setState({
        value: event.target.value,
        bsStyle: 'success',
        disabled: false
      });
    } else if (event.target.value.length > 0 && this.state.isHateSpeech === true) {
      this.setState({
        value: event.target.value,
        bsStyle: 'danger',
        disabled: true
      });
    } else {
      this.setState({
        value: event.target.value,
        bsStyle: 'default',
        disabled: true
      });
    }
  }

  handleSubmit(event) {
    event.preventDefault();
    
    const url = `https://graph.facebook.com/v2.10/${this.props.id}/feed?access_token=${this.props.accessToken}`;
    const data = {message: this.state.value};

    fetch(url, {
      method: 'POST',
      body: JSON.stringify(data),
      headers: {'Content-Type': 'application/json'}
    }).then(res => res.json())
    .catch(error => {
      notify.show('Something went wrong', 'error');
    })
    .then(response => {
      notify.show('Posted successfully to your wall', 'success');
    });

    this.setState({
      value: '',
      bsStyle: 'default',
      disabled: true
    });
  }

  reportHateSpeech(event) {
    event.preventDefault();

    this.setState({
      bsStyle: 'default',
      disabled: true,
      changeRoute: true
    });
  }
  
  render() {
    if (this.state.changeRoute === true) {
      return (<Redirect to={{
        pathname: '/reporthatespeech',
        referrer: {
          hateSpeech: this.state.value,
          platform: 'SafeMedia'
        }
      }} />)
    }

    return (
      <div>
        <Notifications />
        <h2 style={{ fontSize: 32, fontFamily: "Patua One, cursive", color:"#4189C7"}}>We help you write non abuse words on your Facebook</h2>
        <Form onSubmit={this.handleSubmit}>
          <FormGroup controlId="formControlsTextarea" bsSize="large">
            <Row>
              <Col sm={12}>
                <FormControl componentClass="textarea" style={{height: '200px'}} value={this.state.value} onChange={this.handleChange} placeholder={this.state.placeholder} />
              </Col>
            </Row>
            <Row>
              <Col sm={6} style={{marginTop: '10px'}}>
                <Panel bsStyle="primary">
                  <Panel.Heading>
                    <Panel.Title componentClass="h3">Language</Panel.Title>
                  </Panel.Heading>
                  <Panel.Body style={{height: '50px'}}>{this.state.language}</Panel.Body>
                </Panel>
              </Col>
              <Col sm={6} style={{marginTop: '10px'}}>
                <Panel bsStyle="primary">
                  <Panel.Heading>
                    <Panel.Title componentClass="h3">Language Confidence</Panel.Title>
                  </Panel.Heading>
                  <Panel.Body style={{height: '50px'}}>{this.state.languageConfidance}</Panel.Body>
                </Panel>
              </Col>
            </Row>
            <Row>
              <Col sm={6} style={{marginTop: '10px'}}>
                <Panel bsStyle="primary">
                  <Panel.Heading>
                    <Panel.Title componentClass="h3">Hate Speech Confidence</Panel.Title>
                  </Panel.Heading>
                  <Panel.Body style={{height: '50px'}}>{this.state.hateSpeechConfidance}</Panel.Body>
                </Panel>
              </Col>
              <Col sm={6} style={{marginTop: '10px'}}>
                <Panel bsStyle="primary">
                  <Panel.Heading>
                    <Panel.Title componentClass="h3">Suggestion</Panel.Title>
                  </Panel.Heading>
                  <Panel.Body style={{height: '50px'}}>{this.state.suggestion}</Panel.Body>
                </Panel>
              </Col>
            </Row>
          </FormGroup>
          <Button style={{fontFamily: "Open Sans, sans-serif"}} type="submit" bsStyle={this.state.bsStyle} bsSize="large" disabled={this.state.disabled} block>POST ON MY FACEBOOK WALL <FontAwesomeIcon icon="arrow-right"/></Button>
          <Button style={{fontFamily: "Open Sans, sans-serif", marginTop: '5%'}} bsStyle={this.state.bsStyle} bsSize="large" disabled={this.state.disabled} onClick={this.reportHateSpeech}>REPORT AS HATE SPEECH <FontAwesomeIcon icon="flag"/></Button>
        </Form>
      </div>
    );
  }
}