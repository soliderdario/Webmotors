import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../base-component';

import { AdvertisementModel } from 'src/app/02 - Domain/model';
import { OperationType } from 'src/app/02 - Domain/types';

import { AdvertisementService } from 'src/app/03 - Service/advertisement.service';

import { MsModalService } from 'src/app/04 - Infrastrucuture/modal/ms-modal.service';

@Component({
  selector: 'app-advertisement',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.css']
})
export class AdvertisementComponent extends BaseComponent implements OnInit {

  advertisements = new Array<AdvertisementModel>();
  advertisement: AdvertisementModel;
  page = 1;

  constructor(
    injector: Injector,
    private advertisementService: AdvertisementService,
    private modalService: MsModalService
  ) {
    super(injector);
  }

  ngOnInit() {
    super.ngOnInit();
    this.advertisementService.get().subscribe(resp => {
      this.advertisements = resp;
    });
  }

  new(id: string) {
    this.advertisement = new AdvertisementModel();
    this.advertisement.Operation = OperationType.Insert;
    this.modalService.open(id);
  }

  edit(advertisement: AdvertisementModel, id: string) {
    this.advertisement = Object.assign({}, new AdvertisementModel(), advertisement);
    this.advertisement.Operation = OperationType.Update;
    this.modalService.open(id);

  }

  delete(Id: number) {
    this.advertisementService.delete(Id).subscribe(() => {
      const index = this.advertisements.findIndex(src => src.Id === Id);
      this.advertisements.splice(index, 1);
    });
  }

  onResponseAdvertisement(advertisement: AdvertisementModel) {
    if (advertisement === null) {
      this.advertisement = null;
      return;
    }
    const index = this.advertisements.findIndex(src => src.Id === advertisement.Id);
    if (index === -1) {
      this.advertisements.push(advertisement);
    } else {
      this.advertisements[index] = advertisement;
    }
    this.advertisement = null;

  }
}

