using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_ConsumindoAPI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Url da api 
        /// </summary>
        string URI = "http://localhost:5000/api/Selecao";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUId.Enabled = false;
            GetAllSelecao();
        }
  
        #region Metodos consumindo a API

        /// <summary>
        /// Retorna todos as selecoes cadastradas
        /// </summary>
        private async void GetAllSelecao()
        {
           using (var selecao = new HttpClient())
            {
                using (var response = await selecao.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var selecaoJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<Selecao[]>(selecaoJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show($"Não é possivel obter a seleções: {response.StatusCode}");
                    }
                }

            }
        }

        /// <summary>
        /// Retorna apenas uma seleção na qual o id passado pertence
        /// </summary>
        /// <param name="id"></param>
        private async void GetSelecaoById(int id)
        {
            using (var selecaoPorId = new HttpClient())
            {
                BindingSource bsDados = new BindingSource();
                URI += "/" + Convert.ToInt32(txtBuscar.Text) + "/" + "obterselecaoporid";
                HttpResponseMessage response = await selecaoPorId.GetAsync(URI);
                if (response.IsSuccessStatusCode)
                {
                    var selecaoJsonString = await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<Selecao>(selecaoJsonString);
                    dgvDados.DataSource = bsDados;
                }
                else
                {
                    MessageBox.Show($"Falha ao obter selecao: {response.StatusCode}");
                }
            }
        }

        /// <summary>
        /// Cadastra uma nova seleão
        /// </summary>
        private async void AddSelecao()
        {
            URI += "/criarselecao";
            Selecao toSelecao = new Selecao()
            {
                NomeSelecao = txtNomeSelecao.Text,
                Continente = txtContinente.Text,
                NumeroParticipacoes = Convert.ToInt32(txtNumeroParticipacoes.Text),
                MelhorResultado = txtMelhoreResultado.Text
            };
            using (var selecao =  new HttpClient())
            {
                var serializeSelecao = JsonConvert.SerializeObject(toSelecao);
                var content = new StringContent(serializeSelecao, Encoding.UTF8, "application/json");
                var result = await selecao.PostAsync(URI, content);
            }
            GetAllSelecao();
        }

        /// <summary>
        /// Atualiza a seleção passando o objeto preenchido.
        /// </summary>
        /// <param name="toSelecao"></param>
        private async void UpdateSelecao(Selecao toSelecao)
        {
            //URI += "/atualizarselecao";
           using (var selecao =  new HttpClient())
            {
                HttpResponseMessage responseMessage = await selecao.PutAsJsonAsync(URI  +"/atualizarselecao/", toSelecao);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Seleção atuaizada com sucesso:");
                }
                else
                {
                    MessageBox.Show("Falha ao tentar atualizar a selecao:" + responseMessage.StatusCode);
                }
            }
            GetAllSelecao();
        }

        /// <summary>
        /// Deletar uma seleção passando o valor do id da seleção desejada
        /// </summary>
        /// <param name="id"></param>
        private async void DeleteSelecao(int id)
        {
            URI += "/" + txtDeletarPorId.Text+ "/excluirselecao";
            using (var selecao =  new HttpClient())
            {
                selecao.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await selecao.DeleteAsync(URI);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Seleção excluido com sucesso:");
                }
                else
                {
                    MessageBox.Show("Falha ao tentar excluir a seleção:" + responseMessage.StatusCode);
                }
            }
            GetAllSelecao();
        }

        #endregion

        #region Botoes

        private void btnBuscarPorId_Click(object sender, EventArgs e)
        {
            GetSelecaoById(Convert.ToInt32(txtBuscar.Text));
        }
        private void btnCarregarGrid_Click(object sender, EventArgs e)
        {
            GetAllSelecao();
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            AddSelecao();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DeleteSelecao(Convert.ToInt32(txtDeletarPorId.Text));
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Selecao toSelecao = new Selecao();

            toSelecao.Id = Convert.ToInt32(txtUId.Text);
            toSelecao.NomeSelecao = txtUNomeSelecao.Text;
            toSelecao.Continente = txtUContinente.Text;
            toSelecao.NumeroParticipacoes = Convert.ToInt32(txtUNumeroParticipacoes.Text);
            toSelecao.MelhorResultado = txtUMelhorResultado.Text;

            UpdateSelecao(toSelecao);
        }

        #endregion

        #region Util
        //TODO: Melhorar o limpar DataGrid ao efetuar alguma alteração nos registros, atualizando os dados do grid
        private void LimparDGV()
        {
            dgvDados.DataSource = null;
        }

        /// <summary>
        /// Atribui nos textbox os valores da linha selecionda 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
            {
                return;
            }

            DataGridViewRow linha = dgvDados.Rows[_linhaIndice];

            //exibe os valores no textbox
            txtUId.Text = linha.Cells[0].Value.ToString();
            txtUNomeSelecao.Text = linha.Cells[1].Value.ToString();
            txtUContinente.Text = linha.Cells[2].Value.ToString();
            txtUNumeroParticipacoes.Text = linha.Cells[3].Value.ToString();
            txtUMelhorResultado.Text = linha.Cells[4].Value.ToString();


        }

        #endregion


    }
}
