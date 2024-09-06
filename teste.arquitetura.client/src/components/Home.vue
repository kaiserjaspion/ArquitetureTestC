<template>

   <div class="container-lg mt-5">
      <div class="mb-3">

         <input v-model="post.cpf" class="form-control form-control-lg" type="text" placeholder="CPF" aria-label="CPF" tabindex="1" />
         <input v-model="post.date" class="form-control form-control-lg mt-2" type="date" placeholder="Date" aria-label="Date" tabindex="2" />
         <input v-model="post.value" class="form-control form-control-lg mt-2" type="number" placeholder="Value" aria-label="Value" tabindex="3" />

         <div class="container p-2 border mt-4 rounded ">
            <h2 class="px-2">Itens</h2>
            <div v-for="t in post.items" :key="index" class="mt-4">
               <input v-model="t.name" class="form-control form-control-lg" type="text" placeholder="Name" aria-label="Name" :tabindex="index*3+1" />
               <input v-model="t.price" class="form-control form-control-lg mt-2" type="number" placeholder="Price" aria-label="price" :tabindex="index*3+2" />
               <input v-model="t.quantity" class="form-control form-control-lg mt-2" type="number" placeholder="Quantity" aria-label="Quantity" :tabindex="index*3+3" />
            </div>

            <div class="d-grid gap-2 d-md-flex justify-content-md-end mt-2">
               <button type="button" class="btn btn-outline" tabindex="30" @click="listAddItem">
                  <svg viewBox="0 0 448 512" width="24" height="24" >
                     <path d="M256 80c0-17.7-14.3-32-32-32s-32 14.3-32 32l0 144L48 224c-17.7 0-32 14.3-32 32s14.3 32 32 32l144 0 0 144c0 17.7 14.3 32 32 32s32-14.3 32-32l0-144 144 0c17.7 0 32-14.3 32-32s-14.3-32-32-32l-144 0 0-144z"/>
                  </svg>
               </button>
            </div>
         </div>

         <div class="d-grid gap-2 d-md-flex justify-content-md-end mt-4">
            <button type="button" class="btn btn-outline-danger" tabindex="31">Cancel</button>
            <button type="button" class="btn btn-success" tabindex="32" @click="fetchData">Submit</button>
         </div>
      </div>
   </div>
</template>

<script lang="ts">
   import { defineComponent } from 'vue';
   import axios from "axios";

   type Item = {
      id: string,
      price: number,
      name: string,
      quantity: number,
      cashFlowId: string,
      dtChanged: string,
      isActive: boolean
   }

   export default defineComponent({
      data() {
         return {
            items :{
               id: "",
               price: 0,
               name: "",
               quantity: 0,
               cashFlowId: "",
               dtChanged: "",
               isActive: true
            },
            post: {
               id: "",
               value: 0,
               cpf: "",
               date: "",
               items: new Array<Item>(), 
               dtChanged: "",
               isActive: true
            }
         };
      },
      created() {
         console.log(this.post)
      },


      methods: {
         fetchData(): void {

            axios.post('https://localhost:44333/CashFlow', this.post, {
               headers: {
                  'Content-Type': 'application/json'
               }
            })
            .then((response) => {  })
            .catch((error) => { })
         },
         listAddItem() {
            this.post.items.push(this.items)
         }
      },
   });
</script>

<style scoped>
   th {
      font-weight: bold;
   }

   tr:nth-child(even) {
      background: #F2F2F2;
   }

   tr:nth-child(odd) {
      background: #FFF;
   }

   th, td {
      padding-left: .5rem;
      padding-right: .5rem;
   }

   .weather-component {
      text-align: center;
   }

   table {
      margin-left: auto;
      margin-right: auto;
   }
</style>