using System;
using System.Threading.Tasks;
using System.Net.Http;
using NBomber.CSharp;
using Teste.Arquitetura.Server.Models.DTO;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Newtonsoft.Json;

using var httpClient = new HttpClient();

var scenario1 = Scenario.Create("Report Scenario", async context =>
{
    var date = DateTime.MinValue;
    DateTime.TryParse("2024-04-09", out date);
    var response = await httpClient.GetAsync("https://localhost:32768/Cashflow/" + date.ToString() );
    return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
})
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: 50,
                                  interval: TimeSpan.FromSeconds(1),
                                  during: TimeSpan.FromMinutes(1))
            );

var scenario2 = Scenario.Create("Inject Scenario", async context =>
{
    string json = JsonConvert.SerializeObject(new CashFlow());
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await httpClient.PostAsync("https://localhost:32768/Cashflow/Manually", content);
    return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
})
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: 50,
                                  interval: TimeSpan.FromSeconds(1),
                                  during: TimeSpan.FromMinutes(1))
            );

NBomberRunner
    .RegisterScenarios([scenario1, scenario2])
    .Run();




