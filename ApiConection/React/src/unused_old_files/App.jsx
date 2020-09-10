import React from "react";
import PropTypes from 'prop-types';
import { hot } from "react-hot-loader";
import './App.css'
import {
  AppBar,
  Toolbar,
  Typography,
  IconButton,
  Slide,
  Box,
  Drawer,
  createStyles,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Divider
} from "@material-ui/core";
import useScrollTrigger from '@material-ui/core/useScrollTrigger';
import CssBaseline from "@material-ui/core/CssBaseline";
import clsx from 'clsx';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import {
  TransitionGroup,
  CSSTransition
} from "react-transition-group";

import {
  BrowserRouter as Router,
  Switch,
  Route, Redirect, useLocation
} from "react-router-dom";

import { routes } from "./routes.jsx";
import ListItemLink from "./ListItemLink";

import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import MenuIcon from "@material-ui/icons/Menu";
import Login from "./Login/LoginComponent";
import { PrivateRoute } from "./Services/AuthService";

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
)



function HideOnScroll(props) {
  const { children, window } = props;
  const trigger = useScrollTrigger({ target: window ? window() : undefined });
  return (
    <Slide appear={false} direction="down" in={!trigger}>
      {children}
    </Slide>
  )

}

HideOnScroll.propTypes = {
  children: PropTypes.element.isRequired,
  // window: PropTypes.func,
}



function DashBoard(props) {
  const location = useLocation();
  const classes = useStyles();
  const theme = useTheme();
  const [open, setOpen] = React.useState(false);

  // const matches = useMediaQuery(theme.breakpoints.up("sm"));
  // const drawerType = () => {
  //   return matches ? "permanent" : "temporary";
  // };
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
        className={clsx(classes.drawer, {
          [classes.drawerOpen]: open,
          [classes.drawerClose]: !open
        })}
        classes={{
          paper: clsx({
            [classes.drawerOpen]: open,
            [classes.drawerClose]: !open,
          }),
        }}>

        <div>
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
            {routes.map((route, index) => (
              <ListItemLink
                key={index}
                to={route.path}
                primary={route.primary}
                icon={<route.icon />}
              // onClick={!matches ? handleDrawerClose : () => { }}
              />
            ))}
          </List>
        </div>
      </Drawer>
      <main style={{ position: 'relative', width: '100%', height: 'Calc(100vh - 16px)' }} className={classes.content}>
        <TransitionGroup >

          <CSSTransition
            key={location.key}
            classNames="fade"
            timeout={300}>

            <Switch location={location}>
              {routes.map((route, index) => (

                !route.private ?
                  <Route
                    style={{ position: 'absolute' }}
                    key={index}
                    path={route.path}
                    exact={route.exact}>
                    <Box style={{
                      position: 'absolute',
                      top: 0,
                      bottom: 0,
                      background: theme.palette.background.default
                    }} children={<route.main />}>

                    </Box>
                  </Route> :
                  <PrivateRoute
                    style={{ position: 'absolute' }}
                    key={index}
                    path={route.path}
                    exact={route.exact}>
                    <Box style={{
                      position: 'absolute',
                      top: 0,
                      bottom: 0,
                      background: theme.palette.background.default
                    }} children={<route.main />}>

                    </Box>
                  </PrivateRoute>
              ))}
              <Route path="*">
                Pagina no encontrada!!!
            </Route>
            </Switch>

          </CSSTransition>

        </TransitionGroup>
      </main>
    </div>
  );
}


function App() {
  return (
    <Router>
      <Switch>

        <Route exact path="/">
          <Redirect to="/Home" />
        </Route>

        <Route path="/login">
          <Login></Login>
        </Route>

        <Route path="*">
          <DashBoard />
        </Route>

      </Switch>
    </Router>
  )
}


export default hot(module)(App);
