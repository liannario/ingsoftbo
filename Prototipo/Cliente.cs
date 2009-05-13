using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    abstract class Cliente
    {
        public Vetture _vetture
        {
            get { return _vetture; }
            set { _vetture = value; }
        }
        public String Indirizzo
        {
            get { return Indirizzo; }
            set { Indirizzo = value; }
        }
        public String Email
        {
            get { return Email; }
            set { Email = value; }
        }
        public String Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        public Boolean Privacy
        {
            get { return Privacy; }
            set { Privacy = value; }
        }
    }

    public class ClientePrivato : Cliente
    {
        private String Nome;
        private String 
       
        public String Nome
        {
            get { return Nome; }
            set { Nome = value; }
        }
        public DateTime
    }
        
}
