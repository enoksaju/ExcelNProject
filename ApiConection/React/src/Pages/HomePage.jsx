import React from 'react';

import { valuesService, autenticationService } from '../Services';
import { Button } from '@material-ui/core';

const HomePage = (props) => {
    // Agrego variables de estado al componente
    const [currentUser, setCurrentUser] = React.useState();
    const [values, setValues] = React.useState([]);


    // Use Efect similar a didmount, evento antes del load del componente
    React.useEffect(() => {
        // Indico que el componente se puede subscribir
        let isSubscribed = true;
        if (isSubscribed) {
            // Obtengo desde el servicio el usuuario actual y lo almaceno en el state currentUser
            setCurrentUser(autenticationService.curretUserValue);

            // Leno los datos desde la API
            valuesService.get().then((values) => {

                setValues(values)

            });
        }
        // Libero la subscripcion
        return () => isSubscribed = false;
    }, []);

    return (
        <div>
            <h1>Home Page</h1>
            {JSON.stringify(values)}
            {/* <Button onClick={() => { autenticationService.logout() }}>Cerrar Sesión</Button> */}
        </div>
    )
}

export { HomePage };
