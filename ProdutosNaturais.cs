using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_DA1
{
    public class ProdutoNatural : ProdutoAlimentar
    {
        //private int m_IdProdutoNatural;
        private string m_PaisOrigem ;
        private bool m_Biologico;

        public ProdutoNatural(int id, string nome, int nDistribuidores, string nomeDistribuidor) :base (id, nome, 5 ,nDistribuidores,  nomeDistribuidor)
        {
            m_PaisOrigem = "Portugal";
            m_Biologico = false;
        }

        public string PaisOrigem
        {
            get { return m_PaisOrigem; }

        }

        public bool Biologico
        {
            get { return m_Biologico; }
            set { m_Biologico = value; }
        }

        public bool Saudavel()
        {
          return true;
        }

        //construtor

        

    }      
    
}



    
