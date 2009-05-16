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
            //Creazione categorie
            Categoria pneumatici = new Categoria("Pneumatici");
            Categoria pneumaticiTermici = new Categoria("Pneumatici Termici");
            Categoria pneumaticiNormali = new Categoria("Pneumatici Normali");
            Negozio.GetInstance().CategoriaRoot.CategoriaCollection.Add(pneumatici);
            pneumatici.CategoriaCollection.Add(pneumaticiTermici);
            pneumatici.CategoriaCollection.Add(pneumaticiNormali);

            //Creazione magazzini
            Magazzino m1 = new Magazzino("Magazzino centrale", "Via Saragozza");
            
            //Aggiunta prodotti ai magazzini
            m1.Prodotti.Add(new Prodotto("012345", "Pneumatico termico Pirelli", 345.22, 380, 10, pneumaticiTermici));
            m1.Prodotti.Add(new Prodotto("012346", "Pneumatico termico Michelin", 365.22, 400, 7, pneumaticiTermici));
            m1.Prodotti.Add(new Prodotto("012347", "Pneumatico Bridgestone", 244.24, 270, 12, pneumaticiNormali));

            //Aggiunta magazzino al negozio
            Negozio.GetInstance().Magazzini.Add(m1);
            
            //Aggiunta Clienti al negozio
            ClienteAzienda clienteAzienda1 = new ClienteAzienda("01234567890", "Progetto s.r.l.", "via saragozza 1", "info@azienda.it", true, "01234567890", "020202020");
            clienteAzienda1.Vetture.Add(new Vettura("CZ373KS", "Lancia Y"));
            clienteAzienda1.Vetture.Add(new Vettura("CZ474SW", "Alfa Mito"));
            clienteAzienda1.WheelCard.Punti = 1250;
            Negozio.GetInstance().Clienti.Add(clienteAzienda1);

            ClientePrivato clientePrivato1 = new ClientePrivato("cliente", "privato", new DateTime(1970, 1, 1), "via saragozza 2", "cliente@privato.it", true, "cltprv70a1g732", "020202020");
            clientePrivato1.Vetture.Add(new Vettura("DA263GS", "Ferrari F430"));
            clientePrivato1.Vetture.Add(new Vettura("DC878EW","Lamborghini Murcielago"));
            clientePrivato1.WheelCard.Punti = 500;
            Negozio.GetInstance().Clienti.Add(clientePrivato1);

            //Run del login
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
