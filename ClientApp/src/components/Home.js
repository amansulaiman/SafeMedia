import React, { Component } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';

export class Home extends Component {
  displayName = Home.name

  constructor(props) {
    super(props);
    this.state = {
      value: '',
      bsStyle: 'default',
      disabled: true,
      placeholder: 'Have anything in your mind? Write it here'
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    // I'm simulating the response from the sentiment API here
    // We will pass event.target.value in our request in an async function
    // If there is hate speech it'll return 1
    // otherwise it'll return 0
    const sentiment = Math.floor(Math.random() * 2);

    if (event.target.value.length > 0 && !sentiment) {
      this.setState({
        value: event.target.value,
        bsStyle: 'success',
        disabled: false
      });
    } else if (event.target.value.length > 0 && sentiment) {
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
      <Form onSubmit={this.handleSubmit}>
        <FormGroup controlId="formControlsTextarea" bsSize="large">
          <FormControl componentClass="textarea" style={{height: '300px', marginTop: '50px'}} value={this.state.value} onChange={this.handleChange} placeholder={this.state.placeholder} />
        </FormGroup>
        <Button type="submit" bsStyle={this.state.bsStyle} bsSize="large" disabled={this.state.disabled} block>POST ON MY FACEBOOK WALL</Button>
      </Form>
    );
  }
}