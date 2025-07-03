using Meu_Site_Em_MVC.Data;
using Meu_Site_Em_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Meu_Site_Em_MVC.Repositories
{
    public class ContactRepository : ContactInterface
    {
        private readonly BancoContext _Context;
        public ContactRepository(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }   

        public ContactModel ListById(int id)
        {
            _Context.ChangeTracker.Clear();
            return _Context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> BuscarTodos()
        {
            return _Context.Contatos.ToList();
        }

        public ContactModel Adicionar(ContactModel contact)
        {
            _Context.Contatos.Add(contact);
            _Context.SaveChanges();

            return contact;
        }

        public ContactModel Atualizar(ContactModel contact)
        {
            ContactModel contatoDb = ListById(contact.Id);

            if (contatoDb == null) throw new SystemException("Houve um erro ao atualizar o contato!");

            contatoDb.Name = contact.Name;
            contatoDb.Email = contact.Email;
            contatoDb.Phone = contact.Phone;

            _Context.Contatos.Update(contatoDb);
            _Context.SaveChanges();

            return contatoDb;
        }

        bool ContactInterface.Erase(int id)
        {
            ContactModel contatoDb = ListById(id);

            if (contatoDb == null) throw new SystemException("Houve um erro ao deletar o contato!");

            _Context.Contatos.Remove(contatoDb);
            _Context.SaveChanges();
            return true;
        }
    }
}
