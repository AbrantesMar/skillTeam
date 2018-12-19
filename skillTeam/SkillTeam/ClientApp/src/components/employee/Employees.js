import React, { Component } from "react";
import Employee from "../../models/Employee";

export class Employees extends Component {
    displayName = Employees.name

    constructor(props){
        super(props);
        this.state = { employees: [], loading: true };

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
                        <tr key={employee.Id}>
                            <td>{employee.Description}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render(){
        let contents = this.state.loading
            ? <p><em>loading...</em></p>
            : Employee.renderEmployeesTable(this.state.employees);
        
        return (
            <div>
                <h1>Employees:</h1>
                {contents}
            </div>
        )
    }
}