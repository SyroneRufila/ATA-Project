using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackingApp.Data;
using TrackingApp.Models.Domain;


namespace TrackingApp.Pages.Clients
{
    public class StatModel : PageModel
    {
        private readonly TrackingAppDbContext dbContext;

        public StatModel(TrackingAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public string Trackingnumber { get; set; }

        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(string trackingNumber)
        {
            if (!string.IsNullOrEmpty(trackingNumber))
            {
                Client = await dbContext.Clients.FirstOrDefaultAsync(c => c.trackingnumber == trackingNumber);
            }
            else
            {
                Client = null;
            }

            return Page();
        }

    }
}
