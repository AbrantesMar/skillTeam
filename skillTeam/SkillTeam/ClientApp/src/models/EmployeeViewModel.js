import { types } from "mobx-state-tree";

const EmployeeViewModel = types
    .model("EmployeeViewModel", {
        Employees: types.optional(types.array(Employee))
        , SelectEmployee: types.reference(Employee)
    })
    .actions()
    .views()

export default EmployeeViewModel;