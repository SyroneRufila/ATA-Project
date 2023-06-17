using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using TrackingApp.Data;
using TrackingApp.Models.ViewModels;

namespace TrackingApp.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly TrackingAppDbContext dbContext;

        [BindProperty]
        public EditClientViewModel EditClientViewModel { get; set; }



        public string DeleteMessage { get; set; }

        public EditModel(TrackingAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var client = dbContext.Clients.Find(id);

            if (client != null)
            {
                EditClientViewModel = new EditClientViewModel()
                {
                    id = client.id,
                    lastname = client.lastname,
                    firstname = client.firstname,
                    middlename = client.middlename,
                    suffixname = client.suffixname,
                    graduate = client.graduate,
                    yeargraduated = client.yeargraduated,
                    email = client.email,
                    mobilenumber = client.mobilenumber,
                    studentnumber = client.studentnumber,
                    program = client.program,
                    employment = client.employment,
                    housenumber = client.housenumber,
                    country = client.country,
                    zipcode = client.zipcode,
                    currentemployer = client.currentemployer,
                    yearsstay = client.yearsstay,
                    position = client.position,
                    joblevel = client.joblevel,
                    status = client.status,
                    recordRequested = client.recordRequested,
                    EditTranscript = client.recordRequested.Contains("Transcript"),
                    EditDiploma = client.recordRequested.Contains("Diploma"),
                    EditForm137 = client.recordRequested.Contains("Form 137"),
                    EditCertification = client.recordRequested.Contains("Certification"),
                    others = client.others
                };
            }
        }

        public void OnPostUpdate()
        {
            var recordsRequested = "";
            var checkboxes = new Dictionary<string, string>
        {
             {"Transcript", "EditTranscript"},
             {"Diploma", "EditDiploma"},
             {"Form 137", "EditForm137"},
             {"Certification", "EditCertification"}
        };

            foreach (var checkbox in checkboxes)
            {
                if ((bool)typeof(EditClientViewModel).GetProperty(checkbox.Value).GetValue(EditClientViewModel))
                {
                    recordsRequested += checkbox.Key + " ";
                }
            }


            if (EditClientViewModel != null)
            {
                var existingClient = dbContext.Clients.Find(EditClientViewModel.id);

                if (existingClient != null)
                {
                    existingClient.lastname = EditClientViewModel.lastname;
                    existingClient.firstname = EditClientViewModel.firstname;
                    existingClient.middlename = EditClientViewModel.middlename;
                    existingClient.suffixname = EditClientViewModel.suffixname;
                    existingClient.graduate = EditClientViewModel.graduate;
                    existingClient.yeargraduated = EditClientViewModel.yeargraduated;
                    existingClient.email = EditClientViewModel.email;
                    existingClient.mobilenumber = EditClientViewModel.mobilenumber;
                    existingClient.studentnumber = EditClientViewModel.studentnumber;
                    existingClient.housenumber = EditClientViewModel.housenumber;
                    existingClient.program = EditClientViewModel.program;
                    existingClient.employment = EditClientViewModel.employment;
                    existingClient.country = EditClientViewModel.country;
                    existingClient.zipcode = EditClientViewModel.zipcode;
                    existingClient.currentemployer = EditClientViewModel.currentemployer;
                    existingClient.yearsstay = EditClientViewModel.yearsstay;
                    existingClient.position = EditClientViewModel.position;
                    existingClient.joblevel = EditClientViewModel.joblevel;
                    existingClient.others = EditClientViewModel.others ?? "";
                    existingClient.recordRequested = EditClientViewModel.recordRequested;
                    if (existingClient.employment == "No")
                    {
                        existingClient.currentemployer = "";
                        existingClient.yearsstay = "";
                        existingClient.position = "";
                        existingClient.joblevel = "";
                    }
                    if (existingClient.status != null)
                    {
                        existingClient.status = EditClientViewModel.status;
                    }

                    dbContext.SaveChanges();
                }
            }
            dbContext.SaveChanges();
            ViewData["Message"] = "Client updated successfully";

        }

        public IActionResult OnPostDelete()
        {
            var existingClient = dbContext.Clients.Find(EditClientViewModel.id);

            if (existingClient != null)
            {
                dbContext.Clients.Remove(existingClient);
                dbContext.SaveChanges();

                DeleteMessage = $"Deleted ID: {existingClient.id}";

                return RedirectToPage("/Clients/List");
            }
            return Page();
        }

    }

}


