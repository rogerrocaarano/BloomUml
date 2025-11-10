import { Routes } from "@angular/router";
import { HelloWorld } from "./hello-world/hello-world";

export const routes: Routes = [
    // default route redirection
    {
        path: "",
        redirectTo: "hello-world",
        pathMatch: "full",
    },
    {
        path: "hello-world",
        component: HelloWorld,
    },
];
