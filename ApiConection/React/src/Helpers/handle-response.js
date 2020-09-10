import { autenticationService } from "../Services";


export function handleResponse(response) {
  return response.text().then(text => {
    if (!response.ok) {
      
      if ([401, 403].indexOf(response.status) !== -1) {
        autenticationService.logout();
        location.reload(true);
      }

      if ([500].indexOf(response.status) !== -1) {
        return Promise.reject('Error interno');
      }

      const data = text && JSON.parse(text);
      const error = (data && data.message) || (data && data.error_description) || response.statusText;
      console.log(error)
      return Promise.reject(error);
    }
    const data = text && JSON.parse(text);
    return data;
  });
}
