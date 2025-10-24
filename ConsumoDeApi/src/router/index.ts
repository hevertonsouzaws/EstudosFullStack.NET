import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/pages/HomePage.vue';
import EmployeeList from '@/pages/EmployeeList.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/employees',
      name: 'employees',
      component: EmployeeList,
    },
  ],
});

export default router;
