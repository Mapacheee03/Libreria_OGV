using Libreria_OGV.Data.Services;
using Libreria_OGV.Data.ViewModels;
using Libreria_OGV.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Libreria_OGV.Controllers
{
    public class PublishersController : Controller
    {
        private PublisherService _publisherService;
        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpPost("Add-publisher")]
        public IActionResult Addpublisher([FromBody] PublisherVM author)
        {
            try
            {
                var newPublisher = _publisherService.AddAuthor(author);
                return Created(nameof(Addpublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la editorial: {ex.PublisherNamer}");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}