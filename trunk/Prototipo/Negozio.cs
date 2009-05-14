using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Negozio
    {
        private static Negozio _instance = null;
        private static Utenti _utenti;
        private static Utente _utenteCorrente;
        private static Magazzini _magazzini;
        private static Vendite _vendite;
        private static Clienti _clienti;
        private static Categoria _categoriaRoot;

        protected Negozio()
        {
            _utenti = new Utenti();
            _magazzini = new Magazzini();
            _vendite = new Vendite();
            _clienti = new Clienti();
            _categoriaRoot = new Categoria("Principale", new CategoriaCollection());
        }

        public static Negozio GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Negozio();
                return _instance;
            }
            return _instance;
        }

        public Utenti Utenti
        {
            get { return _utenti; }
            set { _utenti = value; }
        }

        public Utente UtenteCorrente
        {
            get { return _utenteCorrente; }
            set { _utenteCorrente = value; }
        }

        public Magazzini Magazzini
        {
            get { return _magazzini; }
            set { _magazzini = value; }
        }

        public Vendite Vendite
        {
            get { return _vendite; }
            set { _vendite = value; }
        }

        public Clienti Clienti
        {
            get { return _clienti; }
            set { _clienti = value; }
        }

        public Categoria CategoriaRoot
        {
            get { return _categoriaRoot; }
            set { _categoriaRoot = value; }
        }
    }
}
