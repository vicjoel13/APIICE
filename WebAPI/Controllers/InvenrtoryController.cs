using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DataModels.RoleSystem;
using Repository;
using Services;
using Services.DTOs;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private IRepository<Inventory> InventoryRepository;
        private readonly ICSVService _csvService;
        private ApplicationDbContext _Context;
        public InventoryController(IRepository<Inventory> Invetory, ICSVService csvService, ApplicationDbContext appDB)
        {
            this.InventoryRepository = Invetory;
            _csvService = csvService;
            _Context = appDB;
        }

        /// <summary>
        /// Get a list of all inventory entries
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var ListProducts = InventoryRepository.GetAll().ToList();

            return Ok(ListProducts);
        }
        /// <summary>
        /// Create a new inventory entry
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateInventory(Inventory inventory)
        {

            var ListProducts = InventoryRepository.Insert(inventory);

            return Created("Inventory entry created successfully", new { Message = "Inventory entry created successfully" });
        }
        /// <summary>
        /// Update an existing inventory entry by ID
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateanEntry(Inventory inventory)
        {

            InventoryRepository.Update(inventory);

            return Created("Inventory entry updated successfully", new { Message = "Inventory entry Updated successfully" });
        }
        /// <summary>
        /// Upload inventory entries from a CSV file
        /// </summary>
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadCsv([FromForm] IFormFileCollection file)
        {
            try
            {
                var inventories = _csvService.ReadCSV<InventoryCsv>(file[0].OpenReadStream());

                foreach (var item in inventories)
                {
                    if (!String.IsNullOrEmpty(item.Store))
                    {
                        var inventory = new Inventory();
                        inventory.quantity = Int32.Parse(item.Quantity);
                        inventory.Date = DateTime.Parse(item.Date).ToUniversalTime(); ;
                        inventory.ModifiedDate = DateTime.Now.ToUniversalTime();
                        inventory.Flavor = item.Flavor;
                        inventory.is_season_flavor = item.Is_Season == "Yes" ? true : false;

                        var tienda = await _Context.Store.Where(x => x.Name.Equals(item.Store)).FirstOrDefaultAsync();

                        if (tienda == null)
                        {
                            var store = new Store();
                            store.Name = item.Store;
                            store.AddedDate = DateTime.Now.ToUniversalTime(); ;
                            store.ModifiedDate = DateTime.Now.ToUniversalTime(); ;
                            await _Context.Store.AddAsync(store);
                            await _Context.SaveChangesAsync();
                            inventory.store_id = store.Id;
                        }
                        else
                        {
                            inventory.store_id = tienda.Id;
                        }
                        var Empleado = await _Context.Empleados.Where(x => x.Name.Equals(item.Listed_By)).FirstOrDefaultAsync();
                        if (Empleado == null)
                        {
                            var EmpleadoEntry = new Employee();
                            EmpleadoEntry.Name = item.Listed_By;
                            EmpleadoEntry.AddedDate = DateTime.Now.ToUniversalTime(); ;
                            EmpleadoEntry.ModifiedDate = DateTime.Now.ToUniversalTime(); ;
                            await _Context.Empleados.AddAsync(EmpleadoEntry);
                            await _Context.SaveChangesAsync();
                            inventory.employee_id = EmpleadoEntry.Id;
                        }
                        else
                        {
                            inventory.employee_id = Empleado.Id;
                        }

                        await _Context.Inventario.AddAsync(inventory);
                        await _Context.SaveChangesAsync();

                    }
                }



                return Created("Inventory entries uploaded successfully", new { Message = "Inventory entries uploaded successfully" });
            }
            catch (Exception e)
            {

                throw;
            }

        }


        /// <summary>
        /// Get details of a specific inventory entry by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInventory(int id)
        {

            var item = InventoryRepository.Get(id);
            if (item == null) return NotFound();

            return Ok(item);

        }
        /// <summary>
        /// Get details of a specific inventory entry by ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventory(int id)
        {

            var item = InventoryRepository.Get(id);
            if (item == null) return NotFound();

            InventoryRepository.HardDelete(item);   

            return NoContent();
        }
    }
}
