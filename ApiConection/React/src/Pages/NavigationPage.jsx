import React from 'react';
import { Route, BrowserRouter as Router, Switch, Link, Redirect } from 'react-router-dom';
import { HomePage } from './HomePage';
import { PrivateRoute, ListItemLink } from '../Components';
import { DashboardPage } from './PlaneacionPages';
import {
    Button, makeStyles, CssBaseline,
    Drawer, AppBar, Toolbar, IconButton,
    createStyles, List, Divider, ListItem
} from '@material-ui/core';
import { autenticationService } from '../Services';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import MenuIcon from "@material-ui/icons/Menu";
import ExitToAppIcon from '@material-ui/icons/ExitToApp';

import clsx from 'clsx';
import { mainroutes } from './autorized.routes';

const drawerWidth = 200;
const useStyles = makeStyles((theme) =>
    createStyles({
        root: {
            display: 'flex',
        },
        appBar: {
            zIndex: theme.zIndex.drawer + 1,
        },
        drawer: {
            width: drawerWidth,
            flexShrink: 0,
            whiteSpace: 'nowrap'
        },
        drawerOpen: {
            width: drawerWidth,
            transition: theme.transitions.create('width', {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.enteringScreen
            }),
        },
        drawerClose: {
            transition: theme.transitions.create('width', {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.leavingScreen
            }),
            overflowX: 'hidden',
            width: theme.spacing(7) + 1,
            [theme.breakpoints.up('sm')]: {
                width: theme.spacing(7.5) + 1,
            },
        },
        mainToolBar: {
            paddingLeft: 65
        },
        content: {
            flexGrow: 1,
            margin: theme.spacing(1)
        },
        menuButton: {

        },
        grow: {
            flexGrow: 1
        },
        gutters: {
            paddingLeft: 5,
            ...theme.gutters
        }
    })
);

function NavigationPage(props) {
    const classes = useStyles();
    const mainRoutes = mainroutes;


    // State y funciones para el manejo de apertura del drawer
    const [open, setOpen] = React.useState(false);
    const handleDrawerOpen = () => {
        setOpen(true);
    };
    const handleDrawerClose = () => {
        setOpen(false);
    };




    return (
        <div className={classes.root}>
            <CssBaseline />
            <Drawer
                variant="permanent"
                className={clsx(classes.drawer, { [classes.drawerOpen]: open, [classes.drawerClose]: !open })}
                classes={{ paper: clsx({ [classes.drawerOpen]: open, [classes.drawerClose]: !open, }), }}>


                <div style={{ display: 'flex', flexDirection:'column', flex: '1 1 100%' }}>
                    <AppBar position="relative">
                        <Toolbar classes={{ gutters: classes.gutters }} >
                            <div className={classes.grow} />
                            <IconButton color="inherit"
                                onClick={open ? handleDrawerClose : handleDrawerOpen}
                                edge="end"
                                className={classes.menuButton}>
                                {open ? <ArrowBackIcon /> : <MenuIcon />}
                            </IconButton>

                        </Toolbar>
                    </AppBar>
                    <List>
                        {
                            mainRoutes.map((route, index) => (
                                <ListItemLink
                                    key={index}
                                    to={`${props.match.url}${route.path}`}
                                    icon={<route.icon />}
                                    primary={route.label}
                                />
                            ))
                        }
                    </List>
                    <Divider />
                    <div style={{
                        flex: '1 1 100%'
                    }} ></div>
                    <List>
                        <ListItemLink
                            key={0}
                            to={'/'}
                            onClick={autenticationService.logout}
                            icon={<ExitToAppIcon />}
                            primary="Salir"
                        />
                    </List>

                </div>
            </Drawer>
            <main style={{ position: 'relative', width: '100%', height: 'Calc(100vh - 16px)' }} className={classes.content}>

                <Switch>
                    {
                        mainRoutes.map((route, index) => {
                            if (route.roles == null) {
                                return (<Route key={index} exact={route.exact} path={`${props.match.path}${route.path}`} component={route.main} />)
                            } else {
                                return (<PrivateRoute key={index} exact={route.exact} roles={route.roles} path={`${props.match.path}${route.path}`} component={route.main} />)
                            }
                        }
                        )
                    }
                </Switch>
            </main>
        </div>
        // <div>
        //     <ul>
        //         <li key="1">
        //             <Link to={`${props.match.url}/dashboard`}>dashboard</Link>
        //         </li>
        //         <li key="2">
        //             <Link to={`${props.match.url}/home`} >home</Link>
        //         </li>
        //         <li key="3">
        //             <Button onClick={autenticationService.logout}>Cerrar Sesion</Button>
        //         </li>
        //     </ul>
        //     <Route path={`${props.match.path}/`}>
        //         <Redirect to={`${props.match.path}/home`} />
        //     </Route>
        //     <Route path={`${props.match.path}/home`} component={HomePage} />
        //     <PrivateRoute path={`${props.match.path}/dashboard`} component={DashboardPage} />
        // </div>
    )
}

export { NavigationPage }
