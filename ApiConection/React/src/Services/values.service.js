import { authHeader, handleResponse } from '../Helpers';

export const valuesService = {
    get
}

function get() {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    return fetch(`/api/values`, requestOptions)
        .then(handleResponse);
}
