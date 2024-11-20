using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetAcademy.Models;

namespace PetAcademy.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()
        {
            return View();
        }


        public static List<Pet> CreateSamplePets()
        {
            var pets = new List<Pet>
        {
            new Pet("Балкан", "Куче", "Пинчер", "Първото куче, с което сме работили.", "balkan.jpg"),
            new Pet("Пешо", "Хамстер", "Сирийски Хамстер", "Първият хамстер, с което сме работили.", "Pesho.jpg"),
            new Pet("Пухчо", "Заек", "Holland Lop", "Първият заек, с което сме работили.", "puhcho.jpg")
        };

            return pets;
        }
    }
}