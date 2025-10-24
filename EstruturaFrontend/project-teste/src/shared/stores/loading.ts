import { defineStore } from 'pinia';
import { ref, computed } from 'vue';
import type { LoadingState } from '@/shared/types/loading'; 

export const useLoadingStore = defineStore('loading', () => {
    
    const isLoading = ref<LoadingState['isLoading']>(true);

    const startLoading = () => {
        isLoading.value = true;
    };

    const finishLoading = () => {
        isLoading.value = false;
    };
    
    const isReady = computed(() => !isLoading.value);

    return {
        isLoading,
        isReady,
        startLoading,
        finishLoading,
    };
});