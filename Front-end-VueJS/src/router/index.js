import Vue from 'vue'
import Router from 'vue-router'

import Cadastro from '@/components/Cadastro.vue'
import Tecnicos from '@/components/Tecnicos.vue'

Vue.use(Router)

const routes = [
    
    {
        name: 'cadastro',
        path: '/',
        component: Cadastro
    },    

    {
        name: 'tecnicos',
        path: '/Tecnicos',
        component: Tecnicos
    }
]

const router = new Router({ routes, mode: 'history' })

export default router
