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
            get
            {
                if (_categoriaCollection == null)
                    return new CategoriaCollection();
                return _categoriaCollection;
            }
            set { _categoriaCollection = value; }
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
