import { BehaviorSubject } from 'rxjs';

import { handleResponse } from '../Helpers';

const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));
const currentUserDataSubject = new BehaviorSubject(
  localStorage.getItem('currentUser') ?
    JSON.parse(JSON.parse(localStorage.getItem('currentUser')).data) : null
);

export const autenticationService = {
  login,
  logout,
  currentUser: currentUserSubject.asObservable(),
  currentUserData: currentUserDataSubject.asObservable(),
  get curretUserValue() { return currentUserSubject.value },
  get currentDataUserValue() { return currentUserDataSubject.value }
}

function login(username, password) {
  const requestOptions = {
    method: 'post',
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    body: `username=${username}&password=${password}&grant_type=password` //JSON.stringify({ username, password })
  };

  return fetch(`/TOKEN`, requestOptions)
    .then(handleResponse)
    .then(user => {
      localStorage.setItem('currentUser', JSON.stringify(user));
      currentUserSubject.next(user);
      currentUserDataSubject.next(JSON.parse(user.data));
      return user;
    })
}

function logout() {
  localStorage.removeItem('currentUser');
  currentUserSubject.next(null);
}


