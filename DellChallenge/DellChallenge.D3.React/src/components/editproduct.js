import React, { Component, PropTypes } from "react";
import { Redirect } from "react-router-dom";
import Validation from "../validation";

class EditProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Id: this.props.Id,
      Name: this.props.Name,
      Category: this.props.Category,
      Success: false,
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }  
  
  componentWillReceiveProps(data) {
      this.setState({Id: data.Id});
      this.setState({Name: data.Name});
      this.setState({Category:data.Category});
  }
  
  componentDidMount() {
	  const { id } = this.props.match.params;
      fetch("http://localhost:2534/api/products/" + id)
      .then(
        result => {
          this.setState({
            Id: result.Id,
			Name: result.Name,
			Category: result.Category,
          });
        }
      );
  }
  
  handleSubmit = event => {
    event.preventDefault();
		let id = this.state.Id;
		let postData = {
		  Name: this.state.Name,
		  Category: this.state.Category
		};

		fetch("http://localhost:2534/api/products/" + id, {
		  method: "PUT",
		  headers: {
			Accept: "application/json",
			"Content-Type": "application/json"
		  },
		  mode: "cors",
		  body: JSON.stringify(postData)
		})
		.then(res => res.json())
		.then(this.props.history.push('/products'))
		.catch(err => console.log(err));	
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <h4>Edit Product</h4>
        <div className="form-group">
		  <input
		    className="form-control"
			type="hidden"
			id="Id"
			name="Id"
			value={this.state.ID}
		  />
          <label className="control-label" htmlFor="Name">
            Name
          </label>
          <input
            className="form-control"
            type="text"
            id="Name"
            name="Name"
            onChange={this.handleInputChange}
            value={this.state.Name}
			required
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Name"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <label className="control-label" htmlFor="Category">
            Category
          </label>
          <input
            className="form-control"
            type="text"
            id="Category"
            name="Category"
            onChange={this.handleInputChange}
            value={this.state.Category}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Category"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <button className="btn btn-primary">Update</button>
        </div>
        <Validation />
      </form>
    );
  }
}

export default EditProduct;
