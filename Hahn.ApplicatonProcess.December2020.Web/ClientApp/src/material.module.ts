/**
 * @license
 * Copyright Google LLC All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */

import {NgModule} from '@angular/core';
// import {
//   MatDatepickerModule,
//   MatButtonModule,
//   MatCardModule,
//   MatCheckboxModule,
//   MatDialogModule,
//   MatRadioModule,
//   //MatFormFieldModule,
//   MatGridListModule,
//   MatToolbarModule,
//   MatIconModule,
//   MatInputModule,
//   MatListModule,
//   MatPaginatorModule,
//   MatTooltipModule,
//   MatMenuModule,
//   MatSelectModule,
//   MatSidenavModule,
//   MatSortModule,
//   MatSliderModule,
//   MatSlideToggleModule,
//   MatTableModule,
// } from '@angular/material';
// import {MatNativeDateModule, MatRippleModule} from '@angular/material';
import {CdkTableModule} from '@angular/cdk/table';
import {CdkAccordionModule} from '@angular/cdk/accordion';
import {A11yModule} from '@angular/cdk/a11y';
import {BidiModule} from '@angular/cdk/bidi';
import {OverlayModule} from '@angular/cdk/overlay';
import {PlatformModule} from '@angular/cdk/platform';
import {ObserversModule} from '@angular/cdk/observers';
import {PortalModule} from '@angular/cdk/portal';

/**
 * NgModule that includes all Material modules that are required to serve the demo-app.
 */
@NgModule({
  exports: [
    // MatDatepickerModule,
    // MatNativeDateModule,
    // MatRippleModule,
    // MatButtonModule,
    // MatCardModule,
    // MatCheckboxModule,
    // MatTableModule,
    // MatDialogModule,
    // //MatFormFieldModule,
    // MatSortModule,
    // MatGridListModule,
    // MatIconModule,
    // MatInputModule,
    // MatListModule,
    // MatTooltipModule,
    // MatRadioModule,
    // MatToolbarModule,
    // MatPaginatorModule,
    // MatSelectModule,
    // MatSidenavModule,
    // MatSlideToggleModule,
    // MatSliderModule,
    CdkTableModule,
    A11yModule,
    BidiModule,
    CdkAccordionModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    PortalModule,
    //MatMenuModule
  ]
})
export class MaterialModule {}
