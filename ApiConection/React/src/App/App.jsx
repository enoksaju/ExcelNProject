import React from 'react';
import { Card, CssBaseline } from '@material-ui/core';
import { autenticationService } from '../Services';
import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom';
import { history } from '../Helpers';
import { PrivateRoute } from '../Components';
import { LoginPage, NavigationPage } from '../Pages';


class App extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      currenUser: null,
      isAdmin: false
    }
  }

  componentDidMount() {
    // Modificar estatus del APP desde el servicio de Autenticación
    autenticationService.currentUser.subscribe(x =>
      this.setState({
        currenUser: x, isAdmin: x && x.role === 'Admin'
      }));
  }

  logout() {
    autenticationService.logout();
    history.push('/login');
  }

  render() {
    const { currenUser, isAdmin } = this.state;
    return (
      <Router>
        <Switch>
          <Route exact path="/">
            <Redirect to="/app" />
          </Route>
          <PrivateRoute path="/app" component={NavigationPage} />
          <Route path="/login" component={LoginPage} />
        </Switch>
      </Router>
    )
  }
}
export { App };
