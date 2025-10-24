import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/pages/HomePage.vue';
import Estudy from '@/pages/Estudy.vue';
import StatusWS from '@/pages/StatusWS.vue';
import LoadingPage from '@/pages/LoadingPage.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/estudy',
      name: 'estudy',
      component: Estudy,
    },
    {
      path: '/statusws',
      name: 'statusws',
      component: StatusWS,
    },
    {
      path: '/loader',
      name: 'loader',
      component: LoadingPage,
    },
  ],
});

export default router;
