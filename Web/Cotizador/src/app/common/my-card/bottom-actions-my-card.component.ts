import { Component, OnInit, Input, Inject } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material';

export interface MyBottomSheetButton {
  icon?: string;
  text: string;
  description: string;
  actionResult: string;
}

@Component({
  selector: 'app-bottom-actions-my-card',
  templateUrl: './bottom-actions-my-card.component.html',
  styles: [],
})
export class BottomActionsMyCardComponent implements OnInit {
  hasAddButton: boolean = false;
  hasPrintButton: boolean = false;
  extraButtons: MyBottomSheetButton[];

  constructor(
    private bottomSheetRef: MatBottomSheetRef<BottomActionsMyCardComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: any
  ) {
    const defaults = {
      hasAddButton: false,
      hasPrintButton: false,
      extraButtons: new Array< MyBottomSheetButton>()
    };
    const options = Object.assign(defaults, data);

    this.hasAddButton = options.hasAddButton;
    this.hasPrintButton = options.hasPrintButton;
    this.extraButtons = options.extraButtons;
  }

  close(action: string) {
    this.bottomSheetRef.dismiss(action);
  }

  ngOnInit() {}
}
