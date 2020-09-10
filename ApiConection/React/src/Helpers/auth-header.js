import { autenticationService } from '../Services';

export function authHeader() {
  const currenUser = autenticationService.curretUserValue;

  if (currenUser && currenUser.access_token) {
    return { Authorization: `Bearer ${currenUser.access_token}` };
  } else {
    return {};
  }
}
