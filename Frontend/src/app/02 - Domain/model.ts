import { OperationType } from './types';

class AdvertisementModel {
  constructor(
    public Id: number = null,
    public Marca: string = null,
    public Modelo: string = null,
    public Versao: string = null,
    public Ano: number = null,
    public Quilometragem: number = null,
    public Observacao: string = null,
    public Operation: OperationType = OperationType.Insert
  ) {}
}

class MakeModel {
  constructor(
    public Id: number = null,
    public Name: string = null
  ) {}
}

class ModelModel {
  constructor(
    public Id: number = null,
    public MakeId: number = null,
    public Name: string = null
  ) {}
}

class VersionModel {
  constructor(
    public Id: number = null,
    public ModelId: number = null,
    public Name: string = null
  ) {}
}

class VehiclesModel {
  constructor(
    public Id: number = null,
    public Make: string = null,
    public Model: string = null,
    public Version: string = null,
    public Image: string = null,
    public Km: number = null,
    public Price: number = null,
    public YearModel: number = null,
    public YearFab: number = null,
    public Color: string =  null
  ) {}
}



export {
  AdvertisementModel,
  MakeModel,
  ModelModel,
  VersionModel,
  VehiclesModel
};
