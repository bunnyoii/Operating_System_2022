<template>
  <memory msg="Welcome to my memory management homework with Vue.js App"/>
</template>

<script>
import memory from './components/memory.vue'

export default {
  name: 'App',
  components: {
    memory
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 30px;
}
</style>
