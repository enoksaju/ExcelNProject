import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export enum DialogIcons {
  None,
  Success,
  Error,
  Info,
  Question
}

export enum DialogButtonsFlags {
  none = 0,
  Ok = 1 << 0,
  Cancel = 1 << 1,
  Yes = 1 << 2,
  No = 1 << 3
}

export interface DialogData {
  Message: string;
  Title: string;
  Icon: DialogIcons;
  buttons: DialogButtonsFlags;
  hasCloseButton: boolean;
}

export enum DialogResults {
  Ok,
  Cancel,
  Yes,
  No
}


@Component({
  selector: 'app-dialog',
  template: `
<div style="position: relative" fxLayout="column" fxLayoutGap="15px" class="mat-typography" cdkDrag
   cdkDragRootElement=".cdk-overlay-pane"
   cdkDragHandle>
  <!-- CloseButton -->
  <button class="closeButton" *ngIf="hasClose"  tabIndex="3" color="warn" mat-icon-button (click)="CancelResult()">
    <mat-icon>close</mat-icon>
  </button>

  <div fxLayout="row" style="margin-bottom:3px" fxLayoutAlign="center center">
    <!-- DialogIcon -->
    <div fxLayout="column" fxLayoutAlign="center center">
      <mat-icon [style.color]="ColorIcon" class="mat-icon-dialog" [svgIcon]="DialogIcon"></mat-icon>
    </div>
    <h2 fxFlex="100" style="text-align:center; margin:0px" mat-dialog-title>{{data.Title}}</h2>
  </div>

  <mat-divider></mat-divider>

  <!-- DialogContent -->
  <div fxFlex="100">
    <div mat-dialog-content [innerHTML]="data.Message"></div>
    <div mat-dialog-actions fxLayout="row" fxLayoutAlign="space-between center">
      <button *ngIf="HasFlag(data.buttons, DialogButtons.No)" tabIndex="0" (click)="NoResult()" color="warn" mat-stroked-button>No</button>
      <button *ngIf="HasFlag(data.buttons, DialogButtons.Yes)"  tabIndex="1" (click)="YesResult()" color="primary" mat-stroked-button>Si</button>
      <button *ngIf="HasFlag(data.buttons, DialogButtons.Cancel)"  tabIndex="0" (click)="CancelResult()" color="warn" mat-stroked-button>Cancelar</button>
      <button *ngIf="HasFlag(data.buttons, DialogButtons.Ok)"  tabIndex="1" (click)="OkResult()" color="primary" mat-stroked-button>Ok</button>
    </div>
  </div>
</div>
  `
})
export class DialogComponent implements OnInit {
  DialogButtons = DialogButtonsFlags;

  constructor(public dialogRef: MatDialogRef<DialogComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData) {
    this.data.buttons = data.buttons === null || data.buttons === 0 ? DialogButtonsFlags.Ok : data.buttons;
  }

  ngOnInit(): void {
  }

  HasFlag(value: DialogButtonsFlags, compare: DialogButtonsFlags) {
    if (value & compare) {
      return true;
    } else {
      return false;
    }
  }

  get hasClose() {
    return this.data.hasCloseButton;
  }

  get DialogIcon() {
    switch (this.data.Icon) {
      case DialogIcons.Error:
        return 'alert-circle-outline';
      case DialogIcons.Info:
        return 'information-outline';
      case DialogIcons.Question:
        return 'help-circle-outline';
      case DialogIcons.Success:
        return 'check-circle-outline';
      default:
        return 'information-outline';
    }
  }

  get ColorIcon() {
    switch (this.data.Icon) {
      case DialogIcons.Error:
        return '#f44336';
      case DialogIcons.Info:
        return '#03a9f4';
      case DialogIcons.Question:
        return '#304ffe';
      case DialogIcons.Success:
        return '#4caf50';
      default:
        return '#03a9f4';
    }
  }

  OkResult() {
    this.dialogRef.close(DialogResults.Ok);
  }
  CancelResult() {
    this.dialogRef.close(DialogResults.Cancel);
  }
  YesResult() {
    this.dialogRef.close(DialogResults.Yes);
  }
  NoResult() {
    this.dialogRef.close(DialogResults.No);
  }

}
