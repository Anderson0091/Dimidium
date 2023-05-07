using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dimidium.my_peges
{
    public class pg1 : PageModel
    {
        private readonly ILogger<pg1> _logger;

        public pg1(ILogger<pg1> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}