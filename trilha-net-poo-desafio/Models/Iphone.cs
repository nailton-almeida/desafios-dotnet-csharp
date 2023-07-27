namespace DesafioPOO.Models;


public class Iphone : Smartphone
{
    public Iphone(string numero, string modelo, string iMEI, int memoria) : base(numero, modelo, iMEI, memoria)
    {
    }

 
    public override void InstalarAplicativo(string nomeApp)
    {
        Console.WriteLine($"Aplicativo instalado {nomeApp} no Iphone");
    }
}