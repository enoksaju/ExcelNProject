import React, { Component } from 'react';
import { Route, Redirect } from 'react-router-dom';

import { autenticationService } from '../Services';
import { forwardRef } from 'react';

function PrivateRoute({ component: Component, roles, ...rest }) {

  return (<Route {...rest} render={props => {

    const currentUser = autenticationService.curretUserValue;
    const currentDataUser = autenticationService.currentDataUserValue;

    if (!currentUser) {
      // Si no se a autenticado se direcciona a la pagina login
      return <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
    }

    if (roles) {
      for (var i = 0; i < currentDataUser.Roles.length; i++) {
        if (roles.indexOf(currentDataUser.Roles[i]) !== -1) {
          // Autorizado, regreso componente
          return <Component {...props} />
        }
      }
      // Rol de usuario no autorizado.
      return <Redirect to={{ pathname: '/app/home' }} />
    } else {
      // Autorizado, regreso componente
      return <Component {...props} />
    }

  }} />)
}

export { PrivateRoute };

