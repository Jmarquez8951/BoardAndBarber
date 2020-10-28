import React from 'react';
import '../components/shared/SingleCustomer/SingleCustomer'
import Customers from '../components/pages/Customers/Customers'
import './App.scss';

class App extends React.Component {
  state
  render() {
    return (
      <div className="App">
        <Customers/>
      </div>
    );
  }
}


export default App;
