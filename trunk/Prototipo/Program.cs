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
            Negozio.GetInstance().Magazzini.Add(m1);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RicercaProdottoForm());
        }
    }
}
