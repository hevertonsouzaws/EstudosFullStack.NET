import { ref } from 'vue';
import { defineStore } from 'pinia';

export const useNameChengerStore = defineStore('nameChanger', () => {
  const currentName = ref<string>('SomosWS');

  const setName = (newName: string): void => {
    currentName.value = newName;
  }

  return { currentName, setName };
})