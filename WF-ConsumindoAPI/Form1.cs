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

        #endregion

        #region Util

        private void LimparDGV()
        {
            for(int i =0; i < dgvDados.RowCount; i++)
            {
                dgvDados.Rows[i].DataGridView.Columns.Clear();
            }
            dgvDados.Refresh();
        }
        
        #endregion
    }
}
