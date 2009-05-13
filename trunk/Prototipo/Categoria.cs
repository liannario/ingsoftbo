using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Categoria
    {
        private string _nome;
        private CategoriaCollection _categoriaCollection;

        public Categoria()
        { 
        }

        public Categoria(string nome)
               : this(nome, null)
        {
        }

        public Categoria(string nome, CategoriaCollection categoriaCollection)
        {
            Nome = nome;
            _categoriaCollection = categoriaCollection;
        }
        
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public CategoriaCollection CategoriaCollection
        {
            get { return _categoriaCollection; }
            set { _categoriaCollection = value; }
        }
    }
}
