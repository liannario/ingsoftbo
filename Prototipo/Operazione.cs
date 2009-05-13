using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    abstract class Operazione
    {
        public virtual void Operazione(Guest g)
        {
            throw new Exception("non puoi fare questa operazione");
        }
        public virtual void Operazione(Operatore o)
        {
            throw new Exception("non puoi fare questa operazione");
        }
        public abstract void Operazione(Amministratore a);
        
    }
}
