using Microsoft.Extensions.Primitives;

namespace FirstWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Un builder caricare configuration, environments e default services
            // Environments si intente API URLS o nomi server
            // Configurations impostazioni come le stringhe di connessione
            var builder = WebApplication.CreateBuilder(args);

            // Richiamando il Build() otterremo un'istanza di web application
            // che è riferibile da una variabile 'app'
            // attraverso questa istanza sarà possibile configurare i 'Middlewares'
            // della tua applicazione
            var app = builder.Build();

            // Ogni qualvolata viene passato un URL di richiesta ad un localhost:port number
            // La risposta sarà Hello World
            // app.MapGet("/", () => "Hello World!");

            // passo un unico argoment come lambda expression che conterrà come argomento
            // 'context', un'oggetto che sarà istanziato in automatico al ricevimento di una richiesta HTTP
            app.Run( async (HttpContext context) =>
            {
                // context.Request
                // context.Response.StatusCode = 400;

                // headers è un 'dictionary' che aggiungerà una coppia di chiavi
                // quando il browser invierà una richiesta, verrà inviata questa coppia di chiavi
                // come 'response' header al browser
                context.Response.Headers["MyKey"] = "my_value_key";
                context.Response.Headers["Server"] = "my_server";
                context.Response.Headers["Content-Typer"] = "text/html";

                // POST 
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                // questo metodo legge una query string e converte il salvataggio in un 'dictionary' object (mapping)
                // StringValues può rappresentare moltiplici valori, anche in caso di restituzione di un singolo valore
                // richiede essere usato come tipo
                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                // check if query dictionary contains a key in whiche we are interested
                if (queryDict.ContainsKey("firstName")) 
                {
                    string ?firstName = queryDict["firstName"][0];
                    await context.Response.WriteAsync(firstName);
                }

                /* GET
                // Query string

                string path = context.Request.Path;

                if (context.Request.Headers.ContainsKey("User-Agent")) 
                {
                    // string userAgent = context.Request.Headers["User-Agent"];
                    string auth = context.Request.Headers["AuthorizationKey"];
                    await context.Response.WriteAsync($"<p>{auth}</p>");

                    //if (context.Request.Query.ContainsKey("id")) 
                    //{
                    //    string id = context.Request.Query["id"]; // localhost:....?id=1&name=scott
                    //    await context.Response.WriteAsync($"<p>{id}</p>");
                    //}
                }

                // per restituire un attuale response body sarà necessario fornire la risposta
                await context.Response.WriteAsync("<h1>Hello</h1>");
                await context.Response.WriteAsync("<h2>World</h2>");

                // await specifica che il codice sucessivo allo statement dovrò attendere il completamento
                // il codice successivo verrà eseguito */
            });

            app.Run();
        }
    }
}
