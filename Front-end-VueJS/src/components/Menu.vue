<template>
  <div>
    <html lang="pt-br">
      <head>
        <meta charset="utf-8" />
        <title>Cadastro</title>
      </head>

      <header class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow" id="topo1">
        <router-link to="/"
          ><a class="navbar-brand col-md-3 col-lg-2 me-0 px-5" href="#" id="topo2">Teste BoxTI</a></router-link
        >
        <button
          class="navbar-toggler position-absolute d-md-none collapsed"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#sidebarMenu"
          aria-controls="sidebarMenu"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
      </header>
    </html>
  </div>
</template>

<script>
export default {
  name: 'Menu',
  props: {
    msg: String,
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#topo1 {
  background-color: #244873 !important;
}

#topo2 {
  font-size: 12pt;
  font-family: Arial, Helvetica, sans-serif;
}
body {
  font-size: 0.875rem;
}

.navbar {
  height: 45px;
}
</style>
