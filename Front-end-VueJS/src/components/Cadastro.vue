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
            <input type="text" class="form-control" maxlength="35" placeholder="Nome do técnico" v-model="tech.name" />
          </div>

          <div class="col-12 md-6" id="DadosForm">
            <input
              type="text"
              class="form-control"
              id="inputCpf"
              maxlength="14"
              placeholder="CPF do técnico (000.000.000-00"
              v-model="tech.cpf"
            />
          </div>

          <div class="col-12" id="DadosForm">
            <input
              type="email"
              class="form-control"
              id="inputEmail"
              maxlength="35"
              placeholder="E-mail do técnico"
              v-model="tech.email"
            />
          </div>

          <div class="col-12 md-6" id="DadosForm">
            <input
              type="date"
              class="form-control"
              id="inputData"
              maxlength="8"
              placeholder="Data de nascimentodo técnico"
              v-model="tech.birthdate"
            />
          </div>

          <div class="col-4 md-6" id="DadosForm">
            <input type="text" class="form-control" id="inputCid" placeholder="Cidade" v-model="tech.city" />
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

          <div class="col-4 md-2" id="DadosForm">
            <input type="text" class="form-control" id="inputCep" placeholder="CEP" v-model="tech.cep" />
          </div>

          <div class="col-5" id="DadosForm">
            <select
              name="Espec"
              class="form-control"
              size="10"
              multiple="multiple"
              style="overflow:hidden"
              id="Stacks"
              v-model="tech.stack"
            >
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
            <button v-if="!isEdit"  class="btn btn-primary input-group-btn" @click.prevent="save()">
              Salvar
            </button>
            <button v-if="isEdit" class="btn btn-primary input-group-btn" @click.prevent="modify(technical)">
              Atualizar
            </button>
          </div>
        </form>
      </div>
    </div>
    <table class="table col-10 offset-md-2">
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
            <button type="button" value="" @click.prevent="remove(technical)">Deletar</button>
            &emsp;
            <button type="button" @click.prevent="modify(technical)">Atualizar</button>
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
        id:0,
        name: '',
        cpf: '',
        email: '',
        birthdate: new Date(''),
        city: '',
        state: '',
        cep: '',
        changedate: new Date(),
        createdate: new Date(),
        stacks: [
          {
            id:0,
            stacks: '',
          },
        ],
      },
    }
  },

  computed: {
    repostaCount() {
      return `Total de Técnicos Cadastrados é ${this.technicals.length}`
    },
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
    save() {
      Technical.save(this.tech).then(resposta => {
        console.log(resposta)
        alert('Salvo com sucesso!')
      location.reload()
      })
    },

    remove(technical) {
      Technical.del(technical.id, technical).then(resposta => {
        console.log(resposta)        
        alert('Deletado com sucesso!')
        location.reload()
      })

    },

    modify(technical) {     
      this.tech.id = technical.id 
      this.stacks.id = technical.stacks.id
      console.log(this.tech)
      Technical.update(this.tech.id, this.tech).then(resposta => {
        //console.log(resposta)
        technical = resposta
        alert('Atualizado com sucesso!')
        location.reload()
      })
  
    },
    editUsers(technicals) {
      this.technicals = technicals
      this.isEdit = true
      //location.reload()
    },
  },
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

h1,
.h1 {
  font-size: 2.5rem;
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
