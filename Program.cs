// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text.Json;

internal class Program
{
    static void Main(string[] args)
    {

        //DevuelveCivilizaciones();
       // caracteristicasCivilizacion(4);

        string? resp = "s";
        do
        {
            DevuelveCivilizaciones();
            Console.WriteLine("ingrese el id de la civilizacion para ver sus caracteristicas");
            var id=Convert.ToInt32(Console.ReadLine()) ;
            caracteristicasCivilizacion(id);

            Console.WriteLine("quiere ingresar otra covilizacion? (s/n)");
            resp = Console.ReadLine();
        } while (resp != "n");


      
    }
    private static void DevuelveCivilizaciones(){
        
        var url=$"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
        var request =(HttpWebRequest)WebRequest.Create(url);
        request.Method="GET";
        request.ContentType="application/json";
        request.Accept="application/json";

        try
        {
            using ( WebResponse response = request.GetResponse())// respuesta de la api
            {
                using (Stream sr = response.GetResponseStream())// lo convierte en un steam
                {
                    if (sr ==null) return ;
                    using (StreamReader objReader=new StreamReader(sr)) // luego lo convierte en un steamReader
                    {
                        string responseBody=objReader.ReadToEnd();// luego al SR lo convierte en un string (bloque de texto o json resultante)
                        Civilizaciones listaCivilizaciones= JsonSerializer.Deserialize<Civilizaciones>(responseBody);

                        foreach (Civilization civil in listaCivilizaciones.Civilizations)
                        {
                            Console.WriteLine($"ID: {civil.Id} Civilizacion: {civil.Name } ");
                        }
                    }

                }

            }
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    private static void caracteristicasCivilizacion(int id){
        var url =$"https://age-of-empires-2-api.herokuapp.com/api/v1/civilization/{id}";
        var request =(HttpWebRequest)WebRequest.Create(url);
        request.Method="GET";
        request.ContentType="application/json";
        request.Accept="application/json";

        try
        {
            using (WebResponse response = request.GetResponse()  )
            {
                using (Stream sr=response.GetResponseStream() )
                {
                    if (sr==null) return ;

                    using (StreamReader objReader = new StreamReader(sr))
                    {
                        string responseBody=objReader.ReadToEnd();
                        Civilization civilizacion=JsonSerializer.Deserialize<Civilization>(responseBody);
                        Console.WriteLine($"caracteristicas");
                        Console.WriteLine($"ID: {civilizacion.Id}");
                        Console.WriteLine($"Nombre: {civilizacion.Name} ");
                        Console.WriteLine($"Expansion: {civilizacion.Expansion}");
                        Console.WriteLine($"Army_type : {civilizacion.ArmyType}");
                        
                        foreach (var unidad in civilizacion.UniqueUnit)
                        {
                            Console.WriteLine($"unique_unit: {unidad}");
                        }

                        Console.WriteLine($"unique_tech: {civilizacion.UniqueTech}");
                        
                        Console.WriteLine($"team Bonus: {civilizacion.TeamBonus}");                    

                    }
                }
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }





    }




}