<template>
  <div>
    <Header />
    <PrimeiroComponente />
    <LifeCycle />
    <Pessoa />
    <MultiplosEventos />
  </div>
</template>

<script>

import PrimeiroComponente from './components/PrimeiroComponente.vue'
import LifeCycle from './components/LifeCycle.vue'
import Pessoa from './components/Pessoa.vue'
import Header from './components/Header.vue';
import MultiplosEventos from './components/MultiplosEventos.vue';

export default {
  name: 'App',
  components: {
    Header,
    PrimeiroComponente,
    LifeCycle,
    Pessoa,
    MultiplosEventos
  }
}
</script>

<style>
* {
  padding: 0;
  margin: 0;
  color: #fff;
}

body {
  background: linear-gradient(180.73deg, #0e0c2b -51.9%, #0b1336 131.43%, #0c1253 131.45%);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

body ul, li{
  list-style: none;
}
</style>