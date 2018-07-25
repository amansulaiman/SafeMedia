import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from '../components/Layout';
import { Home } from '../components/Home';
import { SafeMessages } from '../components/SafeMessages';
import { ReportHateSpeech } from '../components/ReportHateSpeech';
import FacebookLogin from 'react-facebook-login';
import { DataPrivacy } from '../components/DataPrivacy';
export default class Facebook extends Component {
    displayName = Facebook.name;
    constructor(props) {
        super(props);
        this.state = {
            isLoggedIn: false,
            userID: '',
            accessToken: '',
            name: '',
            email: '',
            picture: '',
            feed: ''
        }
    }
    
    componentClicked = () => console.log('Component clicked');

    responseFacebook = response => {
        console.log(response);
        this.setState({
            isLoggedIn: true,
            userID: response.userID,
            accessToken: response.accessToken,
            name: response.name,
            email: response.email,
            picture: response.picture.data.url,
            feed: response.feed
        });
    }

    render() {
        if (!this.state.isLoggedIn) {
            return (
                <Layout>
                    <Route exact path='/' render={()=><Home id={this.state.userID} accessToken={this.state.accessToken} feed={this.state.feed} />} />
                    <Route path='/safemessages' component={SafeMessages} />
                    <Route path='/reporthatespeech' component={ReportHateSpeech} />
                    <Route path='/dataprivacy' component={DataPrivacy} />
                </Layout>
            );
        } else {
            return (
                <div className="fb-login">
                    <FacebookLogin
                        appId="1453670621367042"
                        autoLoad={true}
                        fields="name,email,picture,feed"
                        scope="public_profile,publish_actions"
                        version="2.10"
                        onClick={this.componentClicked}
                        callback={this.responseFacebook}
                        icon="fa-facebook" />
                </div>
            );
        }
    }
}