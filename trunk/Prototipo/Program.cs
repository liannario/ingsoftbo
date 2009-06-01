using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prototipo
{
    public static class Program
    {
        //Parametri per inviare le mail
        public static readonly string EmailAdmin = "lucaiannario@gmail.com";
        public static readonly string EmailPasswd = "?!c4ss4ndr4?!";

        //Soglia limite per la giacenza
        public const int Soglia = 2;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            //Creazione categorie
            //Categoria pneumatici = new Categoria("Pneumatici");
            Categoria pneumaticiTermici = new Categoria("Pneumatici Termici");
            Categoria pneumaticiNormali = new Categoria("Pneumatici Normali");
            Categoria cerchi = new Categoria("Cerchi");
            Categoria accessori = new Categoria("Accessori");
            //Negozio.GetInstance().CategoriaRoot = pneumatici;
            Negozio.GetInstance().CategoriaRoot.CategoriaCollection.Add(pneumaticiTermici);
            Negozio.GetInstance().CategoriaRoot.CategoriaCollection.Add(pneumaticiNormali);
            Negozio.GetInstance().CategoriaRoot.CategoriaCollection.Add(cerchi);
            Negozio.GetInstance().CategoriaRoot.CategoriaCollection.Add(accessori);

            //Creazione magazzini
            Magazzino m1 = new Magazzino("Magazzino centrale", "Via Saragozza");
            
            //Aggiunta prodotti ai magazzini
            m1.Prodotti.Add(new Prodotto("012345", "Pneumatico termico Pirelli", 345.22, 380, 10, pneumaticiTermici));
            m1.Prodotti.Add(new Prodotto("012346", "Pneumatico termico Michelin", 365.22, 400, 7, pneumaticiTermici));
            m1.Prodotti.Add(new Prodotto("012347", "Pneumatico Bridgestone", 244.24, 270, 12, pneumaticiNormali));
            m1.Prodotti.Add(new Prodotto("012348", "Cerchi in lega", 232.24, 260, 8, cerchi));
            m1.Prodotti.Add(new Prodotto("012349", "Catene da neve", 35.22, 50, 20, accessori));
            m1.Prodotti.Add(new Prodotto("012350", "Pneumatico Dunlop", 279.24, 300, 15, pneumaticiNormali));

            //Aggiunta magazzino al negozio
            Negozio.GetInstance().Magazzini.Add(m1);
            
            //Aggiunta Clienti al negozio
            ClienteAzienda clienteAzienda1 = new ClienteAzienda("01234567890", "Progetto s.r.l.", "via saragozza, 1", "info@progettosrl.it", true, "01234567890", "0513464222");
            clienteAzienda1.Vetture.Add(new Vettura("CZ373KS", "Lancia Y"));
            clienteAzienda1.Vetture.Add(new Vettura("CZ474SW", "Alfa Mito"));
            clienteAzienda1.WheelCard.Punti = 1250;
            Negozio.GetInstance().Clienti.Add(clienteAzienda1);

            ClienteAzienda clienteAzienda2 = new ClienteAzienda("34564567890", "Azienda s.r.l.", "viale aldini, 93", "info@azienda.it", true, "34564567890", "0510934555");
            clienteAzienda2.Vetture.Add(new Vettura("CA373KS", "Fiat Punto"));
            clienteAzienda2.Vetture.Add(new Vettura("CS474SQ", "Ducato Maxi"));
            clienteAzienda2.WheelCard.Punti = 2000;
            Negozio.GetInstance().Clienti.Add(clienteAzienda2);

            ClientePrivato clientePrivato1 = new ClientePrivato("Cliente", "privato", new DateTime(1970, 5, 18), "via saragozza, 2", "cliente@privato.it", true, "CLTPRV70E18G732A", "328435432");
            clientePrivato1.Vetture.Add(new Vettura("DA263GS", "Ferrari F430"));
            clientePrivato1.Vetture.Add(new Vettura("DC878EW","Lamborghini Murcielago"));
            clientePrivato1.WheelCard.Punti = 500;
            Negozio.GetInstance().Clienti.Add(clientePrivato1);

            ClientePrivato clientePrivato2 = new ClientePrivato("Cliente2", "privato", new DateTime(1987, 3, 6), "via turati, 23", "cliente2@privato.it", true, "CLTPRV87C06G732A", "3335688421");
            clientePrivato2.Vetture.Add(new Vettura("BZ463GS", "Mercedes SLK AMG"));
            clientePrivato2.Vetture.Add(new Vettura("CV878EW", "Lamborghini Gallardo"));
            clientePrivato2.WheelCard.Punti = 845;
            Negozio.GetInstance().Clienti.Add(clientePrivato2);

            ////Aggiunta vendita che ha impostato una notifica
            //string messaggio = "La invitiamo ad effettuare un controllo dei prodotti venduti. Distinti saluti";
            //Vendita vendita1 = new Vendita(new DateTime(2009, 5, 18), TipoDocumentoVendita.Scontrino, new Prodotti(), new Notifiche(), new Clienti());
            //vendita1.Notifiche.Add(new Notifica(TipoNotifica.email, messaggio, "lucaiannario@gmail.com", new DateTime(2009, 5, 18)));
            //Negozio.GetInstance().Vendite.Add(vendita1);

            //Run del login
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
