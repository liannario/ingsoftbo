using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Prodotti : List<Prodotto>
    {
        public IList<Prodotto> CercaProdottoByDescrizione(string descrizione)
        {
            List<Prodotto> result = new List<Prodotto>();
            foreach (Prodotto p in this)
            {
                if(p.Descrizione.Contains(descrizione))
                    result.Add(p);
            }
            return result;
        }

        public IList<Prodotto> CercaProdottoByCodice(string codice)
        {
            List<Prodotto> result = new List<Prodotto>();
            foreach (Prodotto p in this)
            {
                if (p.Descrizione.Contains(codice))
                    result.Add(p);
            }
            return result;
        }
    }
}
