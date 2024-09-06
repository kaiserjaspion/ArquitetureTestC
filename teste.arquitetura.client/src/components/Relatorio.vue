<template>
   <div class="container-lg mt-5">

      <input class="form-control form-control-lg mt-2" type="date" placeholder="Date" aria-label="Date" tabindex="2" />

      <table class="table mt-5">
         <thead>
            <tr>
               <th scope="col">Id</th>
               <th scope="col">CPF</th>
               <th scope="col">Value</th>
               <th scope="col">Date</th>
            </tr>
         </thead>
         <tbody>
            <tr v-for="i in post" :key="i.id" class="accordion-item">
               <th scope="row">{{i.id}}</th>
               <td>{{i.cpf}}</td>
               <td>{{i.value}}</td>
               <td>{{i.date}}</td>
            </tr>
         </tbody>
      </table>

      <div class="d-grid gap-2 d-md-flex justify-content-md-end mt-2">
         <button type="button" class="btn btn-success" tabindex="1">Download</button>
      </div>
   </div>
</template>

<script lang="ts">
   import { defineComponent } from 'vue';
   import axios from "axios";

   type CashFlow = {
      id: string,
      value: number,
      cpf: string
      date: string,
      itens: Item[],
      dtChanged: string,
      isActive: boolean
   }[];

   type Item = {
      id: string,
      price: number,
      name: string,
      quantity: number,
      cashFlowId: string,
      dtChanged: string,
      isActive: boolean
   }[]

   interface Data {
      loading: boolean,
      post: null | CashFlow,
      searchDate: string
   }

   export default defineComponent({
      data(): Data {
         return {
            loading: false,
            post: null,
            searchDate: "",
         };
      },
      created() {
         const date = new Date(Date.now());
         this.searchDate = date.toString()
         this.fetchData();
      },
      watch: {
         // call again the method if the route changes
         '$route': 'fetchData'
      },
      methods: {
         fetchData(): void {
            this.post = null;
            this.loading = true;
            axios.get('https://localhost:44333/CashFlow/' + new Date(this.searchDate).getFullYear() + '-' + new Date(this.searchDate).getMonth() + '-' + new Date(this.searchDate).getDay())
               .then((response) => { this.post = response.data as CashFlow })
               .catch((error) => { })
         }
      },
   });
</script>