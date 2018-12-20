import React, { Component } from "react";
//import Employee from "../../models/Employee";

export class Employees extends Component {
    displayName = Employees.name

    constructor(props) {
        super(props);
        this.state = { employees: [], loading: true };

        fetch('api/Employee')
            .then(response => response.json())
            .then(data => {
                this.setState({ employees: data, loading: false });
            });
    }

    static renderEmployeesTable(employees){
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map(employee => 
                        <tr key={employee.id}>
                            <td>{employee.description}</td>
                            <td>
                                <button>Edit</button>
                                <button>Excluir</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render(){
        let contents = this.state.loading
            ? <p><em>loading...</em></p>
            : Employees.renderEmployeesTable(this.state.employees);
        
        return (
            <div>
                <h1>Employees:</h1>
                {contents}
            </div>
        )
    }
}