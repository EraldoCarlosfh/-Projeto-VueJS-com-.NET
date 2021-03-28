import Vue from 'vue';
import App from './App.vue'
import 'jquery';
import 'popper.js';
import 'bootstrap';
import './assets/app.css';
import router from '@/router/index.js';

//import '../node_modules/bootstrap-vue/dist/bootstrap-vue';


Vue.config.productionTip = false

//window.vue = Vue

new Vue({ 
  router, 
  render: h => h(App)
}).$mount('#app');
