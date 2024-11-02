using CompStore.Context;
using CompStore.DTO.ComputerDTO;
using CompStore.Entities;
using CompStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompStore.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;
        private readonly IDetailService _detailService;

        public ComputerController(IComputerService computerService,IDetailService detailService)
        {
            _computerService = computerService;
            _detailService = detailService;
        }
        [HttpGet]
        public IActionResult ComputerList()
        {
            
            ComputerListDTO dto=new ComputerListDTO();
            dto.ComputerList =_computerService.GetAllComputers();

            return View(dto);

        }
        [HttpGet]
        public IActionResult ActiveComputerList()
        {
            ComputerListDTO dto = new ComputerListDTO();
            dto.ComputerList = _computerService.GetActiveComputers();

            return View(dto);

        }
        [HttpGet]
        public IActionResult DeactiveComputerList()
        {
              ComputerListDTO dto=new ComputerListDTO();
            dto.ComputerList =_computerService.GetDeactiveComputer();

            return View(dto);

        }
        [HttpGet]
        
        public IActionResult Create()
        {
            AddComputerDTO dto=new AddComputerDTO();
            dto.SizeList = _detailService.SizeList();
            return View(dto);
        }
        [HttpPost]
        public IActionResult Create(AddComputerDTO dto)
        {
            dto.SizeList = _detailService.SizeList();
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("InStock","Please add count!");
            //    ModelState.AddModelError("ModelName", "Please add ModelName!");
            //    ModelState.AddModelError("MarkName", "Please add MarkName!");
            //    ModelState.AddModelError("Price", "Please add Price!");
            //    ModelState.AddModelError("DetailId", "Please select size from list!");

            //    return View(dto);
            //}
            Computer computer = new Computer();
            computer.InStock=dto.InStock;
            computer.MarkName = dto.MarkName;
            computer.Price=dto.Price;
            computer.DetailId = dto.DetailId; 
            computer.ModelName= dto.ModelName;  
            _computerService.Create(computer);
            return RedirectToAction("ComputerList");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
         Computer computer=_computerService.GetById(Id);
           
            _computerService.Delete(computer);
            
            return RedirectToAction("ComputerList");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            if (Id==null)
            {
                return NotFound();
            }
            Computer computer = _computerService.GetById(Id);
            UpdateComputerDTO dto= new UpdateComputerDTO();
            dto.SizeList= _detailService.SizeList();
            dto.DetailId=computer.DetailId;
            dto.MarkName=computer.MarkName;
            dto.ModelName= computer.ModelName;
            dto.InStock=computer.InStock;
            dto.Price=computer.Price;
            dto.Id=computer.Id;
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(UpdateComputerDTO dto) {

            dto.SizeList = _detailService.SizeList();
            Computer computer = _computerService.GetById(dto.Id);
            computer.InStock=dto.InStock;
            computer.Price=dto.Price;
            computer.DetailId=dto.DetailId;
            computer.ModelName=dto.ModelName;
            computer.MarkName=dto.MarkName;
          
            _computerService.Update(computer);
            return RedirectToAction("ComputerList");
        }
        [HttpGet]
        public IActionResult Detail(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Computer computer = _computerService.GetById(Id);
            ReadComputerDTO dto = new ReadComputerDTO();
            dto.SizeList = _detailService.SizeList();
            dto.DetailId = computer.DetailId;
            dto.MarkName = computer.MarkName;
            dto.ModelName = computer.ModelName;
            dto.InStock = computer.InStock;
            dto.Price = computer.Price;
            
            return View(dto);
            
        }





    }
}
