using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prototipo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Magazzino m1 = new Magazzino("Magazzino centrale", "Via Saragozza");
            m1.Prodotti.Add(new Prodotto("012345", "Pneumatico termico", 345.22, 380, 10));
            m1.Prodotti.Add(new Prodotto("012346", "Pneumatico termico2", 365.22, 400, 7));
            
            Negozio.GetInstance().Clienti.Add(new ClienteAzienda("01234567890", "Progetto s.r.l.", "via saragozza 1", "info@azienda.it", true, "01234567890", "020202020"));
            Negozio.GetInstance().Clienti.Add(new ClientePrivato("cliente", "privato", new DateTime(1970, 1, 1), "via saragozza 2", "cliente@privato.it", true, "cltprv70a1g732", "020202020"));
            

            Negozio.GetInstance().Magazzini.Add(m1);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VenditaForm());
        }
    }
}
