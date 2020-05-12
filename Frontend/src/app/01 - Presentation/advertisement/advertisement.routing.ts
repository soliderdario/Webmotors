import { Routes, RouterModule } from '@angular/router';
import { AdvertisementComponent } from './advertisement.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'list'
    },
    {
      path: 'list',
      component: AdvertisementComponent
    },
  ];

export const AdvertisementRoutes = RouterModule.forChild(routes);
