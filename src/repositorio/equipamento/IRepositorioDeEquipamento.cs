using dominio;

namespace repositorio;

public interface IRepositorioDeEquipamento
{
    Task<Equipamento> Obter(int? codigo);
    Task Salvar(int? codigo, string nome);
}
