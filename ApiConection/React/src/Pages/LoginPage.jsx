import React from 'react';
import { Button, CssBaseline, Container, Typography, Avatar, TextField, Snackbar } from '@material-ui/core'
import { createMuiTheme, ThemeProvider, makeStyles } from '@material-ui/core/styles'
import LockOutlinedIcon from '@material-ui/icons/LockOutlined'
import { Formik, Form } from 'formik'
import * as Yup from 'yup';
import login_background from '../Assets/loginBackground.png';
import { autenticationService } from '../Services';
import { teal, yellow, orange, pink } from '@material-ui/core/colors';
import { Alert } from '@material-ui/lab';
// Configuro tema para pagina Login
const themeLocal = createMuiTheme({
    palette: {
        type: 'dark',
        primary: {
            main: yellow[700]
        },
        secondary: {
            main: teal[500]
        },
        error: {
            main: pink['A400']
        }
    }
})

// Agrego estilos para la pagina Login
const useStyles = makeStyles(theme => ({
    paper: {
        marginTop: theme.spacing(2),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        // margin: theme.spacing(1),
        background: orange[500]
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        //  marginTop: theme.spacing(1),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
    page_backgroud: {
        background: `url(${login_background})`,
        backgroundSize: 'cover',
        backgroundPosition: "center",
        position: 'fixed',
        zIndex: 0,
        width: '100%',
        height: '100%',
        top: '0',
        left: '0',
        '&::before': {
            background: '#000',
            opacity: '0.85',
            width: '100%',
            height: '100%',
            position: "absolute",
            left: 0,
            bottom: 0,
            content: '""',
            zIndex: '-1'
        }
    }
}));

// Creo el objeto para la configuracion con `Yup` para Formik
const validationFormLogin = Yup.object().shape({
    username: Yup.string().required('El usuario es requerido'),
    password: Yup.string().required('No se ha indicado la contraseña')
})

// Configuro valores iniciales para el Formik
const initialValuesLogin = {
    username: '',
    password: ''
}

// Genero el componente mediante funcion
function LoginPage(props) {
    // Configuro los estilos para la pagina Login
    const classes = useStyles();

    // Configuro el handled para el submit del form
    const submitForm = ({ username, password }, { setStatus, setSubmitting }) => {
        setStatus();

        // Utilizo el servicio para el inicio de sesion
        autenticationService.login(username, password)
            .then(
                // Si se inicio correctamente, redirecciono a la pagina home
                user => {
                    const { from } = props.location.state || { from: { pathname: "/" } };
                    props.history.push(from);
                },

                // Si ocurrio un error, cambio el estado del Formik
                error => {
                    console.log(error);
                    setSubmitting(false);
                    setStatus(error);
                }
            )
    }

    return (
        <ThemeProvider theme={themeLocal}>
            <CssBaseline />
            <main className={classes.page_backgroud}>
                <Container component="main" maxWidth="xs">
                    <div className={classes.paper}>
                        <Avatar className={classes.avatar}>
                            <LockOutlinedIcon />
                        </Avatar>
                        <Typography component="h1" variant="h5">Iniciar Sesión</Typography>
                        <Formik
                            initialValues={initialValuesLogin}
                            validationSchema={validationFormLogin}
                            onSubmit={submitForm}>
                            {({ errors, handleChange, touched, status, setStatus, submitCount }) => (
                                <div>
                                    <Form className={classes.form}>
                                        <TextField
                                            error={touched.username && errors.username != null}
                                            helperText={errors.username}
                                            onChange={handleChange}
                                            margin="normal"
                                            id="username"
                                            name="username"
                                            variant="outlined"
                                            fullWidth
                                            autoFocus
                                            label="Usuario"
                                        />
                                        <TextField
                                            error={touched.password && errors.password != null}
                                            helperText={errors.password}
                                            onChange={handleChange}
                                            type="password"
                                            margin="normal"
                                            id="password"
                                            name="password"
                                            variant="outlined"
                                            fullWidth
                                            autoFocus
                                            label="Contraseña"
                                        />
                                        <Button
                                            type="submint"
                                            fullWidth color="primary"
                                            className={classes.submit}
                                            variant="contained"
                                        >Entrar
                                            </Button>
                                    </Form>
                                    <Snackbar open={submitCount > 0 && status !== null} autoHideDuration={6000} onClose={() => setStatus(null)} >
                                        <Alert variant="filled" severity="error" >{status}</Alert>
                                    </Snackbar>
                                </div>
                            )}
                        </Formik>
                    </div>
                </Container>
            </main>
        </ThemeProvider>
    )
}


// Exporto la clase
export { LoginPage }
