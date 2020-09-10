import React, { Suspense } from 'react';
import { HomePage } from '.';
import {
    Home as HomeIcon,
    Dashboard as DashboardIcon
} from '@material-ui/icons';
import { DashboardPage } from './PlaneacionPages';

const mainroutes = (
    [
        {
            path: "",
            exact: true,
            label: "Home",
            roles: null,
            icon: () => <HomeIcon />,
            main: () => <Suspense fallback={<div>Loading...</div>}><HomePage /></Suspense>,
        },
        {
            path: "/dashboard",
            exact: false,
            label: "Dashboard",
            roles: ["Administrador Produccion", "Supervisor Produccion", "Develop", "Sistemas", "Administrador"],
            icon: () => <DashboardIcon />,
            main: () => <Suspense fallback={<div>Loading...</div>}><DashboardPage /></Suspense>,
        }
    ]
)



export { mainroutes }
