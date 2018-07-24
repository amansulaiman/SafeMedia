import React, { Component } from 'react';
import { Form, FormGroup, FormControl, Button, Row, Col } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class ReportHateSpeech extends Component {
  displayName = ReportHateSpeech.name

  constructor(props) {
    super(props);

    this.state = {
      bsStyle: 'success',
      disabled: false,
      placeholder: 'Have you find any speech hateful in nature? Report it here'
    };

    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleSubmit(event) {
    event.preventDefault();
    
    const url = '/api/SentimentAnalysis';
    const data = {
      hateText: event.target.hateText.value,
      source: event.target.source.value,
      evidanceLink: event.target.evidanceLink.value,
      target: event.target.target.value,
      language: Number(event.target.language.value),
      category: Number(event.target.category.value)
    };

    fetch(url, {
      method: 'POST',
      body: JSON.stringify(data),
      headers: {'Content-Type': 'application/json'}
    }).then(res => res.json())
    .catch(error => console.error('Error:', error))
    .then(response => console.log('Success:', response));

    event.target.hateText.value = '';
    event.target.source.value = '';
    event.target.evidanceLink.value = '';
    event.target.target.value = '';
    event.target.language.value = '';
    event.target.category.value = '';

  }

  render() {
    return (
      <div>
         <h2 style={{ fontSize: 28, fontFamily: "Patua One, cursive", color:"#4189C7"}}>Help us capture all hate speech</h2>
        <Form onSubmit={this.handleSubmit}>
          <FormGroup controlId="formControlsTextarea" bsSize="large">
            <Row>
              <Col sm={12}>
                <FormControl type="multitext" componentClass="textarea" placeholder={this.state.placeholder} name='hateText' required/>
              </Col>
            </Row>
            <Row style={{marginTop: '10px'}}>
              <Col sm={12}>
                <FormControl type="url" placeholder="Evidence Link e.g https://web.facebook.com/ameenukano585/posts/1987380447959756" name='evidanceLink' required/>
              </Col>
            </Row>
            <Row>
              <Col sm={6} style={{marginTop: '10px'}}>
                <FormControl type="text" placeholder="Source e.g Facebook" bsSize="large" name='source' required/>
              </Col>
              <Col sm={6} style={{marginTop: '10px'}}>
                <FormControl type="text" placeholder="Target e.g Government, Police" name='target' required/>
              </Col>
            </Row>
            <Row>
              <Col sm={6} style={{marginTop: '10px'}}>
                <FormControl componentClass="select" placeholder="language" name='language' required>
                  <option value="">Select Language</option>
                  <option value="0">Hausa</option>
                  <option value="1">English</option>
                </FormControl>
              </Col>
              <Col sm={6} style={{marginTop: '10px'}}>
                <FormControl componentClass="select" placeholder="category" name='category' required>
                  <option value="">Select Category</option>
                  <option value="0">Gender Based Violence</option>
                  <option value="1">Farmers/Herdsmen</option>
                  <option value="2">Ethnicity</option>
                  <option value="3">Poverty</option>
                  <option value="4">Biafra</option>
                  <option value="5">Election</option>
                  <option value="6">Intra Religious</option>
                  <option value="7">Boko Haram</option>
                  <option value="8">Inter Religious</option>
                  <option value="9">Politics</option>
                  <option value="10">Others</option>
                </FormControl>
              </Col>
            </Row>
          </FormGroup>
                <Button style={{fontFamily: "Open Sans, sans-serif"}} type="submit" bsStyle={this.state.bsStyle} bsSize="large" disabled={this.state.disabled} block>SUBMIT HATE SPEECH <FontAwesomeIcon icon="arrow-right"/></Button>
        </Form>
      </div>
    );
  }
}
