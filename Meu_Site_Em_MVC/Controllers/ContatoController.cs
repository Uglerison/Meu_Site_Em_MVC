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
            try
            {
                _ContactRepository.Erase(id);
                TempData["msgSuccess"] = "Cadastro excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

                TempData["msgError"] = $"Não foi possível excluir o cadastro: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Criar(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ContactRepository.Adicionar(contact);
                    TempData["msgSuccess"] = "Cadastro criado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contact);

            }
            catch (Exception error)
            {

                TempData["msgError"] = $"Não foi possível realizar o cadastro: {error.Message}";
                return RedirectToAction("Index");

            }
            
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ContactRepository.Atualizar(contact);
                    TempData["msgSuccess"] = "Cadastro editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Edit", contact);
            }
            catch (Exception error)
            {

                TempData["msgError"] = $"Não foi possível Editar o cadastro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
