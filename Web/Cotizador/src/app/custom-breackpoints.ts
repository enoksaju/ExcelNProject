import { BREAKPOINT } from '@angular/flex-layout';

const PRINT_BREAKPOINTS = [
  {
    alias: 'print',
    suffix: 'Print',
    mediaQuery: 'print',
    overlapping: false,
  },
];

export const CustomBreakPointsProvider = {
  provide: BREAKPOINT,
  useValue: PRINT_BREAKPOINTS,
  multi: true,
};
