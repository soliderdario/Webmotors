import { Component, OnInit, Input, Output, EventEmitter, Injector } from '@angular/core';
import { BaseComponent } from '../../base-component';
import { AdvertisementModel, MakeModel, ModelModel, VersionModel, VehiclesModel } from 'src/app/02 - Domain/model';
import { FormBuilder, Validators } from '@angular/forms';
import { AdvertisementService } from 'src/app/03 - Service/advertisement.service';
import { MsModalService } from 'src/app/04 - Infrastrucuture/modal/ms-modal.service';

@Component({
  selector: 'app-create-update',
  templateUrl: './create-update.component.html',
  styleUrls: ['./create-update.component.css']
})
export class CreateUpdateComponent extends BaseComponent implements OnInit {

  @Input() id: string;
  @Input() advertisement: AdvertisementModel;
  @Output() responseAdvertisement: EventEmitter<AdvertisementModel> = new EventEmitter();

  makes =  new Array<MakeModel>();
  models =  new Array<ModelModel>();
  versions =  new Array<VersionModel>();
  vehicles =  new Array<VehiclesModel>();

  constructor(
    injector: Injector,
    private fb: FormBuilder,
    private advertisementService: AdvertisementService,
    private modalService: MsModalService
  ) {
    super(injector);
  }

  private initialize(advertisement: AdvertisementModel) {
    this.formulario = this.fb.group({
      Id: advertisement.Id,
      Marca: [advertisement.Marca, Validators.required],
      Modelo: [advertisement.Modelo, Validators.required],
      Versao: [advertisement.Versao, Validators.required],
      Ano: [advertisement.Ano, Validators.required],
      Quilometragem: [advertisement.Quilometragem, Validators.required],
      Observacao: [advertisement.Observacao, Validators.required],
      Operation: [advertisement.Operation]
    });

    this.commonService.getMake().subscribe(response => {
      this.makes = response;
      console.log(this.makes);
    });
  }

  ngOnInit() {
    super.ngOnInit();
    this.initialize(this.advertisement);
  }

  getModel(makeId: number) {
    this.commonService.getModel(makeId).subscribe(response => this.models = response);
  }

  getVersion(modelId: number) {
    this.commonService.getVersion(modelId).subscribe(response => this.versions = response);
  }

  getVehicle(page: number) {
    this.commonService.getVehicle(page).subscribe(response => this.vehicles = response);
  }

  save() {

    this.errors = new Array<any>();
    if (!this.formulario.valid) {
      this.errors.push('Verifique se os campos obrigatórios foram preenchidos!');
      return;
    }

    const advertisement: AdvertisementModel = Object.assign({}, new AdvertisementModel(), this.formulario.value);
    this.advertisementService.save(advertisement).subscribe(
      (response) => {

        this.responseAdvertisement.next(response);
        this.responseAdvertisement.complete();
        this.modalService.close(this.id);

      },
      (fail) => {
        this.errors = fail.error.errors;
      });
  }
  onClose() {
    this.formulario.reset();
    this.responseAdvertisement.next(null);
    this.modalService.close(this.id);
  }

}

