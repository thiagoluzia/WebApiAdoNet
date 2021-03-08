using AspNetWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Selecao")]
    public class SelecaoController : Controller
    {
        /// <summary>
        /// Injeção de dependencias - Com _selecaoDal  do tipo ISelecaoDal, e o construtor que recebe um paramtrp do tipo  ISelecaoDal, atribuimos a _selecaoDal o parametro selecaoDal fazendo com que _selecaoDal implemete os metodos da interface ISelecaoDal 
        /// </summary>
        private readonly ISelecaoDal _selecaoDal;
        public SelecaoController(ISelecaoDal selecaoDal)
        {
            _selecaoDal = selecaoDal;
        }

        /// <summary>
        /// A primeira Action é a Get, ela utiliza o método obterselecoes, e em seguida retorna um OK que é um status code que significa que foi tudo OK. com a consulta, é muito importante você retornar os verbos corretos para as respectivas chamadas na API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _selecaoDal.ObterSelecoes();
            return Ok(result);
        }

        /// <summary>
        /// A segunda Action é a Create, inicialmente decoramos com HttpPost informando que esta Action é um post, em seguida criamos uma rota chamada criarselecao, com isso facilitamos a chamada da action
        /// </summary>
        /// <param name="selecao"></param>
        /// <returns></returns>
        [HttpPost, Route("criarselecao")]
        public IActionResult Create([FromBody] Selecao selecao)
        {
            if (selecao == null)
                return BadRequest();

            var status = _selecaoDal.IncluirSelecao(selecao);

            if (status != 1)
                return StatusCode(500, "Erro ao incluir a seleção");

            return Ok();
        }

        /// <summary>
        /// A próxima Action é Obter Selecao por Id, recebemos como parâmetro o id da seleção e retornamos um OK com o respectivo objeto, alguns detalhes que não podem ficar despercebidos nesta Action, perceba que caso uma seleção não seja encontrado será retornado o verto NotFound, que tem o código 404, ou seja não é um erro, e sim um status informando que o busca não foi encontrada e outro detalhe que deve perceber é a rota, alteramos para receber como parâmetro o id e mudamos o nome de Get para obterselecaoporid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/obterselecaoporid")]
        public IActionResult Get(int id)
        {
            var selecao = _selecaoDal.ObeterSelecaoPorId(id);

            if (selecao == null)
                return NotFound();

            return Ok(selecao);
        }

        /// <summary>
        /// Em seguida vamos criar a Action que atualiza uma seleção. Perceba o atributo [FromBody] quando vamos receber como parâmetro uma Selecao é necessário informa-lo pois estamos recebendo como argundo um tipo complexo, para um tipo simples como int, string não é necessário. Caso ocorro um erro ao atualizar utilizamos StatusCode com o código 500 e por fim um novo verbo que é padrão para o put, que é NoContent que retorna o código 204
        /// </summary>
        /// <param name="selecao"></param>
        /// <returns></returns>
        [HttpPut, Route("atualizarselecao")]
        public IActionResult Put([FromBody] Selecao selecao)
        {
            if (selecao == null)
                return BadRequest();

            var status = _selecaoDal.AtualizarSelecao(selecao);

            if (status != 1)
                StatusCode(500, "Erro ao atualizar a seleção");

            return NoContent();
        }

        /// <summary>
        ///  Por fim vamos realizar a exclusão da seleção, repare no atributo HttpDelete e na rota, excluir seleção, o statuscode 500 também é utilizado e NoContent caso tudo ocorra como o esperado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}/excluirselecao")]
        public IActionResult Delete(int id)
        {
            var status = _selecaoDal.ExcluirSelecao(id);

            if (status != 1)
                return StatusCode(500, "Erro ao excluir a seleção");

            return NoContent();
        }
    }
}
