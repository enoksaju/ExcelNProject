import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http } from '@angular/http';

export class Menu {
  NombreGrupo: string;
  Icon: string;
  Items: Item[];
  constructor(Items: Item[], NombreGrupo: string = null, Icon: string = null) {
    this.Icon = Icon;
    this.Items = Items;
    this.NombreGrupo = NombreGrupo;
  }
}

export class SubMenu {
  Items: Item[];
  constructor(items: Item[]) {
    this.Items = items;
  }
}


export class Item {
  Label: string;
  Description: string;
  Icon: string;
  routerLink: string;
  SubMenu: SubMenu;
  /**
  * /@example
  new Item("SubMenu", "Prueba de submenu", "face", null,
      new SubMenu(
        [
          new Item("About", "Acerca de esta pagina", "help", "/about")
        ]
      )
    )
  */
  constructor(label: string, description: string, icon: string, routerLink: string = null, submenu: SubMenu = null) {
    this.Label = label;
    this.Description = description;
    this.Icon = icon ? icon.toLowerCase() : null;
    this.routerLink = routerLink;
    this.SubMenu = submenu;
  }
}

@Component({
  selector: 'menu-item',
  templateUrl: './menuitem.component.html',
  styles: [`
.content {
    display: flex;
    flex-direction: row;
    align-items: center;
    box-sizing: border-box;
    padding: 0;
    position: relative;
    width:100%;
}
.icon {
    width: 24px;
    height: 24px;
    font-size: 24px;
    box-sizing: content-box;
    border-radius: 50%;
    padding: 4px;
}
.text {
    display: flex;
    flex-direction: column;
    width: 100%;
    box-sizing: border-box;
    overflow: hidden;
    padding: 0 16px!important;
    margin: 0;
}
.line{
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    display: block;
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}
.head{
   font-weight:bold!important;
   font-size:20px!important;
}
.tx{
    font-weight:300!important;
    font-size:15px!important;
    font-family: Roboto, "Helvetica Neue", sans-serif!important;
}
.full-with{
    width:100%;
}
.lg-icon{
    font-size:35px!important;
    width:35px!important;
    height:35px!important;
}
`]
})
export class MenuItemsComponent implements OnInit {
  @Input() Menu: Menu
  @Input() ActiveClass: string;

  Open(): void {
    console.info("Click");
  }
  print(f: any): void {
    console.log(f);
  }
  constructor() { }
  ngOnInit(): void {
  }
}