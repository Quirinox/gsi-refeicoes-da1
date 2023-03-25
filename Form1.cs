using System;
using System.Windows.Forms;

namespace Trabalho_DA1
{
    public partial class MyChef : Form
    {
        int idProd = 0;
        ProdutoAlimentar[] produtos = new ProdutoAlimentar[1000];

        public MyChef()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chb_alergenios.Checked = true;
            btn_editar.Enabled = false;
            cb_id_prod_edit.Enabled = false;
            btn_criar_alimento.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_tipo_produto_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cb_tipo_produto.SelectedIndex)
            {
                case 0:
                    AtivarTexto();
                    txt_marca.Enabled = false;
                    txt_unidades_emb.Enabled = false;
                    txt_validade.Enabled = false;
                    txt_modo_prep.Enabled = false;
                    chb_gourmet.Enabled = false;
                    txt_tempo_prep.Enabled = false;
                    txt_pais.Text = "Portugal";
                    txt_pais.Enabled = false;
                    break;
                case 1:
                    AtivarTexto();
                    txt_pais.Enabled = false;
                    chb_bio.Enabled = false;
                    txt_modo_prep.Enabled = false;
                    txt_tempo_prep.Enabled = false;
                    chb_gourmet.Enabled = false;
                    break;
                case 2:
                    AtivarTexto();
                    txt_pais.Enabled = false;
                    chb_bio.Enabled = false;
                    break;
            }
        }

        private void AtivarTexto()
        {
            txt_marca.Enabled = true;
            txt_unidades_emb.Enabled = true;
            txt_validade.Enabled = true;
            txt_modo_prep.Enabled = true;
            txt_pais.Enabled = true;
            txt_tempo_prep.Enabled = true;
            chb_gourmet.Enabled = true;
            chb_gourmet.Enabled = true;
            chb_bio.Enabled = true;
        }

        private void btn_criar_alimento_Click(object sender, EventArgs e)
        {
            if (txt_nome_produto.Text != "" && txt_peso.Text != "" && txt_custo.Text != "" && txt_prot.Text != "" && txt_carbs.Text != "" && txt_lips.Text != "" && txt_nome_dist_princ.Text != "" )
            {
                if (idProd < 1000)
                {
                    switch (cb_tipo_produto.SelectedIndex)
                    {
                        case 0:
                            if (txt_pais.Text != "") {
                                idProd++;
                                if (txt_n_distribuidores.Text == "")
                                {
                                    produtos[idProd - 1] = new ProdutoNatural(idProd, txt_nome_produto.Text, 1, txt_nome_dist_princ.Text);
                                }
                                else
                                {
                                    produtos[idProd - 1] = new ProdutoNatural(idProd, txt_nome_produto.Text, Convert.ToInt32(txt_n_distribuidores.Text), txt_nome_dist_princ.Text);
                                }
                                produtos[idProd - 1].PesoUnid = Convert.ToDouble(txt_peso.Text);

                                produtos[idProd - 1].Custo = Convert.ToDouble(txt_custo.Text);
                                produtos[idProd - 1].ValorMedioProteinas = Convert.ToInt32(txt_prot.Text);
                                produtos[idProd - 1].ValorMedioCarboHidratos = Convert.ToInt32(txt_carbs.Text);
                                produtos[idProd - 1].ValorMedioLipidos = Convert.ToInt32(txt_lips.Text);
                                produtos[idProd - 1].Alergenios = chb_alergenios.Checked;
                               
                                ((ProdutoNatural)produtos[idProd - 1]).Biologico = chb_bio.Checked;

                                lbl_n_alimentos.Text = "Nº de produtos alimentares: " + idProd;
                                AdicionarProduto(produtos[idProd - 1].IdProduto);

                                LimparProduto();
                                txt_pais.Text = "Portugal";
                                MessageBox.Show("Produto adicionado com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("Verifique se todos os campos estão preenchidos.");
                            }

                            break;
                        case 1:
                            if (txt_marca.Text != "" || txt_unidades_emb.Text != "" || txt_validade.Text != "")
                            {
                                idProd++;
                                if (txt_n_distribuidores.Text == "")
                                {
                                    produtos[idProd - 1] = new ProdutosProcessados(idProd, txt_nome_produto.Text, txt_marca.Text, 1 ,txt_nome_dist_princ.Text);
                                }
                                else
                                {
                                    produtos[idProd - 1] = new ProdutosProcessados(idProd, txt_nome_produto.Text, txt_marca.Text, Convert.ToInt32(txt_n_distribuidores.Text), txt_nome_dist_princ.Text);
                                }
                                produtos[idProd - 1].PesoUnid = Convert.ToDouble(txt_peso.Text);
                                produtos[idProd - 1].Custo = Convert.ToDouble(txt_custo.Text);
                                produtos[idProd - 1].ValorMedioProteinas = Convert.ToInt32(txt_prot.Text);
                                produtos[idProd - 1].ValorMedioCarboHidratos = Convert.ToInt32(txt_carbs.Text);
                                produtos[idProd - 1].ValorMedioLipidos = Convert.ToInt32(txt_lips.Text);
                                produtos[idProd - 1].Alergenios = chb_alergenios.Checked;

                                ((ProdutosProcessados)produtos[idProd - 1]).NumUnidEmbalagem = Convert.ToInt32(txt_unidades_emb.Text);
                                ((ProdutosProcessados)produtos[idProd - 1]).NumDiasValidade = Convert.ToInt32(txt_validade.Text);
                                lbl_n_alimentos.Text = "Nº de produtos alimentares: " + idProd;
                                AdicionarProduto(produtos[idProd - 1].IdProduto);

                                LimparProduto();
                                MessageBox.Show("Produto adicionado com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("Verifique se todos os campos estão preenchidos.");
                            }
                            
                            break;

                        case 2:
                            if (txt_marca.Text != "" || txt_unidades_emb.Text != "" || txt_validade.Text != "")
                            {
                                idProd++;
                                if (txt_n_distribuidores.Text == "")
                                {
                                    produtos[idProd - 1] = new Refeicoes(idProd, txt_nome_produto.Text, txt_marca.Text, 1, txt_nome_dist_princ.Text);
                                }
                                else
                                {
                                    produtos[idProd - 1] = new Refeicoes(idProd, txt_nome_produto.Text, txt_marca.Text, Convert.ToInt32(txt_n_distribuidores.Text), txt_nome_dist_princ.Text);

                                }
                                produtos[idProd - 1].PesoUnid = Convert.ToDouble(txt_peso.Text);
                                produtos[idProd - 1].Custo = Convert.ToDouble(txt_custo.Text);
                                produtos[idProd - 1].ValorMedioProteinas = Convert.ToInt32(txt_prot.Text);
                                produtos[idProd - 1].ValorMedioCarboHidratos = Convert.ToInt32(txt_carbs.Text);
                                produtos[idProd - 1].ValorMedioLipidos = Convert.ToInt32(txt_lips.Text);
                                produtos[idProd - 1].Alergenios = chb_alergenios.Checked;

                                ((Refeicoes)produtos[idProd - 1]).NumUnidEmbalagem = Convert.ToInt32(txt_unidades_emb.Text);
                                ((Refeicoes)produtos[idProd - 1]).NumDiasValidade = Convert.ToInt32(txt_validade.Text);
                                
                                if(txt_tempo_prep.Text !="")
                                {
                                    ((Refeicoes)produtos[idProd - 1]).ModoPreparacao = txt_tempo_prep.Text;
                                }
                                

                                if(txt_tempo_prep.Text != "")
                                {
                                    ((Refeicoes)produtos[idProd - 1]).TempoPreparacao = Convert.ToInt32(txt_tempo_prep.Text);

                                }

                                ((Refeicoes)produtos[idProd - 1]).Gourmet = chb_gourmet.Checked;
                                
                                AdicionarProduto(produtos[idProd - 1].IdProduto);
                                lbl_n_alimentos.Text = "Nº de produtos alimentares: " + idProd;
                                LimparProduto();
                                MessageBox.Show("Produto adicionado com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("Verifique se todos os campos estão preenchidos.");
                            }

                            break;
                        default:
                            MessageBox.Show("Tem que selecionar um tipo de produto");
                            return;
                    }
                }
                else
                {
                    MessageBox.Show("Limite de Produtos ultrapassados");
                }
            }
            else
            {
                MessageBox.Show("Verifique se todos os campos estão preenchidos.");
            }
        }

        private void AdicionarProduto(int id)
        {
            if (0 <= produtos.Length)
            {
                cb_id_produto.Items.Insert(idProd - 1, idProd.ToString());
                cb_id_produto_distribuidor.Items.Insert(idProd - 1, idProd.ToString());
                cb_id_prod_edit.Items.Insert(idProd - 1, idProd.ToString());
                cb_delete.Items.Insert(idProd - 1, idProd.ToString());
            }
        }

        private void lbl_custo_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

    
        private void cb_id_produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarInformacoes();
        }

        private void LimparLabel()
        {
            lbl_nome_produto.Text = "----------------";
            lbl_custo.Text = "----------------";
            lbl_peso.Text = "----------------";
            lbl_prot.Text = "----------------";
            lbl_carbs.Text = "----------------";
            lbl_lips.Text = "----------------";
            lbl_alergenios.Text= "----------------";
            lbl_marca.Text= "----------------";
            lbl_uni_emb.Text= "----------------";
            lbl_validade.Text= "----------------";
            lbl_valor_nutri_100.Text = "----------------";
            lbl_valor_nutricional.Text= "----------------";
            lbl_margem_comer.Text= "----------------";
            lbl_preco_venda.Text= "----------------";
            lbl_saudavel.Text = "----------------";
            lbl_pais.Text = "----------------";
            lbl_bio.Text= "----------------";
        }

        private void LimparProduto()
        {
            txt_nome_produto.Text = "";
            txt_peso.Text = "";
            txt_custo.Text = "";
            txt_prot.Text = "";
            txt_carbs.Text = "";
            txt_lips.Text = "";
            chb_alergenios.Checked = false;
            chb_bio.Checked = false;
            txt_pais.Text = "";
            txt_marca.Text = "";
            txt_unidades_emb.Text = "";
            txt_validade.Text = "";
            txt_modo_prep.Text = "";
            txt_n_distribuidores.Text = "";
            txt_tempo_prep.Text = "";
            txt_nome_dist_princ.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_registar_produto_Click(object sender, EventArgs e)
        {
            if (txt_nome_distribuidor.Text != "" || txt_custo_proposto.Text != "" || cb_id_produto_distribuidor.SelectedIndex != -1)
            {
                Console.WriteLine(txt_nome_distribuidor.Text);
                if (txt_nome_distribuidor.Text == "" && txt_custo_proposto.Text == "" && cb_id_produto_distribuidor.SelectedIndex != -1)
                {
                    produtos[cb_id_produto_distribuidor.SelectedIndex].RegistarDistribuidor();
                    MessageBox.Show("Distribuidor adicionado com sucesso");
                    return;
                }
             
                if(produtos[cb_id_produto_distribuidor.SelectedIndex].RegistarDistribuidor(txt_nome_distribuidor.Text, Convert.ToDouble(txt_custo_proposto.Text)))
                {
                    MessageBox.Show("Distribuidor adicionado com sucesso");
                }
                else
                {
                    MessageBox.Show("Distribuidor não adicionado");
                }
            }
            else
            {
                MessageBox.Show("Por favor preencha os campos");
            }
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            if (cb_id_produto.SelectedIndex != -1)
            {
                MostrarInformacoes();
            }
            else
            {
                MessageBox.Show("Tem que selecionar um id de produto");
            }
        }

        private void MostrarInformacoes()
        {
            if (produtos[cb_id_produto.SelectedIndex] is ProdutoNatural)
            {
                LimparLabel();
                lbl_tipo_produto.Text = "Natural";
                lbl_nome_produto.Text = produtos[cb_id_produto.SelectedIndex].Nome;
                lbl_custo.Text = produtos[cb_id_produto.SelectedIndex].Custo.ToString();
                lbl_peso.Text = produtos[cb_id_produto.SelectedIndex].PesoUnid.ToString();
                lbl_prot.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioProteinas.ToString();
                lbl_carbs.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioCarboHidratos.ToString();
                lbl_lips.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioLipidos.ToString();
                lbl_alergenios.Text = produtos[cb_id_produto.SelectedIndex].Alergenios ? "Sim" : "Não";
                lbl_pais.Text = ((ProdutoNatural)produtos[cb_id_produto.SelectedIndex]).PaisOrigem;
                lbl_bio.Text = ((ProdutoNatural)produtos[cb_id_produto.SelectedIndex]).Biologico ? "Sim" : "Não";
                lbl_nome_distribuidor.Text = produtos[cb_id_produto.SelectedIndex].DistribuidorPrincipal;
                lbl_n_max_distribuidores.Text = produtos[cb_id_produto.SelectedIndex].NumMaximoDistribuidores.ToString();
                lbl_n_distribuidores.Text = produtos[cb_id_produto.SelectedIndex].NumDistribuidores.ToString();

                lbl_valor_nutri_100.Text = produtos[cb_id_produto.SelectedIndex].ValorNutricional100g().ToString();
                lbl_valor_nutricional.Text = produtos[cb_id_produto.SelectedIndex].ValorTotalNutricional().ToString();
                lbl_margem_comer.Text = produtos[cb_id_produto.SelectedIndex].MargemComercialização().ToString();
                lbl_preco_venda.Text = produtos[cb_id_produto.SelectedIndex].PrecoVenda().ToString();
                lbl_saudavel.Text = ((ProdutoNatural)produtos[cb_id_produto.SelectedIndex]).Saudavel() ? "Sim" : "Não";
                return;
            }

            if (produtos[cb_id_produto.SelectedIndex] is Refeicoes)
            {
                LimparLabel();
                lbl_tipo_produto.Text = "Refeições";
                lbl_nome_produto.Text = produtos[cb_id_produto.SelectedIndex].Nome;
                lbl_custo.Text = produtos[cb_id_produto.SelectedIndex].Custo.ToString();
                lbl_peso.Text = produtos[cb_id_produto.SelectedIndex].PesoUnid.ToString();
                lbl_prot.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioProteinas.ToString();
                lbl_carbs.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioCarboHidratos.ToString();
                lbl_lips.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioLipidos.ToString();
                lbl_alergenios.Text = produtos[cb_id_produto.SelectedIndex].Alergenios ? "Sim" : "Não";
                lbl_nome_distribuidor.Text = produtos[cb_id_produto.SelectedIndex].DistribuidorPrincipal;
                lbl_n_max_distribuidores.Text = produtos[cb_id_produto.SelectedIndex].NumMaximoDistribuidores.ToString();
                lbl_n_distribuidores.Text = produtos[cb_id_produto.SelectedIndex].NumDistribuidores.ToString();

                lbl_marca.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).Marca;
                lbl_uni_emb.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).NumUnidEmbalagem.ToString();
                lbl_validade.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).NumDiasValidade.ToString();

                lbl_gourmet.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).Gourmet ? "Sim" : "Não";
                lbl_modo_prep.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).ModoPreparacao;
                lbl_tempo_prep.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).TempoPreparacao.ToString();
                
                lbl_valor_nutri_100.Text = produtos[cb_id_produto.SelectedIndex].ValorNutricional100g().ToString();
                lbl_valor_nutricional.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).ValorTotalNutricional().ToString();
                lbl_margem_comer.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).MargemComercialização().ToString();
                lbl_preco_venda.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).PrecoVenda().ToString();
                lbl_saudavel.Text = ((Refeicoes)produtos[cb_id_produto.SelectedIndex]).Saudavel() ? "Sim" : "Não";
                return;
            }

            if (produtos[cb_id_produto.SelectedIndex] is ProdutosProcessados)
            {
                LimparLabel();
                lbl_tipo_produto.Text = "Processado";
                lbl_nome_produto.Text = produtos[cb_id_produto.SelectedIndex].Nome;
                lbl_custo.Text = produtos[cb_id_produto.SelectedIndex].Custo.ToString();
                lbl_peso.Text = produtos[cb_id_produto.SelectedIndex].PesoUnid.ToString();
                lbl_prot.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioProteinas.ToString();
                lbl_carbs.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioCarboHidratos.ToString();
                lbl_lips.Text = produtos[cb_id_produto.SelectedIndex].ValorMedioLipidos.ToString();
                lbl_alergenios.Text = produtos[cb_id_produto.SelectedIndex].Alergenios ? "Sim" : "Não";
                lbl_nome_distribuidor.Text = produtos[cb_id_produto.SelectedIndex].DistribuidorPrincipal;
                lbl_n_max_distribuidores.Text = produtos[cb_id_produto.SelectedIndex].NumMaximoDistribuidores.ToString();
                lbl_n_distribuidores.Text = produtos[cb_id_produto.SelectedIndex].NumDistribuidores.ToString();

                lbl_marca.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).Marca;
                lbl_uni_emb.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).NumUnidEmbalagem.ToString();
                lbl_validade.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).NumDiasValidade.ToString();

                lbl_valor_nutri_100.Text = produtos[cb_id_produto.SelectedIndex].ValorNutricional100g().ToString();
                lbl_valor_nutricional.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).ValorTotalNutricional().ToString();
                lbl_margem_comer.Text = produtos[cb_id_produto.SelectedIndex].MargemComercialização().ToString();
                lbl_preco_venda.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).PrecoVenda().ToString();
                lbl_saudavel.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).Saudavel() ? "Sim" : "Não";

                return;
            }
        }

        private void cb_funcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparProduto();
            switch (cb_funcao.SelectedIndex)
            {
                case 0:
                    
                    btn_editar.Enabled = false;
                    cb_id_prod_edit.Enabled = false;
                    btn_criar_alimento.Enabled = true;
                    break;
                case 1:
                    if (idProd != 0 )
                    {
                        btn_criar_alimento.Enabled = false;
                        btn_editar.Enabled = true;
                        cb_id_prod_edit.Enabled = true;
                        btn_criar_alimento.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Não tem nenhum alimento adicionado");
                        btn_criar_alimento.Enabled = false;
                        cb_funcao.SelectedIndex= 0;
                    }
                    
                    break;
                default:
                    btn_editar.Enabled = false;
                    cb_id_prod_edit.Enabled = false;
                    btn_criar_alimento.Enabled = false;
                    return;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (cb_id_prod_edit.SelectedIndex != -1)
            {
                switch (cb_tipo_produto.SelectedIndex)
                {
                    case 0:
                        produtos[cb_id_prod_edit.SelectedIndex] = new ProdutoNatural(cb_id_prod_edit.SelectedIndex + 1, txt_nome_produto.Text, Convert.ToInt32(txt_n_distribuidores.Text), txt_nome_dist_princ.Text);
                        GuardarEdicao();
                        ((ProdutoNatural)produtos[cb_id_prod_edit.SelectedIndex]).Biologico = chb_bio.Checked;

                        break;
                    case 1:
                        
                        produtos[cb_id_prod_edit.SelectedIndex] = new ProdutosProcessados(cb_id_prod_edit.SelectedIndex + 1, txt_nome_produto.Text, txt_marca.Text, Convert.ToInt32(txt_n_distribuidores.Text), txt_nome_dist_princ.Text);
                        GuardarEdicao();
                        ((ProdutosProcessados)produtos[cb_id_prod_edit.SelectedIndex]).NumUnidEmbalagem = Convert.ToInt32(txt_unidades_emb.Text);
                        ((ProdutosProcessados)produtos[cb_id_prod_edit.SelectedIndex]).NumDiasValidade = Convert.ToInt32(txt_validade.Text);
                        break;
                    case 2:
                        
                        produtos[cb_id_prod_edit.SelectedIndex] = new Refeicoes(cb_id_prod_edit.SelectedIndex + 1, txt_nome_produto.Text, txt_marca.Text,Convert.ToInt32(txt_n_distribuidores.Text), txt_nome_dist_princ.Text);
                        GuardarEdicao();
                        ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).NumUnidEmbalagem = Convert.ToInt32(txt_unidades_emb.Text);
                        ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).NumDiasValidade = Convert.ToInt32(txt_validade.Text);
                        ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).Gourmet = chb_gourmet.Checked;
                        ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).ModoPreparacao = txt_modo_prep.Text;
                        ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).TempoPreparacao = Convert.ToInt32(txt_tempo_prep.Text);
                        break;
                    default: return;
                }
            }
            else
            {
                MessageBox.Show("Tem que selecionar um produto.");
            }
        }

        private void cb_id_prod_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (produtos[cb_id_prod_edit.SelectedIndex] is ProdutoNatural)
            {
                EditarProdutos();
                txt_pais.Text = ((ProdutoNatural)produtos[cb_id_prod_edit.SelectedIndex]).PaisOrigem;
                chb_bio.Checked = ((ProdutoNatural)produtos[cb_id_prod_edit.SelectedIndex]).Biologico;
                
            }
            if (produtos[cb_id_prod_edit.SelectedIndex] is Refeicoes)
            {
                EditarProdutos();
                txt_marca.Text = ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).Marca;
                txt_unidades_emb.Text = ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).NumUnidEmbalagem.ToString();
                txt_validade.Text = ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).NumDiasValidade.ToString();
                chb_gourmet.Checked = ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).Gourmet;
                txt_modo_prep.Text = ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).ModoPreparacao;
                txt_tempo_prep.Text = ((Refeicoes)produtos[cb_id_prod_edit.SelectedIndex]).TempoPreparacao.ToString();
            }
            if (produtos[cb_id_prod_edit.SelectedIndex] is ProdutosProcessados)
            {
                EditarProdutos();
                txt_marca.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).Marca;
                txt_unidades_emb.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).NumUnidEmbalagem.ToString();
                txt_validade.Text = ((ProdutosProcessados)produtos[cb_id_produto.SelectedIndex]).NumDiasValidade.ToString();
            }
        }

        private void EditarProdutos()
        {
            txt_nome_produto.Text = produtos[cb_id_prod_edit.SelectedIndex].Nome;
            txt_peso.Text = produtos[cb_id_prod_edit.SelectedIndex].PesoUnid.ToString();
            txt_custo.Text = produtos[cb_id_prod_edit.SelectedIndex].Custo.ToString();
            txt_prot.Text = produtos[cb_id_prod_edit.SelectedIndex].ValorMedioProteinas.ToString();
            txt_carbs.Text = produtos[cb_id_prod_edit.SelectedIndex].ValorMedioCarboHidratos.ToString();
            txt_lips.Text = produtos[cb_id_prod_edit.SelectedIndex].ValorMedioLipidos.ToString();
            chb_alergenios.Checked = produtos[cb_id_prod_edit.SelectedIndex].Alergenios;
            txt_nome_dist_princ.Text = produtos[cb_id_prod_edit.SelectedIndex].DistribuidorPrincipal;
            txt_n_distribuidores.Text = produtos[cb_id_prod_edit.SelectedIndex].NumDistribuidores.ToString();
        }

        private void GuardarEdicao()
        {
            produtos[cb_id_prod_edit.SelectedIndex].PesoUnid = Convert.ToDouble(txt_peso.Text);
            produtos[cb_id_prod_edit.SelectedIndex].Custo = Convert.ToDouble(txt_custo.Text);
            produtos[cb_id_prod_edit.SelectedIndex].ValorMedioProteinas = Convert.ToInt32(txt_prot.Text);
            produtos[cb_id_prod_edit.SelectedIndex].ValorMedioCarboHidratos = Convert.ToInt32(txt_carbs.Text);
            produtos[cb_id_prod_edit.SelectedIndex].ValorMedioLipidos = Convert.ToInt32(txt_lips.Text);
            produtos[cb_id_prod_edit.SelectedIndex].Alergenios = chb_alergenios.Checked;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            int position = cb_delete.SelectedIndex + 1;

            for (int i = position - 1; i < idProd - 1; i++)
            {
                produtos[i] = produtos[i + 1];
            }

            cb_delete.Items.Clear();
            cb_delete.ResetText();

            cb_id_produto.Items.Clear();
            cb_id_produto.ResetText();

            cb_id_produto_distribuidor.Items.Clear();
            cb_id_produto_distribuidor.ResetText();

            cb_id_prod_edit.Items.Clear();
            cb_id_prod_edit.ResetText();
            LimparLabel();

            for (int i = 0; i < idProd - 1; i++)
            {
                cb_delete.Items.Insert(i, produtos[i].IdProduto);
                cb_id_produto.Items.Insert(i, produtos[i].IdProduto);
                cb_id_produto_distribuidor.Items.Insert(i, produtos[i].IdProduto);
                cb_id_prod_edit.Items.Insert(i, produtos[i].IdProduto);
            }
            idProd--;
          
            lbl_n_alimentos.Text = "Nº de produtos alimentares: " + idProd;

        }
    }
}
