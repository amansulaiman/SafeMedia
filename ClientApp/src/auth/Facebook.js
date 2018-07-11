import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from '../components/Layout';
import { Home } from '../components/Home';
import { FetchData } from '../components/FetchData';
import { Counter } from '../components/Counter';
import { Messages } from '../components/Messages';
import FacebookLogin from 'react-facebook-login';

export default class Facebook extends Component {
    displayName: 'Hello';
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
        if (this.state.isLoggedIn) {
            return (
                <Layout>
                    <Route exact path='/' render={()=><Home id={this.state.userID} accessToken={this.state.accessToken} feed={this.state.feed} />} />
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetchdata' component={FetchData} />
                    <Route path='/messages' component={Messages} />
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