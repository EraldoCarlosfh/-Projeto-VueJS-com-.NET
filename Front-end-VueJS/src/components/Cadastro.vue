<template>
  <div class="container-fluid">
    <div class="col-10 offset-md-2">
      <div class="col-12 container" id="Form">
        <div
          class="d-flex flex-wrap flex-md-nowrap align-items-center justify-content-between pt-3 pb-2 mb-3 border-bottom"
        >
          <h1 :title="ex">{{ name }}</h1>
          <p>{{ repostaCount }}</p>
        </div>

        <form class="row" @submit.prevent="save">          
          <div class="col-12 md-6 input-group">
            <input type="text" class="form-control" placeholder="Nome do técnico" v-model="tech.name"/>
          </div>

          <div class="col-12 md-6" id="DadosForm">
            <input type="text" class="form-control" id="inputCpf" placeholder="CPF do técnico" v-model="tech.cpf"/>
          </div>

          <div class="col-12" id="DadosForm">
            <input type="email" class="form-control" id="inputEmail" placeholder="E-mail do técnico" v-model="tech.email"/>
          </div>

          <div class="col-12 md-6" id="DadosForm">
            <input type="date" class="form-control" id="inputData" placeholder="Data de nascimentodo técnico" v-model="tech.createDate"/>
          </div>

          <div class="col-4 md-6" id="DadosForm">
            <input type="text" class="form-control" id="inputCid" placeholder="Cidade" v-model="tech.city"/>
          </div>

          <div class="col-4 md-6" id="DadosForm">
            <select id="inputEst" class="form-control" v-model="tech.state">
              <option selected>Estado...</option>
              <optgroup label="Região Norte">
                <option value="AP">Amapá</option>
                <option value="AM">Amazonas</option>
                <option value="PA">Pará</option>
                <option value="RO">Rondônia</option>
                <option value="RR">Roraima</option>
                <option value="TO">Tocantins</option>
                <option value="AC">Acre</option>
              </optgroup>

              <optgroup label="Região Nordeste">
                <option value="BA">Bahia</option>
                <option value="CE">Ceará</option>
                <option value="AL">Alagoas</option>
                <option value="MA">Maranhão</option>
                <option value="PB">Paraíba</option>
                <option value="PE">Pernambuco</option>
                <option value="PI">Piauí</option>
                <option value="RN">Rio Grande do Norte</option>
                <option value="SE">Sergipe</option>
              </optgroup>

              <optgroup label="Região Sul">
                <option value="PR">Paraná</option>
                <option value="RS">Rio Grande do Sul</option>
                <option value="SC">Santa Catarina</option>
              </optgroup>

              <optgroup label="Região Sudeste">
                <option value="ES">Espírito Santo</option>
                <option value="MG">Minas Gerais</option>
                <option value="RJ">Rio de Janeiro</option>
                <option value="SP">São Paulo</option>
              </optgroup>

              <optgroup label="Região Centro-Oeste">
                <option value="MT">Mato Grosso</option>
                <option value="MS">Mato Grosso do Sul</option>
                <option value="GO">Goiás</option>
                <option value="DF">Distrito Federal</option>
              </optgroup>
            </select>
          </div>

          <div class="col-4 md-2" id="DadosForm" >
            <input type="text" class="form-control" id="inputCep" placeholder="CEP" v-model="tech.cep"/>
          </div>

          <div class="col-5" id="DadosForm">
            <select name="Espec" class="form-control" size="10" multiple="multiple" style="overflow:hidden" id="Stacks" v-model="tech.stack">
              <option value="HTML" label="HTML"></option>
              <option value="CSS" label="CSS"></option>
              <option value="PostegreSQL" label="PostegreSQL"></option>
              <option value="JavaScript" label="JavaScript"></option>
              <option value="PHP" label="PHP"></option>
              <option value="React" label="React"></option>
              <option value="React Native" label="React Native"></option>
              <option value="NodeJS" label="NodeJS"></option>
              <option value="VueJS" label="VueJS"></option>
              <option value="MySQL" label="MySQL"></option>
            </select>
          </div>
          <div class="col-12">
            <button v-if="!isEdit" class="btn btn-primary input-group-btn" @click.prevent="save(tech)">
              Salvar
            </button>
            <button v-if="isEdit" class="btn btn-primary input-group-btn" @click.prevent="update(tech)">
              Atualizar
            </button>
          </div>
        </form>
      </div>
    </div>
    <table class="table col-10 offset-md-2" >
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
          <th scope="row">{{technical.id}}</th>
          <td>{{technical.name}}</td>
          <td>{{technical.cpf}}</td>
          <td>{{technical.email}}</td>
          <td>{{technical.createDate}}</td>        
          <td>            
            <a href="#" class="icon1" @click.prevent="del(6)"><svg xmlns="http://www.w3.org/2000/svg" width="19" height="19" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
  <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
