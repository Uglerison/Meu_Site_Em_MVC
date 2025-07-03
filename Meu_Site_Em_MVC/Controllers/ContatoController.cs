using Meu_Site_Em_MVC.Models;
using Meu_Site_Em_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meu_Site_Em_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ContactInterface _ContactRepository;
        public ContatoController(ContactInterface ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contatos = _ContactRepository.BuscarTodos();
            
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _ContactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult EraseConfirmation(int id)
        {
            ContactModel contact = _ContactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Erase(int id)
        {
            _ContactRepository.Erase(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(ContactModel contact)
        {
            _ContactRepository.Adicionar(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            _ContactRepository.Atualizar(contact);
            return RedirectToAction("Index");
        }

    }
}
