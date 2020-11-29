using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.RolePermessionsService;
using InventoryManagement.Application.Services.RoleService;
using InventoryManagement.Application.Services.RoleService.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IRolePermessionsService RolePermessionsService;

        public RolesController(IRoleService roleService, IRolePermessionsService RolePermessionsService)
        {
            this.RolePermessionsService = RolePermessionsService;
            this.roleService = roleService;
        }

        [HttpGet]
        [Route("GetRoles")]
        public ActionResult GetRoles(DataSourceLoadOptions loadOptions)
        {
            var result = roleService.GetEntities(loadOptions, "RoleAndRolePermessions.RolePermession");
            return Ok(result);
        }

        [HttpPost]
        [Route("AddRoles")]
        public async Task<ActionResult> AddRoles([FromForm] string values)
        {
            RoleDto Entity = new RoleDto();
            JsonConvert.PopulateObject(values, Entity);
            var result = await roleService.PostEntity(Entity);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteRole")]
        public async Task<ActionResult<RoleDto>> DeleteRole([FromForm] int key)
        {
            var roleDto = await roleService.DeleteEntity(key);
            if (roleDto == null)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpGet]
        [Route("GetRolePermessions")]
        public ActionResult GetRolePermessions(DataSourceLoadOptions loadOptions)
        {
            var result = RolePermessionsService.GetEntities(loadOptions);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetUserAuthorities")]
        public ActionResult GetUserAuthorities(int RoleId, DataSourceLoadOptions loadOptions)
        {
            var result = roleService.GetRoleAuthorities(RoleId, loadOptions);
            return Ok(result);
        }


        [HttpPost]
        [Route("SaveRolePermessions")]
        public async Task<ActionResult<string>> SaveRolePermessions([FromForm] string values)
        {
            RoleIdAndPermessions RoleAndPermessionsDto = new RoleIdAndPermessions();
            JsonConvert.PopulateObject(values, RoleAndPermessionsDto);

            await roleService.SaveRolePermessions(RoleAndPermessionsDto);
            return Ok(values);
        }


    }
}
