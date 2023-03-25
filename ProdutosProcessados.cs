using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_DA1
{
    public class ProdutosProcessados : ProdutoAlimentar
    {
        
        private string m_marca;
        private int m_numUnidEmbalagem;
        private int m_numDiasValidade;

        public ProdutosProcessados(int id,string nome, string marca, int nDistribuidores, string nomeDistribuidor) : base (id,nome, 10,  nDistribuidores,  nomeDistribuidor)
        {
            m_marca = marca;
            m_numDiasValidade = 1;
            m_numUnidEmbalagem = 1;
        }

        public string Marca
        {
            get { return m_marca; }
        }

        public int NumUnidEmbalagem
        {
            get { return m_numUnidEmbalagem; }
            set { m_numUnidEmbalagem = value; }
        }

        public int NumDiasValidade
        {
            get { return m_numDiasValidade; }
            set { m_numDiasValidade = value; }
        }

        public virtual bool Saudavel()

        {
            if (ValorMedioLipidos <= 10 && ValorMedioCarboHidratos <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public override double ValorTotalNutricional()
        {
            return ((PesoUnid * ValorNutricional100g())/100) * m_numUnidEmbalagem;
        }

        public override double PrecoVenda()
        {
            return MargemComercialização() + Custo + (1 * m_numUnidEmbalagem);
        }

    }
}
