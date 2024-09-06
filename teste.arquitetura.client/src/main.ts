import { createApp } from 'vue'
import App from './App.vue';
import  router  from './router/index';
import Highcharts from 'highcharts';
import Dashboards from '@highcharts/dashboards';
import DataGrid from '@highcharts/dashboards/datagrid';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'


import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.js'

const app = createApp(App)

Dashboards.HighchartsPlugin.custom.connectHighcharts(Highcharts);
Dashboards.DataGridPlugin.custom.connectDataGrid(DataGrid);
Dashboards.PluginHandler.addPlugin(Dashboards.HighchartsPlugin);
Dashboards.PluginHandler.addPlugin(Dashboards.DataGridPlugin);

app.use(router)
app.component('font-awesome-icon', FontAwesomeIcon)
app.mount('#app')
