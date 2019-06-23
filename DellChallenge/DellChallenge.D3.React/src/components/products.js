import React, { Component } from "react";
import Validation from "../validation";

class ProductList extends React.Component {
  constructor() {
    super();
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

	editItem = productId => {
	  fetch("http://localhost:5000/api/products/" + productId)
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
        }
      );
	}

	deleteItem = productId => {
	  const requestOptions = {
		method: 'DELETE'
	  };

	  fetch("http://localhost:5000/api/products/" + productId, requestOptions).then(() => {
		window.location.reload();
	  });
	}

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
	  <table>
		<tr>
			<th><b>Category</b></th>
			<th><b>Name</b></th>
		</tr>
            {items.map(item => (			
				<tr>
					<td>
					{item.category}
					</td>
					<td>
					{item.name}
					</td>
					<td>
					   <a href={"/editproduct/" + item.id}>Edit</a>
					</td>
					<td>
					   <button onClick={() => { this.deleteItem(item.id) }}>Delete</button>
					</td>
				</tr>
            ))}
        </table>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
