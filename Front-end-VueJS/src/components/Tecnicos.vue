<template>
  <div class="col-10 offset-md-2">
    <div class="col-12 container" id="Form">
      <div
        class="col d-flex flex-wrap flex-md-nowrap align-items-center justify-content-between pt-3 pb-2 mb-2"
      >
        <h1 :title="ex">{{name}} </h1> 
        <p>{{repostaCount}}</p>
       </div>
       

      <div class="d-flex flex-wrap flex-md-nowrap pt-6 pb-3 mb-2">
      <div class="col-3">
        <input type="text" class="form-control" id="inputName" placeholder="Nome do técnico" />
      </div>
      <div class="col-3" id="div1">
        <select id="inputSelect" class="form-control" aria-label="Default select example">
          <option selected>Selecione uma stack</option>
          <option value="HTML" label="HTML"></option>
          <option value="CSS" label="CSS"></option>
          <option value="PostegreSQL" label="PostegreSQL"></option>
          <option value="PHP" label="PHP"></option>
          <option value="JavaScript" label="JavaScript"></option>
          <option value="PHP" label="PHP"></option>
          <option value="React" label="React"></option>
          <option value="React Native" label="React Native"></option>
          <option value="NodeJS" label="NodeJS"></option>
          <option value="LaLaravelel" label="HTML"></option>
          <option value="VueJS" label="VueJS"></option>
          <option value="MySQL" label="MySQL"></option>
        </select>
      </div>
    </div> 

      <table class="table col-12 container">
        <thead>
          <tr>
            <th scope="col">Código</th>
            <th scope="col">Nome</th>
            <th scope="col">CPF</th>
            <th scope="col">Email</th>
            <th scope="col">Criado em</th>
            <th scope="col">Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="technical in technicals" :key="technical.id">
          <th scope="row">{{ technical.id }}</th>
          <td>{{ technical.name }}</td>
          <td>{{ technical.cpf }}</td>
          <td>{{ technical.email }}</td>
          <td>{{ technical.createDate }}</td>
          <td>
              <a href="#" class="icon1" @click.prevent="remove(technical)"
                ><svg
                  id="svg1"
                  xmlns="http://www.w3.org/2000/svg"
                  width="19"
                  height="19"
                  fill="currentColor"
                  class="bi bi-trash-fill"
                  viewBox="0 0 16 16"
                >
                  <path
                    d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"
                  /></svg
              ></a>
              &emsp;
              <a href="#" class="icon2" 
                ><router-link to="/" @click.prevent="update(technical)"><svg
                  id="svg2"                  
                  xmlns="http://www.w3.org/2000/svg"
                  width="19"
                  height="19"
                  fill="currentColor"
                  class="bi bi-pencil-fill"
                  viewBox="0 0 16 16"                  
                >
                  <path
                    d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z"
                  /></svg
              ></router-link></a>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
import Technical from '../services/technicals'

export default {  
  name: 'Tecnicos',
  data() {
    return { 
      name: 'Listagem de Técnicos',  
      ex: 'Técnicos Cadastrados',
      technicals: [], 
    } 
    },
 
  computed: {
    repostaCount() {
      return `Total de Técnicos Cadastrados é ${this.technicals.length}`      
    }
  },

  mounted() {     
    this.list()    
  },
  
  methods: {
    list() {
    Technical.list().then(resposta => {    
      this.technicals = resposta.data
     //console.log()      
    })
    }, 
      remove(technical) {
      Technical.del(technical.id, technical).then(resposta => {
        console.log(resposta)        
        alert('Deletado com sucesso!')
        location.reload()
      })
      },

    },    
      
    //location.reload() 
}    
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,.h1 {
  font-size: 2.5rem;
  font-size: 17pt;
  font-family: Arial, Helvetica, sans-serif;
  color: #244873 !important;
  font-weight: bold;
 }

#svg2{

    overflow: hidden;
    vertical-align: middle;
    color: #244873;

}

#svg1 {
  color: #c73232;
}


.table thead th {
  vertical-align: center;
  border-bottom: 2px solid #dee2e6;
  padding-right: 2vh;
  align-items: center;
}

#Form {
  justify-items: center;
  background-color: #f3f3f3;
  padding: 4vh;
  padding-top: 8.5px;
  margin-bottom: 5vh;
  padding-bottom: 0vh;
  float: right;
}

.col-10 {
  flex: 0 0 83.333333%;
  max-width: 83.333333%;
  margin-top: 5vh;
  background-color: #f3f3f3;
}
.container,
.container-fluid,
.container-sm,
.container-md,
.container-lg,
.container-xl {
  width: 100%;
  padding-right: 15px;
  padding-left: 15px;
  margin-right: auto;
  margin-left: auto;
  background-color: #f3f3f3;
  padding-bottom: 10vh;
}
</style>
