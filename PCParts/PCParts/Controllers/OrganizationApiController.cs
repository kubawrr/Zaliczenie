using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using PCParts.Mappers;
using PCParts.Models;
using System.Collections.Specialized;
using System.Net.WebSockets;

namespace PCParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFiltered(string filter)
        {
            
            var result = _context.Organizations
            .Where(o => o.Title.StartsWith(filter))
                .Select(o => new { o.Title, o.Id })
                    .ToList();
            return Ok(result);
        }
        [Route("computer")]
        [HttpGet]
        public IActionResult GetComputersByCountry(string country)
        {
            var options = new CookieOptions
            {
                Path = "/api/organizationapi/computer",
                Expires = DateTimeOffset.UtcNow.AddMinutes(5)
            };

            if (Request.Cookies["Important"] is not null)
            {
                var c = Request.Cookies["Important"];
                var nameV = System.Web.HttpUtility.ParseQueryString(c);
                var x = nameV.AllKeys.FirstOrDefault(x => x == "SessionId");
                return Ok(nameV[x]);
            }

            var cookieValues = new NameValueCollection()
            {
                {"SessionId", "12345" },
                {"ddasd", "sadasd" }
            };

            var querystring = String.Join("&", cookieValues.AllKeys.Select(x => $"{x}={cookieValues[x]}"));

            Response.Cookies.Append("Important", querystring);

            var countryId = _context.ShippingCountries
                .FirstOrDefault(x => x.CountryName == country);
            var getComputersId = _context.ComputerShippingCountries
                .Where(x => x.ShippingId == countryId.Id)
                    .Select(x => x.ComputerId)
                        .ToList();
            var computers = new List<Computer>();
            foreach (var id in getComputersId)
            {
                computers.Add(ComputerMapper.FromEntity(_context.Computers.SingleOrDefault(x => x.Id == id)));
            }
            return Ok(computers);
        }
    }
}
