import React, { Suspense, lazy } from "react";
import DashboardIcon from "@material-ui/icons/Dashboard";
import HomeIcon from "@material-ui/icons/Home";
const Home = lazy(() => import('./HomeComponent'));

export const routes = (
  [
    {
      path: "/Home",
      exact: true,
      primary: "Home",
      private: true,
      icon: () => <HomeIcon />,
      main: () => <Suspense fallback={<div>Loading...</div>}><Home /></Suspense>,
    },
    {
      path: "/About",
      exact: true,
      primary: "About",
      private: false,
      icon: () => <DashboardIcon />,
      main: () => <h2>About</h2>,
    },
    {
      path: "/Bubble",
      exact: true,
      private: false,
      primary: "Bubble",
      icon: () => <DashboardIcon />,
      main: () => <h2>Bubble</h2>,
    },
  ]);

export default routes;
