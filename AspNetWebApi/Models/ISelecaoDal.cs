using System.Collections.Generic;

namespace AspNetWebApi.Models
{
    public interface ISelecaoDal
    {
        IEnumerable<Selecao> ObterSelecoes();
        int IncluirSelecao(Selecao selecao);
        int AtualizarSelecao(Selecao selecao);
        Selecao ObeterSelecaoPorId(int id);
        int ExcluirSelecao(int id);
    }
}
