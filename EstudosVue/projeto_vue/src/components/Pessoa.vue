<template>
  <div>
    <h2>Dados do: {{ nome }}</h2>
    <Info />
    <Form />
  </div>
</template>

<script>
import Form from './Form.vue';
import Info from './Info.vue';

export default {
  name: 'Lyfecycle2',
  components: {
    Info,
    Form
  },
  data() {
    return {
      nome: 'Heverton'
    }
  }
}
</script>
