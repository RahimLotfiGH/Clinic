using AutoMapper;
using Clinic.Application.Contracts;
using Clinic.Application.DTOs;
using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clinic.WebApi.Controllers
{
    [Route("api/appuser")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AppUserController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repository.AppUser.GetAllAppUsers();
                var usersResult = _mapper.Map<IEnumerable<AppUserDto>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

        [HttpGet("{id:long}", Name = "UserById")]
        public IActionResult GetUserById(long id)
        {
            try
            {
                var user = _repository.AppUser.GetAppUserById(id);
                if (user == null) return NotFound();

                var userResult = _mapper.Map<AppUserDto>(user);
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}.");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] AppUserForCreationDto appUserForCreationDto)
        {
            try
            {
                if (appUserForCreationDto == null) return BadRequest("AppUser object is null.");
                if (!ModelState.IsValid) return BadRequest("Invalid model object.");

                var appUserEntity = _mapper.Map<AppUser>(appUserForCreationDto);

                _repository.AppUser.CreateAppUser(appUserEntity);
                _repository.Save();

                var createdAppUser = _mapper.Map<AppUserDto>(appUserEntity);

                return CreatedAtRoute("UserById", new { id = createdAppUser.Id }, createdAppUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}.");
            }
        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateUser(long id, [FromBody] AppUserForUpdateDto appUserForUpdateDto)
        {
            try
            {
                if (appUserForUpdateDto == null) return BadRequest("AppUser object is null.");
                if (!ModelState.IsValid) return BadRequest("Invalid model object.");

                var appUserEntity = _repository.AppUser.GetAppUserById(id);
                if (appUserEntity == null) return NotFound();

                _mapper.Map(appUserForUpdateDto, appUserEntity);

                _repository.AppUser.UpdateAppUser(appUserEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}.");
            }
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteUser(long id)
        {
            try
            {
                var appUser = _repository.AppUser.GetAppUserById(id);
                if (appUser == null) return NotFound();

                _repository.AppUser.DeleteAppUser(appUser);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}.");
            }
        }
    }
}
