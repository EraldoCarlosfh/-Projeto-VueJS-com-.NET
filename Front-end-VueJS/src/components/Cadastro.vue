<template>
  <div class="container-fluid">
    <div class="col-10 offset-md-2">
      <div class="col-12 container" id="Form">
        <div
          class="d-flex flex-wrap flex-md-nowrap align-items-center justify-content-between pt-3 pb-2 mb-3 border-bottom"
        >
          <h1 :title="ex">{{ name }}</h1>
          <p>{{ usuariosCount }}</p>
        </div>

        <form class="row">
          <div class="col-12 md-6 input-group">
            <input type="text" :v-model="usuario.nome" class="form-control" placeholder="Nome do técnico" />
          </div>

          <div class="col-12 md-6" id="DadosForm">
            <input type="text" v-model="usuario.cpf" class="form-control" id="inputCpf" placeholder="CPF do técnico" />
          </div>

          <div class="col-12" id="DadosForm">
            <input
              type="email"
              v-model="usuario.email"
              class="form-control"
              id="inputEmail"
              placeholder="E-mail do técnico"
            />
          </div>

          <div class="col-12 md-6" id="DadosForm">
            <input
              type="date"
              v-model="usuario.dataNasc"
              class="form-control"
              id="inputData"
              placeholder="Data de nascimentodo técnico"
            />
          </div>

          <div class="col-4 md-6" id="DadosForm">
            <input type="text" v-model="usuario.cid" class="form-control" id="inputCid" placeholder="Cidade" />
          </div>

          <div class="col-4 md-6" id="DadosForm">
            <select id="inputEst" v-model="usuario.est" class="form-control">
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
            <input type="text" v-model="usuario.cep" class="form-control" id="inputCep" placeholder="CEP" />
          </div>

          <div class="col-5" id="DadosForm">
            <select
              name="Espec"
              v-model="usuario.stacks"
              class="form-control"
              size="10"
              multiple="multiple"
              style="overflow:hidden"
              id="Stacks"
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
            <button v-if="!isEdit" class="btn btn-primary input-group-btn" @click.prevent="saveUsers(usuario)">
              Salvar
            </button>
            <button v-if="isEdit" class="btn btn-primary input-group-btn" @click.prevent="updateUsers(usuario)">
              Atualizar
            </button>
          </div>
        </form>
      </div>
    </div>
   
  </div>
</template>

<script>


export default {
  name: 'Cadastro',

  data() {
    return {
      usuarios: [],
      name: 'Formulário de Técnico',
      ex: 'Cadastro de Técnicos',
      isEdit: false,
      usuario: {
        ckecked: false,
        nome: '',
        id: '',
        cpf: '',
        cep: '',
        email: '',
        dataNasc: '',
        cid: '',
        est: '',
        stacks: [],
      },

         }
  },

  computed: {
    usuariosCount() {
      return `Total de Técnicos Cadastrados é ${this.usuarios.length}`
    },
  },

  created() {
    this.usuarios = JSON.parse(localStorage.getItem('usuariosApp'))
    //console.log('Vue Criado...')
  },

  methods: {
    saveUsers(usuario) {
      let usuarios = localStorage.getItem('usuariosApp')
      //console.log(usuario)
      usuario.id = new Date().getTime()

      if (usuarios) {
        // atualizar meus usuarios no local storage
        usuarios = JSON.parse(usuarios)
        usuarios.push(usuario)
      } else {
        //eu crio esta chave usuarios
        usuarios = [usuario]
      }
      this.usuarios = usuarios
      //atualizar local storage independentemente de novo usuario ou nova adição
      localStorage.setItem('usuariosApp', JSON.stringify(usuarios))
      location.reload()
    },

    removeUsers(usuarioId) {
      let usuarios = localStorage.getItem('usuariosApp')

      if (!usuarios) return

      usuarios = JSON.parse(usuarios)

      usuarios = usuarios.filter(usuario => {
        return usuario.id != usuarioId
      })

      this.usuarios = usuarios

      localStorage.setItem('usuariosApp', JSON.stringify(usuarios))
    },

    editUsers(usuario) {
      this.usuario = usuario
      this.isEdit = true
    },

    updateUsers(usuario) {
      let usuarios = this.usuarios.map(usuarioMap => {
        if (usuarioMap.id == usuario.id) {
          return usuario
        }
        return usuarioMap
      })

      this.usuarios = usuarios
      this.isEdit = false
      localStorage.setItem('usuariosApp', JSON.stringify(usuarios))

      location.reload()
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
