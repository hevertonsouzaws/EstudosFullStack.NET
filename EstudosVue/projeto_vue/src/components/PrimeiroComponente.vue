<template>
  <div>
    <h1>Olá Vue!</h1>
    <p>Meu nome é: {{ nome }}</p>
    <p>E trabalho como: {{ profissao }}</p>
  </div>
</template>


<script>
export default {
  name: "PrimeiroComponente",
  data() {
    return {
      nome: "Heverton",
      profissao: "Dev WS"
    }
  }
};
</script>