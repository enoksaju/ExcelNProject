import React, { useState } from 'react';
import { Card, TextField, Button, MuiThemeProvider } from '@material-ui/core';
import Axios from 'axios';
import AuthService from '../Services/AuthService';
import { useLocation, useHistory } from 'react-router-dom';


function Login() {

  let history = useHistory();
  let location = useLocation();

  const [usuario, setUsuario] = useState('');
  const [password, setPassword] = useState('');

  let { from } = location.state || { from: { pathname: "/" } };

  let login = () => {
    AuthService.Login(usuario, password, () => {
      history.replace(from);
    })
  };

  return (
    <div>
      <Card>
        <TextField label="Usuario" value={usuario} onChange={(e) => setUsuario(e.target.value)}></TextField>
        <br />
        <TextField label="Password" value={password} onChange={(e) => setPassword(e.target.value)}></TextField>
        <br />
        <Button color="primary" onClick={login} >LogIn</Button>
      </Card>
    </div>
  )
}

export default Login;
