using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Magazzini : List<Magazzino>
    {
        public IList<Prodotto> CercaProdottoByDescrizione(string descrizione) 
        {
            List<Prodotto> result = new List<Prodotto>();
            Prodotto[] prodotti = new Prodotto[12];
            int counter = 0;
            foreach (Magazzino m in this) 
            {
                List<Prodotto> temp = (List<Prodotto>) m.Prodotti.CercaProdottoByDescrizione(descrizione);
                temp.CopyTo(prodotti, counter);
                counter += temp.Count;
            }
            Prodotto[] prodottiTrimmed = new Prodotto[counter];
            for (int i = 0; i < counter; i++)
                prodottiTrimmed[i] = prodotti[i];
            return prodottiTrimmed.ToList<Prodotto>(); ;
        }
    }
}
