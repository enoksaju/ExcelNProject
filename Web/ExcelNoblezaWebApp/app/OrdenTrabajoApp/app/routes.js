"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var app_1 = require("./components/app");
exports.routes = [
    { path: '', redirectTo: '/index', pathMatch: 'full' },
    { path: 'index', component: app_1.IndexComponent },
    { path: 'search', component: app_1.SearchComponent },
    { path: 'progress', component: app_1.ProgressComponent }
];
//# sourceMappingURL=routes.js.map