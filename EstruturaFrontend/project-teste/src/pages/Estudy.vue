<script setup lang="ts">
import AutoCarousel from '@/shared/components/Estudy/AutoCarousel.vue';
import Carrousel from '@/shared/components/Estudy/Carrousel.vue';
import ChangeName from '@/shared/components/Estudy/ChangeNameForm.vue';
import EmployeeForm from '@/shared/components/Estudy/EmployeeForm.vue';
import EmployeeList from '@/shared/components/Estudy/EmployeeList.vue';
</script>

<template>
  <div class="w-full">

    <div class="max-w-xl m-auto rounded-lg border border-gray-400 mt-10">
      <h1 class="text-3xl text-center">
        Estudos com estrutura Front
      </h1>
    </div>

    <div class="max-w-4xl m-auto mt-10 flex flex-col gap-10">
      <div class="">
        <ChangeName />
      </div>
      <div class="flex items-center justify-between gap-5">
        <div class="w-full">
          <EmployeeForm />
        </div>
        <div class="w-full">
          <EmployeeList />
        </div>
      </div>
      <div>
        <Carrousel />
      </div>
      <div>
        <AutoCarousel />
      </div>
    </div>
  </div>
</template>