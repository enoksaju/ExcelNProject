import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http } from '@angular/http';
import { HttpHeaders } from '@angular/common/http';
import { Menu, SubMenu, Item } from './menuitem.component'
import { UserService } from '../Services/user.service'

@Component({
  selector: 'main-app',
  templateUrl: './main.component.html',
  styles: [`
.sideNavApp{width:250px;} 
.toolbar-app{position:fixed;top:0px;left:0px;right:0px;z-index:15;}
.snav-content{padding:10px!important; }
.snav-container{margin-top:64px; width:100%;min-height: Calc(100vh - 65px)}
a.active {color: #039be5;background-color:rgba(0,0,0,0.3)}`]
})
export class MainComponent implements OnInit {
  
  @Input() loginPath: string;
  @Input() logoffPath: string;
  @Input() Menus: Menu[] = null;
  @Input() Token: string;
  @Input() ImageUrl: string;
  @Input() Card: boolean;

  isloged: boolean;

  LogClick(): void {
    if (this.isloged) {
      let frm: any = document.getElementById('logoutForm');
      frm.submit();
    } else {
      this.loginPath && window.location.replace(this.loginPath);
    }
  };

  private withPaths(): boolean {
    var t = this.loginPath || this.logoffPath ? true : false;
    return t;
  }

  constructor(
    public media: ObservableMedia,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.isLoged().then(r => this.isloged = r);
  }
}
