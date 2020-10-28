import React from 'react';
import './Customers.scss';

import customerData from '../../../helpers/data/customerdata';
import SingleCustomer from '../../shared/SingleCustomer/SingleCustomer';

class Customers extends React.Component {
  state = {
    customers: [],
  }

  componentDidMount() {
    customerData.getAllCustomers()
      .then((customers) => this.setState({customers}));
  }

  render() {
    const {customers} = this.state;
    const buildCustomers = customers.map((customer) => {
      return (<SingleCustomer key={customer.id} customer={customer}/>)
    });

    return (
      <div className="Customers">
        {buildCustomers}
      </div>
    );
  }
}

export default Customers;