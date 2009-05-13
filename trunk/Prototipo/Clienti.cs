using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Clienti : List<Cliente>
    {
        public IList<Cliente> CercaClienteByCF(string cf)
        {
            List<Cliente> result = new List<Cliente>();
            foreach (Cliente c in this)
            {
                if (c.Cf.Contains(cf))
                    result.Add(c);
            }
            return result;
        }
    }
}
