using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models.Domain;
using ProductsAPI.Models.DTO;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ProductDbContext dbContext;
        public SupplierController(ProductDbContext productDbContext)
        {
            dbContext = productDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var suppliers = dbContext.suppliers.ToList();

            var suppliersDTO = new List<SupplierDTO>();

            foreach (var supplier in suppliers)
            {
                suppliersDTO.Add(
                    new SupplierDTO()
                    {
                        Id = supplier.Id,
                        Name = supplier.Name,
                        Address = supplier.Address,
                        ContactNo = supplier.ContactNo,
                        Image = supplier.Image
                    }

                );
            }

            return Ok(suppliersDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var supplier = dbContext.suppliers.Find(id);
            var suppliersDTO = new SupplierDTO
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                ContactNo = supplier.ContactNo,
                Image = supplier.Image
            };

            return Ok(suppliersDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddSupplierDTO addSupplierDTO)
        {
            //dto--domainmodel
            var supplierDomainModel = new Supplier
            {
                Name = addSupplierDTO.Name,
                Address = addSupplierDTO.Address,
                Image = addSupplierDTO.Image,
                ContactNo = addSupplierDTO.ContactNo,

            };

            dbContext.suppliers.Add( supplierDomainModel );
            dbContext.SaveChanges();

            //map domain model back to dto
            var supplierDTO = new SupplierDTO
            {
                Id = supplierDomainModel.Id,
                Name = supplierDomainModel.Name,
                Address = supplierDomainModel.Address,
                Image = supplierDomainModel.Image,
                ContactNo = supplierDomainModel.ContactNo
            };

            return CreatedAtAction(nameof(GetById),new {id=supplierDTO.Id},supplierDTO);
        }


    }
}


