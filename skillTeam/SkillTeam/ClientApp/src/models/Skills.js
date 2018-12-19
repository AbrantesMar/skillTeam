import { types } from "mobx-state-tree";

const Skills = types
    .models("Skills", {
        Skills: types.optional(type.array(Skill))
        , selectedSkill: types.reference(Skill)
    })
    .actions()
    .views()

export default Skills;