import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/pages/HomePage.vue';
import EmployeeList from '@/pages/EmployeeLPage.vue';
import WeatherPage from '@/pages/WeatherPage.vue';
import EmployeeFilter from '@/shared/components/Employee/EmployeeFilter.vue';

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
    {
      path: '/clima',
      name: 'clima',
      component: WeatherPage,
    },
    {
      path: '/filtro',
      name: 'filtro',
      component: EmployeeFilter,
    },
  ],
});

export default router;
