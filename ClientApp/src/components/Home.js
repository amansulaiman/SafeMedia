import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div style={{
          width: '400px',
          margin: 'auto',
          background: '#f4f4f4',
          padding: '20px'
      }}>
          <img src={this.props.picture} alt={this.props.name} />
          <h2>Welcome {this.props.name}</h2>
          Email: {this.props.email}
      </div>
    );
  }
}
