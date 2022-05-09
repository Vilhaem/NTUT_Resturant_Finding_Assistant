using System;
using System.Threading.Tasks;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    public class ResturantController : BaseApiController
    {
         private readonly ILoggerService _logger;
        private readonly IResturantCache _resturantCache;
        private readonly IUnitOfWork _unitOfWork;

        public ResturantController(ILoggerService logger, IResturantCache resturantCache, 
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _resturantCache = resturantCache;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All Authors as a list of JSON response
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResturants(string search)
        {
            var location = GetControllerActionNames();

            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    _logger.LogInformation($"{location}: Attempting to get all Resturant records...");

                    var resturants = await _unitOfWork.ResturantRepository.FindAll();

                    _logger.LogInformation($"{location}: Successfully got all Resturant records");

                    return Ok(resturants);
                }
                else
                {
                    _logger.LogInformation($"{location}: Attempting to get Resturants with search parameter of: { search }");

                    var searchResturant = await _unitOfWork.ResturantRepository.FindBySearch(search);

                    _logger.LogInformation($"{location}: Successfully returned Resturants with search parameter of: { search }");

                    return Ok(searchResturant);
                }
            }
            catch (Exception ex)
            {
                return InternalError($"{location}: {ex.Message} - {ex.InnerException}");
            }
            
        }

        /// <summary>
        /// Get a Single Author with a specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResturantById(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                _logger.LogInformation($"{location}: Attempting to get a single record with id:{id}");

                var resturant = _resturantCache.Get(id);

                if (resturant == null)
                {
                    resturant = await _unitOfWork.ResturantRepository.FindById(id);

                    if (resturant == null)
                    {
                        _logger.LogWarning($"{location}: Record with id:{id} was not found");

                        return NotFound();
                    }

                    _resturantCache.Set(resturant);
                }

                _logger.LogInformation($"{location}: Successfully retrieved the Resturant with id:{id}");

                return Ok(resturant);
            }
            catch (Exception ex)
            {
                return InternalError($"{location}: {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Create an Resturant
        /// </summary>
        /// <param name="resturant"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateResturant([FromBody] Resturant resturant)
        {
            var location = GetControllerActionNames();

            try
            {
                _logger.LogInformation($"{location}: Attempting to submit a single record");

                if(resturant == null)
                {
                    _logger.LogWarning($"{location}: Empty request was submitted");

                    return BadRequest(ModelState);
                }

                if(!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was incomplete");

                    return BadRequest(ModelState);
                }

                var isSuccess = await _unitOfWork.ResturantRepository.Create(resturant);

                if (!isSuccess)
                {
                    return InternalError($"{location}: Record creation failed");
                }

                _logger.LogInformation($"Successfully submitted an Resturant object as: {resturant}");

                return Created("CreateResturant", new { resturant });
            }
            catch (Exception ex)
            {
                return InternalError($"{location}: {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Update An Resturant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resturantToUpdate"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateResturant(int id, [FromBody] Resturant resturantToUpdate)
        {
            var location = GetControllerActionNames();

            try
            {
                _logger.LogInformation($"Resturant update attempted - id: {id}");

                if(id < 1 || resturantToUpdate == null || id != resturantToUpdate.Id)
                {
                    _logger.LogWarning($"{location}: Record update failed with invalid data");

                    return BadRequest();
                }

                var ifExists = await _unitOfWork.ResturantRepository.IsExists(id);

                if (ifExists == false)
                {
                    _logger.LogWarning($"{location}: Record with id: {id} was not found");

                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var isSuccess = await _unitOfWork.ResturantRepository.Update(resturantToUpdate);

                if (!isSuccess)
                {
                    return InternalError($"{location}: Update operation failed");
                }

                _resturantCache.Remove(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalError($"{location}: {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Delete An Resturant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteResturant(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                _logger.LogInformation($"Resturant deletion attempted with record id: {id}");

                if(id < 1)
                {
                    _logger.LogWarning($"{location}: Record deletion failed with invalid data");

                    return BadRequest();
                }

                var resturant = await _unitOfWork.ResturantRepository.FindById(id);

                if (resturant == null)
                {
                    _logger.LogWarning($"{location}: Record with id: {id} was not found");

                    return NotFound();
                }

                 var isSuccess = await _unitOfWork.ResturantRepository.Delete(resturant);

                if (!isSuccess)
                {
                    return InternalError($"{location}: Delete operation failed");
                }

                _resturantCache.Remove(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalError($"{location}: { ex.Message} - { ex.InnerException}");
            }
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);

            return StatusCode(500, "Something went wrong. Please contact the Administrator."); 
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;

            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }
    }
}