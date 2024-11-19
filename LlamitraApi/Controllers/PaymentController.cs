using System;
using System.Threading.Tasks;
using LlamitraApi.Models;
using Microsoft.AspNetCore.Mvc;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;

namespace LlamitraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ProyectoIContext _context;

        public PaymentController(ProyectoIContext context, IConfiguration configuration)
        {
            _context = context;
            MercadoPagoConfig.AccessToken = configuration["MercadoPago:AccessToken"];
        }

        [HttpPost("create-preference/{idPublication}")]
        public async Task<IActionResult> CreatePreference(int idPublication)
        {
            var publication = await _context.Publications.FindAsync(idPublication);
            if (publication == null)
            {
                return NotFound("Publicación no encontrada.");
            }

            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = publication.Title,
                        Description = publication.Description,
                        Quantity = 1,
                        CurrencyId = "ARS",
                        UnitPrice = publication.Price
                    }
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://localhost:4200/main/product/view",
                    Failure = "http://localhost:4200/main/product/view",
                    Pending = "http://localhost:4200/main/product/view"
                },
                AutoReturn = "approved",
                NotificationUrl = "http://localhost:4200/main/product/view"
            };

            try
            {
                Preference preference = await new PreferenceClient().CreateAsync(request);
                return Ok(new { PreferenceId = preference.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la preferencia: {ex.Message}");
            }
        }
    }
}
