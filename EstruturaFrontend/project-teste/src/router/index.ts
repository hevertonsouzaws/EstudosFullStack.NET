import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/pages/HomePage.vue';
import Estudy from '@/pages/Estudy.vue';

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
  ],
});

export default router;
