using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;

using webapi.Dtos;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public PropertyController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper
        }

        //property/add
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDto dto)
        {
            var property = mapper.Map<Property>(dto);

            var userId = GetUserId();

            property.PostedBy = userId;
            property.LastUpdatedBy = userId;

            uow.PropertyRepository.AddProperty(property);

            await uow.SaveAsync();

            return StatusCode(201);
        }
    }
}