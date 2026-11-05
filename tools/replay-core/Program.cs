using System;
using AvatarWorld.Core.Economy;

// Comandos (stdout estável, para tools/recon_contract.py replay):
//   bundle-price <id>   preço em moedas do combo (ex.: PB22); exit 2 se não existe
static class Program
{
    static int Main(string[] a)
    {
        if (a.Length == 2 && a[0] == "bundle-price")
        {
            var offer = StoreCatalog.Find("bundle-" + a[1]);
            if (offer == null) { Console.Error.WriteLine("unknown bundle " + a[1]); return 2; }
            Console.Out.Write(offer.Price + "\n");
            return 0;
        }
        Console.Error.WriteLine("usage: bundle-price <id>");
        return 64;
    }
}
