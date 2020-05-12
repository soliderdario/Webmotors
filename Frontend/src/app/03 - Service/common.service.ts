import { Injectable, Injector } from '@angular/core';
import { of, Observable } from 'rxjs';


import { BaseService } from './base-service';
import { MakeModel, VersionModel, VehiclesModel, ModelModel } from '../02 - Domain/model';

@Injectable({
  providedIn: 'root'
})
export class CommonService extends BaseService {
  private urlBase = 'http://desafioonline.webmotors.com.br/api/onlinechallenge/';

  constructor(
    injector: Injector
  ) {

    super(injector);
  }

  getMake(): Observable<MakeModel[]> {
    return this
      .httpClient
      .get<MakeModel[]>(`http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make`, this.getHeaderJson());
     // .get<MakeModel[]>(`${this.urlBase}make`, this.getHeaderJson());

     // http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=1
  }

  getModel(makeId: number): Observable<ModelModel[]> {
    return this
      .httpClient
      .get<ModelModel[]>(`${this.urlBase}model?MakeID=${makeId}`, this.getHeaderJson());
  }

  getVersion(modelId: number): Observable<VersionModel[]> {
    return this
      .httpClient
      .get<VersionModel[]>( `${this.urlBase}version?ModelID=${modelId}`, this.getHeaderJson());
  }

  getVehicle(page: number): Observable<VehiclesModel[]> {
    return this
      .httpClient
      .get<VehiclesModel[]>(`${this.urlBase}vehicles?Page${page}`, this.getHeaderJson());
  }

}
