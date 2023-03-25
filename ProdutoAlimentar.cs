using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_DA1
{
   public abstract class ProdutoAlimentar
    {
        private int m_idProduto;
        private string m_nome;
        private double m_custo;
        private double m_valMedProteinas;
        private double m_valMedCarboHidratos;
        private double m_valMedLipidos;
        private bool m_alergenio;
        private double m_PesoUnid;
        private int m_numDistribuidores;
        private string m_distribuidorPrincipal;
        private int m_numMaxDistribuidores;
        private double m_valNutri100g;

        public int IdProduto
        {
            get { return m_idProduto; }
        }

        public string Nome 
        {
            get { return m_nome; }
        }

        public double Custo
        {
            get { return m_custo; }
            set { m_custo = value; }
        }

        public double ValorMedioProteinas
        {
            get { return m_valMedProteinas; }
            set { m_valMedProteinas = value; }
        }

        public double ValorMedioCarboHidratos
        {
            get { return m_valMedCarboHidratos; }
            set { m_valMedCarboHidratos = value; }
        }

        public double ValorMedioLipidos
        {
            get { return m_valMedLipidos; }
            set { m_valMedLipidos = value; }
        }

        public  bool Alergenios
        {
            get { return m_alergenio; }
            set { m_alergenio = value; }
        }

        public double PesoUnid
        {
            get { return m_PesoUnid; }
            set { m_PesoUnid = value; }
        }

        public int NumDistribuidores
        {
            get { return m_numDistribuidores; }
        }

        public string DistribuidorPrincipal
        {
            get { return m_distribuidorPrincipal; }
        }
        public int NumMaximoDistribuidores
        {
            get { return m_numMaxDistribuidores;}
        }

        public ProdutoAlimentar (int id,string nome, int maxDistribuidores, int nDistribuidores, string nomeDistribuidor)
        {
            m_idProduto = id;
            m_nome = nome;
            m_PesoUnid = 0;
            m_custo = 0;
            m_valMedProteinas = 0;
            m_valMedCarboHidratos = 0;
            m_valMedLipidos = 0;
            m_alergenio = true;
            m_numDistribuidores = nDistribuidores;
            m_numMaxDistribuidores = maxDistribuidores;
            m_distribuidorPrincipal = nomeDistribuidor;
        
            

        }

        public bool RegistarDistribuidor()
        {
            if (NumDistribuidores<NumMaximoDistribuidores)
            {
                m_numDistribuidores++;
                return true;
            }
            return false;
        }

        public bool RegistarDistribuidor (string nomeNovoDistribuidor, double custoproposto )
        {
            if (NumDistribuidores < NumMaximoDistribuidores)
            {
                m_numDistribuidores++;
                
                if(custoproposto<m_custo)
                {
                    m_distribuidorPrincipal = nomeNovoDistribuidor;
                    m_custo = custoproposto;
                }
                return true;
            }
            return false;
        }

        public double ValorNutricional100g()
        {
            m_valNutri100g = (m_valMedProteinas * 4) + (m_valMedCarboHidratos * 4) + (m_valMedLipidos * 9);
            return m_valNutri100g;
        }

        
        public virtual double ValorTotalNutricional()
        {
            return (PesoUnid * ValorNutricional100g())/100;
        }

        public virtual double MargemComercialização()
        {
            return m_custo * 0.1;
        }

        public virtual double PrecoVenda()
        {
            return MargemComercialização() + m_custo;
        }

    }
}
