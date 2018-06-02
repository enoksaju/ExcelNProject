"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var app_1 = require("./components/app");
exports.routes = [
    { path: '', redirectTo: '/index', pathMatch: 'full' },
    { path: 'index', component: app_1.IndexComponent },
    { path: 'solicitar', component: app_1.SolicitarComponent },
    { path: 'descargar', component: app_1.SearchComponent },
    {
        path: 'administrar', component: app_1.AdministrarComponent,
        children: [
            { path: 'validar', component: app_1.ValidarComponent },
            { path: 'reporte', component: app_1.ReporteComponent },
        ]
    }
];
//# sourceMappingURL=routes.js.map