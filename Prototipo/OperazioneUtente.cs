using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public abstract class OperazioneUtente
    {
        public virtual bool Operazione(Guest g)
        {
            return false;
        }
        public virtual bool Operazione(Operatore o)
        {
            return false;
        }
        public abstract bool Operazione(Amministratore a);

    }

    public class ControlloGiacenza : OperazioneUtente
    {
        public override bool Operazione(Guest a)
        {
            return true;
        }

        public override bool Operazione(Operatore a)
        {
            return true;
        }
        
        public override bool Operazione(Amministratore a)
        {
            return true;
        }
    }

    public class EffettuaVendita : OperazioneUtente
    {
        public override bool Operazione(Operatore a)
        {
            return true;
        }

        public override bool Operazione(Amministratore a)
        {
            return true;
        }
    }

    public class GestioneProdotto : OperazioneUtente
    {
        public override bool Operazione(Operatore a)
        {
            return true;
        }

        public override bool Operazione(Amministratore a)
        {
            return true;
        }
    }


}


