<template>
    <header>
        <div>
            <img src="/img/logo-websupply-new.svg" alt="">
        </div>
    </header>
</template>

<script>
export default {
    name: 'Header'
}
</script>

<style scoped>
header {
    width: 100%;
    height: 130px;
    border-bottom: 2px solid rgb(5, 77, 185);
    text-align: center;
    background: linear-gradient(180.73deg, #0c1253 131.45%, #0b1336 131.43%, #0e0c2b -51.9%);
}

header:hover {
    
    background: linear-gradient(180.73deg, #0e0c2b -51.9%, #0b1336 131.43%, #0c1253 131.45%);
}

img {
    width: 400px;
    height: 100px;
    padding-top: 20px;
}
</style>