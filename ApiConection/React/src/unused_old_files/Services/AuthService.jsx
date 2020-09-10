import axios from 'axios';
import { Route, Redirect, useHistory } from 'react-router-dom';
import React from 'react';

const httpInstance = axios.create({
  baseURL: 'api/'
});

httpInstance.interceptors.request.use(
  config => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers['Authorization'] = 'Bearer ' + token;
    }
    return config
  },
  error => {
    Promise.reject(error)
  }
);

httpInstance.interceptors.response.use(response => {
  return response
}, err => {
  const originalRequest = err.config;
  if (err.response.status === 401 && err.config && !err.config.__isRetryRequest) {
    originalRequest._retry = true;

    let __refresh_token = localStorage.getItem('refresh_token');

    return axios.post('/TOKEN', 'refresh_token=' + __refresh_token + '&grant_type=refresh_token', {
      headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
    })
      .then(
        res => {
          if (res.status === 200) {
            localStorage.setItem("token", res.data.access_token);
            localStorage.setItem("refresh_token", res.data.refresh_token);
            originalRequest.headers['Authorization'] = 'Bearer ' + localStorage.getItem("token");
            return axios(originalRequest);
          }
        }, err => {
          const history = useHistory();
          history.push('/Login');
        }
      )
  }
});



const AuthService = {
  Login: (username, password, callback) => {
    return new Promise((resolve, rejected) => {
      return axios.post('/TOKEN',
        'username=' + username +
        '&password=' + password +
        '&grant_type=password',
        { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
        .then(res => {
          localStorage.setItem("token", res.data.access_token);
          localStorage.setItem("refresh_token", res.data.refresh_token);
          localStorage.setItem("isAutenticated", true);
          //AuthService.isAutenticated = true;
          callback();
        }, err => {
          localStorage.setItem("isAutenticated", false);
          //AuthService.isAutenticated = false;
        });
    })
  },
  LogOut: (callback) => {
    localStorage.clear();
    localStorage.setItem("isAutenticated", false);
    //AuthService.isAutenticated = false;
    callback;
  },
  isAutenticated: () => {
    let ret = localStorage.getItem("isAutenticated")
    console.log(ret);
    return ret == "false" ? false : true
  },
  httpInstance: httpInstance
}

export function PrivateRoute({ children, ...rest }) {
  return (<Route {...rest} render={({ location }) => AuthService.isAutenticated() ? (children) : (<Redirect to={{ pathname: "/login", state: { from: location } }} />)} />)
}

export default AuthService;
