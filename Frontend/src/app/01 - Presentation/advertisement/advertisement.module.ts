import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertisementComponent } from './advertisement.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { NgxMaskModule, IConfig } from 'ngx-mask';
import { NgxPaginationModule } from 'ngx-pagination';

import { MsModalModule } from 'src/app/04 - Infrastrucuture/modal/ms-modal.module';

import { AdvertisementRoutes } from './advertisement.routing';
import { CreateUpdateComponent } from './create-update/create-update.component';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

@NgModule({
  imports: [
    CommonModule,
    AdvertisementRoutes,
    ReactiveFormsModule,
    FormsModule,
    NgxMaskModule.forRoot(options),
    NgxPaginationModule,
    MsModalModule
  ],
  declarations: [
    AdvertisementComponent,
    CreateUpdateComponent
  ]
})
export class AdvertisementModule { }
