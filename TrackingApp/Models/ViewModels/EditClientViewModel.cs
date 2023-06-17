using System.ComponentModel.DataAnnotations;

namespace TrackingApp.Models.ViewModels
{
    public class EditClientViewModel
    {
        public Guid id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string suffixname { get; set; }
        public string yeargraduated { get; set; }
        public string email { get; set; }
        public string mobilenumber { get; set; }
        public string studentnumber { get; set; }
        public string graduate { get; set; }
        public string program { get; set; }
        public string employment { get; set; }
        public string comment { get; set; }
        public string housenumber { get; set; }
        public string streetname { get; set; }
        public string subdivision { get; set; }
        public string barangay { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string currentemployer { get; set; }
        public string yearsstay { get; set; }
        public string position { get; set; }
        public string joblevel { get; set; }
        public string recordRequested { get; set; }
        public bool EditTranscript { get; set; }
        public bool EditDiploma { get; set; }
        public bool EditForm137 { get; set; }
        public bool EditCertification { get; set; }
        public bool EditOthers { get; set; }
        public string others { get; set; }
        public string status { get; set; }

        public EditClientViewModel()
        {
            status = "Pending";
        }
    }

}
