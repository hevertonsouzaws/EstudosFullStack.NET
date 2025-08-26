<template>
    <div id="nav">
        <router-link to="/" id="logo-url">
            <img :src="logo" :alt="alt" id="logo">
        </router-link>



        <router-link to="/">Home</router-link>


        <router-link to="/pedidos">Pedidos</router-link>

    </div>
</template>

<script>
export default {
    name: 'Navbar',
    props: ["logo", "alt"]
}
</script>

<style scoped>
#nav {
    background-color: #222;
    border-bottom: 4px solid #111;
    padding: 15px 20px;
    display: flex;
    align-items: center;
    justify-content: flex-end;
}

#nav #logo-url {
    margin: auto;
    margin-left: 0;
}

#logo {
    width: 50px;
    height: 50px;
}

#nav a {
    color: #FCBA03;
    text-decoration: none;
    margin: 12px;
    transition: .5S;
}

#nav a:hover {
    color: #fff;
}
</style>