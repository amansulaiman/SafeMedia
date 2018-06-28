import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from '../components/Layout';
import { Home } from '../components/Home';
import { FetchData } from '../components/FetchData';
import { Counter } from '../components/Counter';
import { Messages } from '../components/Messages';
import FacebookLogin from 'react-facebook-login';

export default class Facebook extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoggedIn: false,
            userID: '',
            name: '',
            email: '',
            picture: ''
        }
    }
    
    componentClicked = () => console.log('Component clicked');

    responseFacebook = response => {
        this.setState({
            isLoggedIn: true,
            userID: response.userID,
            name: response.name,
            email: response.email,
            picture: response.picture.data.url
        });
    }

    render() {
        let fbContent;
        
        if (this.state.isLoggedIn) {
            fbContent = (
                <Layout>
                    <Route exact path='/' render={()=><Home name={this.state.name} picture={this.state.picture} email={this.state.email} />} />
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetchdata' component={FetchData} />
                    <Route path='/messages' component={Messages} />
                </Layout>
            );
        } else {
            fbContent = (
                <FacebookLogin
                    appId="1572110139564731"
                    autoLoad={true}
                    fields="name,email,picture"
                    onClick={this.componentClicked}
                    callback={this.responseFacebook} />
            );
        }

        return (
            <div className='main'>
                {fbContent}
            </div>
        );
    }
}