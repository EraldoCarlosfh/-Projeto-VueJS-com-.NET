<template> 
<div class="container-fluid">
  <div class="row">
    <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
      <div class="position-sticky pt-3">
        <ul class="nav flex-column">
          <li class="nav-item">
            <router-link to="/tecnicos"><a class="nav-link active" aria-current="page" href="">
              <span data-feather="home"></span>
               <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-list-ul" viewBox="0 0 16 16">
                <path fill-rule="evenodd" d="M5 11.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm-3 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm0 4a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm0 4a1 1 0 1 0 0-2 1 1 0 0 0 0 2z"/>
              </svg>&emsp;Lista de técnicos
            </a></router-link>                        
          </li>

          <li class="nav-item">
            <router-link to="/"><a class="nav-link" href="">
              <span data-feather="file"></span><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-plus-fill" viewBox="0 0 16 16">
                <path d="M1 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H1zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"/>
                <path fill-rule="evenodd" d="M13.5 5a.5.5 0 0 1 .5.5V7h1.5a.5.5 0 0 1 0 1H14v1.5a.5.5 0 0 1-1 0V8h-1.5a.5.5 0 0 1 0-1H13V5.5a.5.5 0 0 1 .5-.5z"/>
              </svg>&emsp;Cadastro de técnicos
            </a></router-link>
          </li>
         </ul>
      </div>
    </nav>
</div>
</div>

</template>

<script>
export default {
  name: 'SideBarMenu',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.bg-light {
    background-color: #2F3C4A !important;    
    padding-bottom: 100%;
    margin-top: 0px;
}
.sidebar {
  position: fixed;
  top: 0;  
  bottom: 0;  
  left: 0;
  z-index: 100; 
  padding: 48px 0 0; 
  box-shadow: inset -1px 0 0 rgba(0, 0, 0, .1);
}

@media (max-width: 767.98px) {
  .sidebar {
    top: 5rem;
  }
}

.sidebar-sticky {
  position: relative;
  top: 0;
  height: calc(100vh - 48px);
  padding-top: .5rem;
  overflow-x: hidden;
  overflow-y: auto;
}

.sidebar .nav-link {
  font-weight: 500;
  font-family: Arial, Helvetica, sans-serif;
  color: rgb(255, 255, 255);
  font-size: 13pt;
}

.sidebar .nav-link .feather {
  margin-right: 4px;
  color: #ffffff;
}

.sidebar .nav-link.active {
  color: #ffffff;
  }

.sidebar .nav-link:hover .feather,
.sidebar .nav-link.active .feather {
  color: inherit;
}

.sidebar-heading {
  font-size: .75rem;
  text-transform: uppercase;
}

.nav-link.active:hover{
    background-color: #F3F3F3;
    color: #244873;
}
.nav-link:hover{
    background-color: #F3F3F3;
    color: #244873;
}
body {
  text-align: justify;
}

</style>




