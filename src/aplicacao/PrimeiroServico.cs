using dominio;
using repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao;

public class PrimeiroServico
{
    readonly IRepositorioDeEquipamento _repositorioDeEquipamento;
    public PrimeiroServico(IRepositorioDeEquipamento repositorioDeEquipamento)
    {
        _repositorioDeEquipamento = repositorioDeEquipamento;
    }

    public async Task<Equipamento> Obter(int? codigo)
    {
        await _repositorioDeEquipamento.Salvar(codigo, $"novo serviço {codigo}");
        return await _repositorioDeEquipamento.Obter(codigo);
    }
}
