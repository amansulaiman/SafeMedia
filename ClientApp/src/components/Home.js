import React, { Component } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
export class Home extends Component {
  displayName = Home.name

  constructor(props) {
    super(props);
    this.state = {
      value: '',
      bsStyle: 'default',
      disabled: true,
      isHateSpeech: false,
      placeholder: 'Have anything in your mind? Write it here'
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    const sentimentText = event.target.value.replace(' ', '%20');

    if (sentimentText.length > 0) {
      Promise.resolve((async () => {
        return await fetch(`/api/SentimentAnalysis?sentiment=${sentimentText}`).then(res => res.json());
      })()).then(data => {
        this.setState({isHateSpeech: data.isHateSpeech});
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
    .catch(error => console.error('Error:', error))
    .then(response => console.log('Success:', response));

    this.setState({
      value: '',
      bsStyle: 'default',
      disabled: true
    });
  }

  render() {
    return (
      <div>
        <h2>We help you write non abuse words on your Facebook</h2>
        <Form onSubmit={this.handleSubmit}>
          <FormGroup controlId="formControlsTextarea" bsSize="large">
            <FormControl componentClass="textarea" style={{height: '200px'}} value={this.state.value} onChange={this.handleChange} placeholder={this.state.placeholder} />
          </FormGroup>
          <Button type="submit" bsStyle={this.state.bsStyle} bsSize="large" disabled={this.state.disabled} block>POST ON MY FACEBOOK WALL <FontAwesomeIcon icon="arrow-right"/></Button>
        </Form>
      </div>
    );
  }
}