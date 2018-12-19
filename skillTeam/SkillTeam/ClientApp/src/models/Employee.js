import { types } from "mobx-state-tree";

const Employee = types
    .model("Employee", {
        Id: types.integer
        , Description: types.string
        , Skills: types.optional(types.array(Skill))
    })

export default Employee;
