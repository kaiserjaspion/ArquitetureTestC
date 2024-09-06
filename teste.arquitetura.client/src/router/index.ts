import { createRouter, createWebHistory } from 'vue-router';

const HomePage = () => import('../components/Home.vue')
const Relatorio = () => import('../components/Relatorio.vue')

const routes : any[] = [
   
   {
      name: '/HomePage',
      alias: '/',
      component: HomePage
   },
   {
      name: '/Relatorio',
      alias: '/Relatorio',
      component: Relatorio
   }
]

const router = createRouter({ history: createWebHistory(), routes })

export default router