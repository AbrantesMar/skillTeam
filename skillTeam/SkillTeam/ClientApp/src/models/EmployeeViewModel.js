import { types } from "mobx-state-tree";

const EmployeeViewModel = types
    .model("EmployeeViewModel", {
        Employees: types.optional(types.array(Employee))
        , Employee: types.reference(Employee)
    })
    .actions(self =>({
        create(){
            self.push()
            /*fetch("api/Employee/employee", {
                method: "post",
                body(self.Employee)
            })*/
        }
    }))
    .views()

export default EmployeeViewModel;