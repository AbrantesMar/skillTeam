import React, { Component } from "react";
import EmployeeViewModel from "./../../models/EmployeeViewModel";

export class CreateEmployee extends Component{
    displayName = CreateEmployee.name

    render(){
        const { employee } = this.props;
        return (
            <form
                onSubmit={e =>{
                    e.preventDefault();
                    employee.item
                }}
            >
                <label for='name'>Name Employee:</label>
                <input type='text' name='name'></input>
                <label>Name Employee:</label>
                <input type='text'></input>
            </form>
        );
    }
}