</svg></a>
            &emsp;
            <a href="#" class="icon2" @click.prevent="update(technical)"><svg xmlns="http://www.w3.org/2000/svg" width="19" height="19" fill="currentColor" class="bi bi-pencil-fill" viewBox="0 0 16 16">
  <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z"/>
</svg></a>
                                   
          </td>
        </tr>
      </tbody>      
    </table>
  </div>
</template>

<script>
import Technical from '../services/technicals'


export default {
  name: 'Cadastro',

  data() {
    return {
      technicals: [],
      name: 'Formulário de Técnico',
      ex: 'Cadastro de Técnicos',
      isEdit: false,
      tech: {
        id:"",
        name: "",
        cpf: "",
        email: "",
        birthdate: "",
        state: "",
        city: "",
        cep: "",
        changeDate:"",
        createDate:"",
        stacks:[
          {
            id:"",
            stacks:""
            }
            ]
      }
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
    
    save(){            
      Technical.save(this.technicals).then(resposta => {
        console.log(this.technicals)
        this.tech = {}
        this.technicals = resposta.data     
        alert('Salvo com sucesso!')
        this.list()
      })
    },
      
      del(id){
        Technical.del(id).then(resposta => {
          console.log(resposta)
           alert('Deletado com sucesso!')
        })
      },

      update(technicals) {
        this.tech = technicals
      }
    }
    //location.reload() 
}    

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.table thead th {
  vertical-align: center;
  border-bottom: 2px solid #dee2e6;
  padding-right: 2vh;
  align-items: center;
}
.table {
  width: 100%;
  margin-bottom: 2rem;
  color: #111213;
  background-color: #f3f3f3;
  margin-right: 20vh;
}

.table {
  margin-bottom: 10vh;
}
#msg {
  margin-bottom: 10vh;
}

/* Add "scoped" attribute to limit CSS to this component only -->*/

.h2 {
  font-size: 17pt;
  font-family: Arial, Helvetica, sans-serif;
  color: #244873 !important;
  font-weight: bold;
}

#Form {
  justify-items: center;
  background-color: #f3f3f3;
  padding: 5vh;
  padding-top: 0.5px;
  margin-bottom: 5vh;
  margin-top: 5vh;
  float: right;
}
#DadosForm {
  margin-top: 2vh;
}

.btn-primary {
  background-color: #6aa839;
  font-family: Arial, Helvetica, sans-serif;
  border: #6aa839;
  height: 30px;
  position: relative;
  line-height: 20px;
  padding-left: 5vh;
  padding-right: 5vh;
  float: right;
}

.btn-primary:hover {
  background-color: #6aa839;
}
.bd-placeholder-img {
  font-size: 1.125rem;
  text-anchor: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  user-select: none;
}

@media (min-width: 768px) {
  .bd-placeholder-img-lg {
    font-size: 3.5rem;
  }
}
body {
  font-size: 0.875rem;
}
.user-list {
  padding-top: 2rem;
}
</style>
