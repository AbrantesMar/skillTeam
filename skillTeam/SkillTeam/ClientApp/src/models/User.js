import { types } from "mobx-state-tree";

const User = types
    .model("User", {
        Id: types.integer
        , Description: types.string
        , Name: types.string
        , Password: types.string
        , Email: types.string
    })


export default User;