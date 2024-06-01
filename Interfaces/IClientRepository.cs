namespace Zadanie7.Interfaces;

public interface IClientRepository
{
    public Task DeleteClientAsync(int idClient);
}