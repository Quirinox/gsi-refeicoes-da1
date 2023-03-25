using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_DA1
{
    public class Refeicoes : ProdutosProcessados
    {
       
        private string m_modoPreparacao;
        private int m_tempoPrep;
        private bool m_gourmet;

        public Refeicoes(int id, string nome, string marca, int nDistribuidores, string nomeDistribuidor) : base(id,nome, marca,  nDistribuidores,  nomeDistribuidor)
        {
            m_modoPreparacao = "Sem informação adicional";
            m_tempoPrep = 180;
            m_gourmet = false;
        }


        public bool Gourmet
        {
            get { return m_gourmet; }
            set { m_gourmet = value; }
        }
        public string ModoPreparacao
        {
            get { return m_modoPreparacao; }
            set { m_modoPreparacao = value; }
        }

        public int TempoPreparacao
        {
            get { return m_tempoPrep; }
            set { m_tempoPrep = value; }
        }

        public override double MargemComercialização()
        {   
            if (m_gourmet)
            {
                return Custo * 0.2;
            }
            return base.MargemComercialização();
        }

        public override bool Saudavel()
        {
            if (ValorNutricional100g() * PesoUnid <= 800)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override double PrecoVenda()
        {
            return MargemComercialização() + Custo;
        }
        

    }

}
