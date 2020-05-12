import { Component, OnInit, Injector } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { ApplicationService } from 'src/app/03 - Service/application.service';
import { CommonService } from 'src/app/03 - Service/common.service';

@Component({
  template: ''
})
export class BaseComponent implements OnInit {

  formulario: FormGroup;
  router: Router;
  route: ActivatedRoute;
  errors: any[] = [];

  nameMask = '';
  maskType = '';
  placeholderMask = '';



  applicationService: ApplicationService;
  commonService: CommonService;

  constructor(
    private injector: Injector,
  ) {
    this.router = this.injector.get<Router>(Router);
    this.route = this.injector.get<ActivatedRoute>(ActivatedRoute);
    // this.authenticationService = this.injector.get<AuthenticationService>(AuthenticationService);
    this.applicationService = this.injector.get<ApplicationService>(ApplicationService);
    this.commonService = this.injector.get<CommonService>(CommonService);
   }

  ngOnInit() {
  }

  cepValidator(control: FormControl) {
    const cep = control.value;
    if (cep && cep !== '') {
      const validacep = /^[0-9]{8}$/;
      return validacep.test(cep) ? null : { cepInvalido : true };
    }
    return null;
  }

  verificaValidTouched(campo: string) {
    return (
      !this.formulario.get(campo).valid &&
      (this.formulario.get(campo).touched || this.formulario.get(campo).dirty)
    );
  }

  verificaRequired(campo: string) {
    return (
      this.formulario.get(campo).hasError('required') &&
      (this.formulario.get(campo).touched || this.formulario.get(campo).dirty)
    );
  }

  aplicaCssErro(campo: string) {
    return {
      'has-error': this.verificaValidTouched(campo),
      'has-feedback': this.verificaValidTouched(campo)
    };
  }

  split(text: string, character: string) {
    const work = text.split(character);
    const result = new Array<string>();
    work.forEach(element => {
      if (element.trim().length > 0) {
        result.push(element);
      }
    });
    return result;
  }

  // isAllowed(type: string, value: string) {
  //   const claims: ClaimAuthenticationModel[] = this.authenticationService.getClaim();
  //   if (claims === null ){
  //     return false;
  //   }

  //   const claim = claims.filter(src => src.Type.toUpperCase() === type.toUpperCase());
  //   if (claim.length === 0) {
  //     return false;
  //   }

  //   return this.split(claim[0].Value, ',').filter(val => val.toUpperCase() === value.toUpperCase()).length === 0 ? false : true;
  // }

}
