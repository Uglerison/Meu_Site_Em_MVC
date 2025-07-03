using Meu_Site_Em_MVC.Models;

namespace Meu_Site_Em_MVC.Repositories
{
    public interface ContactInterface
    {
        ContactModel ListById (int id);
        List<ContactModel> BuscarTodos();
        ContactModel Adicionar(ContactModel contact);
        ContactModel Atualizar(ContactModel contact);
        bool Erase(int id);
    }
}
