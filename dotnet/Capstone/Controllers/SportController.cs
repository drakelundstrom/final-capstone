using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportController : Controller
    {
        private readonly ISportDAO sportDAO;

        public SportController(ISportDAO _sportDAO)
        {
            sportDAO = _sportDAO;
        }
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult<List<Sport>> GetAllSports()
        {
            List<Sport> sports = sportDAO.GetSports();
            if (sports.Count != 0)
            {
                return Ok(sports);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
