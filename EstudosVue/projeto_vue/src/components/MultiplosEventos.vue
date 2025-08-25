<template>
    <div>
        <button @click="primeiro($event), segundo($event)">Ativar múltipos eventos</button>
        <p>ola: {{ multiplos_eventos }}</p>
    </div>
</template>

<script>
export default {
    name: 'MultiplosEventos',
    data() {
        return {
            multiplos_eventos: "VOU MUDAR AQUI!"
        }
    },
    methods: {
        primeiro(e) {
            this.multiplos_eventos = "#SOMOSWS"
        },
        segundo(e) {
            setTimeout(() => this.multiplos_eventos = "WebSupply", 1000)
        }
    }
} 
</script>

<style scoped>
div {
    margin: 150px;
}

button {
    background-color: rgb(235, 235, 253);
    border: 1px solid black;
    color: black;
    padding: 8px;
    border-radius: 5px;
    padding: 20px;
}

button:hover {
    background: linear-gradient(180.73deg, #453bce -51.9%, #162568 131.43%, #1b28b4 131.45%);
    color: white;
}

</style>

