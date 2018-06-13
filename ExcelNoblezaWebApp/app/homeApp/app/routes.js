"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var main_component_1 = require("./components/main.component");
var aplicaciones_component_1 = require("./components/aplicaciones.component");
var contacto_component_1 = require("./components/contacto.component");
var products_1 = require("./components/products/products");
exports.routes = [
    { path: '', redirectTo: '/main', pathMatch: 'full' },
    { path: 'main', component: main_component_1.MainComponent },
    { path: 'aplicaciones', component: aplicaciones_component_1.AplicacionesComponent },
    { path: 'contacto', component: contacto_component_1.ContactoComponent },
    {
        path: 'productos',
        component: products_1.ProductsComponent,
        children: [
            {
                path: 'peliculas',
                component: products_1.PeliculasComponent
            },
            {
                path: 'bolsas',
                component: products_1.BolsasComponent
            },
            {
                path: 'polietileno',
                component: products_1.PolietilenoComponent
            },
            {
                path: "etiquetas",
                component: products_1.EtiquetasComponent
            },
            {
                path: "innovaciones",
                component: products_1.InnovacionesComponent
            }
        ]
    },
    { path: '**', redirectTo: '/main', pathMatch: 'full' }
];
//# sourceMappingURL=routes.js.map