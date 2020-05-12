import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { BaseService } from './base-service';
import { AdvertisementModel } from '../02 - Domain/model';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService extends BaseService {

  constructor(
    injector: Injector
  ) {

    super(injector);
  }

  get(): Observable<AdvertisementModel[]> {
    return this
      .httpClient
      .get<AdvertisementModel[]>(this.getApiUrl() + 'advertisement/list', this.getHeaderJson());
  }

  save(advertisement: AdvertisementModel): Observable<AdvertisementModel> {
    console.log(JSON.stringify(advertisement));
    return this.httpClient.post(this.getApiUrl() + 'advertisement/save', JSON.stringify(advertisement), this.getHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete(this.getApiUrl() + `advertisement/delete/${id}`, this.getHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));
  }
}
