using Espacio.cambios;
using System;
using System.Net;
using System.Text.Json;

var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";

try{
    using(WebResponse response = request.GetResponse()){
        using(Stream strReader = response.GetResponseStream()){
            if(strReader == null) return;
            using(StreamReader objReader = new StreamReader(strReader)){
                string responseBody = objReader.ReadToEnd();
                Root cripto = JsonSerializer.Deserialize<Root>(responseBody);
                Console.WriteLine("\u001b[1;4mNombre\u001b[0m: " + cripto.bpi.EUR.description + " \u001b[1;4mCódigo\u001b[0m: " + cripto.bpi.EUR.code + " \u001b[1;4mPrecio\u001b[0m: " + cripto.bpi.EUR.rate_float);
                Console.WriteLine("\u001b[1;4mNombre\u001b[0m: " + cripto.bpi.GBP.description + " \u001b[1;4mCódigo\u001b[0m: " + cripto.bpi.GBP.code + " \u001b[1;4mPrecio\u001b[0m: " + cripto.bpi.GBP.rate_float);
                Console.WriteLine("\u001b[1;4mNombre\u001b[0m: " + cripto.bpi.USD.description + " \u001b[1;4mCódigo\u001b[0m: " + cripto.bpi.USD.code + " \u001b[1;4mPrecio\u001b[0m: " + cripto.bpi.USD.rate_float);
            }
        }
    }
}
catch (WebException ex){
    Console.WriteLine("No se ha podido acceder a la API");
}
