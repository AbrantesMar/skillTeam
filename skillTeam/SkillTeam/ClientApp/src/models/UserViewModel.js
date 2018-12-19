import { types } from "mobx-state-tree";

const UserViewModel = types
    .model("Users", {
        Users: types.optional(types.array(User))
        , selectedUser: types.reference(User)
        , endPoint: "http://localhost:3000/"
    })
    .actions()
    .views()

export default UserViewModel;