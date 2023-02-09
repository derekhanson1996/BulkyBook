using BulkyBook.Data;
using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();  //Gets all records from Product table

            return View(objProductList);
        }

        ////GET
        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Product obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Add(obj);    //Adds Product to table if valid
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product created successfully";

        //        return RedirectToAction("Index");
        //    }

        //    return View(obj);
        //}

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);   //Finds Product with that id

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);    //Updates Product on table if valid
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);   //Finds Product with that id

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product obj)
        {
            _unitOfWork.Product.Remove(obj);    //Deletes Product on table if valid
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
