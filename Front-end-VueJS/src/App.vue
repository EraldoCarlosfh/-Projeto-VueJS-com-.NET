<template>
  <div id="app">
    <Menu />
    <router-view />
    <SideBarMenu />
  </div>
</template>

<script>
import Menu from './components/Menu'
import SideBarMenu from './components/SideBarMenu'

//import _ from 'lodash';

export default {
  name: 'App',
  components: {
    Menu,
    SideBarMenu,
  },
}
</script>
<style></style>
