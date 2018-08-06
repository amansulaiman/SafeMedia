import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from '../components/Layout';
import { Home } from '../components/Home';
import { SafeGroups } from '../components/SafeGroups';
import { ReportHateSpeech } from '../components/ReportHateSpeech';
import FacebookLogin from 'react-facebook-login';
import { DataPrivacy } from '../components/DataPrivacy';
import { GroupFeed } from '../components/GroupFeed';

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
            feed: '',
            groups: ''
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
            feed: response.feed,
            groups: response.groups
        });
    }

    render() {
        if (this.state.isLoggedIn) {
            return (
                <Layout>
                    <Route exact path='/' render={()=><Home id={this.state.userID} accessToken={this.state.accessToken} feed={this.state.feed} />} />
                    <Route exact path='/safegroups' render={()=><SafeGroups id={this.state.userID} accessToken={this.state.accessToken} groups={this.state.groups} />} />
                    <Route path='/reporthatespeech' component={ReportHateSpeech} />
                    <Route path='/dataprivacy' component={DataPrivacy} />
                    <Route exact path='/safegroups/:id' component={GroupFeed} />
                </Layout>
            );
        } else {
            return (
                <div className="fb-login">
                    <FacebookLogin
                        appId="1453670621367042"
                        autoLoad={true}
                        fields="name,email,picture,feed,groups"
                        scope="public_profile,groups_access_member_info"
                        version="2.10"
                        onClick={this.componentClicked}
                        callback={this.responseFacebook}
                        icon="fa-facebook" />
                </div>
            );
        }
    }
}