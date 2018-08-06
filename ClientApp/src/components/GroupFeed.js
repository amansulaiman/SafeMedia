import React, { Component } from 'react';
import { Redirect, Link } from 'react-router-dom';

export class GroupFeed extends Component {
  displayName = GroupFeed.name

  constructor(props) {
    super(props);

    this.state = {
      feeds: [],
      isHateSpeech: false
    }
  }

  isHateSpeech(message) {
    Promise.resolve((async () => {
      return await fetch(`/api/SentimentAnalysis?sentiment=${message}`).then(res => res.json());
    })()).then(data => {
      this.setState({
        isHateSpeech: data.isHateSpeech
      });
    })
  }

  componentDidMount() {
    if (this.props.location.referrer !== undefined) {
      const url = `https://graph.facebook.com/v2.10/${this.props.location.referrer.groupId}/feed?access_token=${this.props.location.referrer.token}`;
      
      fetch(url)
      .then(res => res.json())
      .then(feed => (
        this.setState({
          feeds: feed.data
        })
      ))
    }
  }

  render() {
    if (this.props.location.referrer === undefined) {
      return (
        <Redirect to='/safegroups' />
      )
    } else {
      return (
        <div>
          <Link to='/safegroups'>Back</Link>
          {
            (this.state.feeds === undefined || this.state.feeds.length === 0) ?
            <div>
              It appears that this app does not have admin level permission in your group
            </div>
            :
            this.state.feeds.filter(obj => {
              return obj.message !== undefined;
            })
            .filter(msgObj => {
              this.isHateSpeech(msgObj.message);
              return this.state.isHateSpeech;
            })
            .map((msgObj, index) => {
              return <div key={index}>{msgObj.message}</div>
            })
          }
        </div>
      );
    }
  }
}