import React, { Component, render, useEffect, useState } from "react";
import { HomeWork as HomeWorkIcon } from "@material-ui/icons";
import { Card, CardHeader, CardContent, Typography } from "@material-ui/core";
import Axios from "axios";
import AuthService from "./Services/AuthService";


function Home() {

  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

  useEffect(() => {

    AuthService.httpInstance.get('values')
      .then(val => {
        setIsLoaded(true);
        setItems(val.data);
      }, error => {
        setIsLoaded(true);
        setError(error);
      }
      );
  }, [])

  if (error) {
    return (<div>Error: {error.message}</div>)
  } else if (!isLoaded) {
    return (<div>Loading...</div>)
  } else {

    return (
      <Card>
        <CardHeader title="Home Component"
          subheader="Show a Home Component Lazy loading">

        </CardHeader>
        <CardContent>
          {JSON.stringify(items)}
        </CardContent>
      </Card>)
  }
}

// class Home extends Component {
//   constructor(props) {
//     super(props);
//     this.state = {
//       error: null,
//       isLoaded: false,
//       items: []
//     };
//   }
//   componentDidMount() {
//     fetch('api/values')
//       .then(res => res.json())
//       .then(result => {
//         this.setState(
//           {
//             isLoaded: true,
//             items: result
//           }
//         )
//       }, error => {
//         this.setState({
//           isLoaded: true,
//           error
//         })
//       })
//   }

//   render() {
//     const { error, isLoaded, items } = this.state;
//     if (error) {
//       return <div>Error: {error.message}</div>
//     } else if (!isLoaded) {
//       return <div>Loading...</div>
//     } else {
//       return (
//         items
//       )
//     }
//   }

// }




export default Home;
