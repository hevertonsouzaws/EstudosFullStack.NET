<template>
    <img :src="avatar">
</template>

<script>
export default {
    name: 'Picture',
    data() {
        return {
            avatar: "/img/logows.jpg", 
            descricao: "logo websupply"
        }
    }
}

</script>