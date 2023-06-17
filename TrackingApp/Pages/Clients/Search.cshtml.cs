using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackingApp.Data;
using TrackingApp.Models.Domain;
using TrackingApp.Models.ViewModels;


namespace TrackingApp.Pages.Clients
{
    public class SearchModel : PageModel
    {
        private readonly TrackingAppDbContext dbContext;

        public SearchModel(TrackingAppDbContext dbContext)
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

        [BindProperty]
        public AddClientViewModel AddClientRequest { get; set; }

        [HttpPost]
        public IActionResult OnPost()
        {

            var recordsRequested = "";

            if (AddClientRequest.Transcript)
            {
                recordsRequested += "Transcript ";
            }
            if (AddClientRequest.Diploma)
            {
                recordsRequested += "Diploma ";
            }
            if (AddClientRequest.Form137)
            {
                recordsRequested += "Form 137 ";
            }
            if (AddClientRequest.Certification)
            {
                recordsRequested += "Certification ";
            }

            var clientDomainModel = new Client
            {
                lastname = AddClientRequest.lastname,
                firstname = AddClientRequest.firstname,
                middlename = AddClientRequest.middlename,
                suffixname = AddClientRequest.suffixname,
                graduate = AddClientRequest.graduate,
                yeargraduated = AddClientRequest.yeargraduated,
                email = AddClientRequest.email,
                mobilenumber = AddClientRequest.mobilenumber,
                studentnumber = AddClientRequest.studentnumber,
                program = AddClientRequest.program,
                employment = AddClientRequest.employment,
                housenumber = AddClientRequest.housenumber,
                country = AddClientRequest.country,
                zipcode = AddClientRequest.zipcode,
                currentemployer = "",
                yearsstay = "",
                position = "",
                joblevel = "",
                status = "Pending",
                others = AddClientRequest.others ?? "",
                recordRequested = AddClientRequest.recordRequested,

            };

            if (AddClientRequest.employment == "Yes")
            {
                clientDomainModel.currentemployer = AddClientRequest.currentemployer;
                clientDomainModel.yearsstay = AddClientRequest.yearsstay;
                clientDomainModel.position = AddClientRequest.position;
                clientDomainModel.joblevel = AddClientRequest.joblevel;
            }

            if (AddClientRequest.others == "Others")
            {
                clientDomainModel.others = AddClientRequest.others;
            }

            dbContext.Clients.Add(clientDomainModel);
            dbContext.SaveChanges();


            return RedirectToPage("Stat", new { trackingNumber = clientDomainModel.trackingnumber });
        }

    }

}