import React, { Component } from "react";
import ReactDOM from "react-dom";
import { AppContainer } from 'react-hot-loader';
import { App } from "./App";
import { BrowserRouter, Route } from "react-router-dom";

const render = Component => {
    ReactDOM.render(
        <AppContainer>
            <Component />
        </AppContainer>
        , document.getElementById("root"));
};

render(App);

if (module.hot) {
    module.hot.accept('./App', () => {
        render(App);
    });
}

