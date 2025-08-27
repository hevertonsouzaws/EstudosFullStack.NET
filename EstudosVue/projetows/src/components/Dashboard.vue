<template>
  <div id="burger-table">
    <div>
      <div id="burger-table-heading">
        <div class="order-id">#:</div>
        <div>Cliente:</div>
        <div>Pão:</div>
        <div>Carne:</div>
        <div>Opcionais:</div>
        <div>Ações:</div>
      </div>
      <div id="burger-table-rows">
        <div class="burger-table-row" v-for="burger in burgers" :key="burger.id">
          <div class="order-number">{{ burger.id }}</div>
          <div>{{ burger.nome }}</div>
          <div>{{ burger.pao }}</div>
          <div>{{ burger.carne }}</div>
          <div>
            <ul>
              <li v-for="(opcional, index) in burger.opcionais" :key="index">{{ opcional }}</li>
            </ul>
          </div>
          <div>
            <select name="status" class="status">
              <option value="">Selecione</option>
              <option v-for="s in status" :key="s.id" value="s.tipo" :selected="burger.status == s.tipo">
                {{ s.tipo }}
              </option>
            </select>
            <button class="delete-btn">Cancelar</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Dashboard',
  data() {
    return {
      burgers: null,
      burger_id: null,
      status: []
    }
  },
  methods: {
    async getPedidos() {

      const req = await fetch("http://localhost:3000/burgers")

      const data = await req.json();

      this.burgers = data;

      // resgatar status
      this.getStatus();

      
    },
    async getStatus() {

      const req = await fetch('http://localhost:3000/status')

      const data = await req.json();

      this.status = data;
    }
  },
  mounted() {
    this.getPedidos();
  }

}
</script>

<style scoped>
#burger-table {
  max-width: 1400px;
  margin: 0 auto;
  border: 2px solid #222;
  padding: 20px;
  border-radius: 15px;
  background-color: #0a0a0511;
}


#burger-table-heading,
#burger-table-rows,
.burger-table-row {
  display: flex;
  flex-wrap: wrap;
  font-weight: bold;
}

#burger-table-heading {
  font-weight: bold;
  padding: 12px;
  border-bottom: 3px solid #333;
}

.burger-table-row {
  width: 100%;
  padding: 12px;
  border: 1.5px solid #c79200;
  border-radius: 10px;
  margin-top: 10px;
}

#burger-table-heading div,
.burger-table-row div {
  width: 19%;
}

#burger-table-heading .order-id,
.burger-table-row .order-number {
  width: 5%;
}

select {
  padding: 10px 8px;
  margin-right: 12px;
  border-radius: 10px;
  border: 2px solid #222;
  cursor: pointer;
  background-color: #222222e8;
  color: #fcba03;
  font-size: 16px;
}

.delete-btn {
  background-color: #440505e0;
  color: #fcba03;
  border: 2px solid #222;
  padding: 10px 15px;
  font-size: 16px;
  margin: 0 auto;
  cursor: pointer;
  transition: .5s;
  border-radius: 10px;
}

.delete-btn:hover {
  color: #fff;
  border: 2px solid #ff0000;
}
</style>