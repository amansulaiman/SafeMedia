import React, { Component } from 'react';
import { Form, FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';

export class Home extends Component {
  displayName = Home.name

  constructor(props) {
    super(props);
    this.state = {value: ''};

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({value: event.target.value});
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
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <FormGroup controlId="formControlsTextarea" validationState="success" bsSize="large">
          <ControlLabel>Textarea</ControlLabel>
          <FormControl componentClass="textarea" value={this.state.value} onChange={this.handleChange} placeholder="textarea" />
        </FormGroup>
        <Button type="submit">Submit</Button>
      </form>
    );
  }
}