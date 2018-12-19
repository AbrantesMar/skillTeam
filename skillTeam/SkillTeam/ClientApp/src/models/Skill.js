import { types } from "mobx-state-tree";

const Skill = types
    .models("Skill", {
        Id: types.optional(types.integer)
        , Description: types.string
    })

export default Skill;