using System;
using System.Collections.Generic;

namespace TrackingApp.Models.Domain
{
    public class Client
    {
        public Guid id { get; set; }
        public string? lastname { get; set; }
        public string? firstname { get; set; }
        public string? middlename { get; set; }
        public string? suffixname { get; set; }
        public string? yeargraduated { get; set; }
        public string? email { get; set; }
        public string? mobilenumber { get; set; }
        public string? studentnumber { get; set; }
        public string? graduate { get; set; }
        public string? program { get; set; }
        public string? employment { get; set; }
        public string? trackingnumber { get; set; }
        public string? housenumber { get; set; }
        public string? country { get; set; }
        public string? zipcode { get; set; }
        public string? currentemployer { get; set; }
        public string? yearsstay { get; set; }
        public string? position { get; set; }
        public string? joblevel { get; set; }
        public string? recordRequested { get; set; }
        public string? status { get; set; }
        public string? others { get; set; }

        public Client()
        {
            trackingnumber = GenerateTrackingNumber();
            currentemployer = "";
            yearsstay = "";
            position = "";
            joblevel = "";
        }

        private static string GenerateTrackingNumber()
        {
            string trackingPrefix = "STIPH";
            string randomNumber = GenerateRandomNumber();
            string trackingNumber = trackingPrefix + randomNumber;

            // Check if the tracking number already exists in the database or list
            while (CheckIfTrackingNumberExists(trackingNumber))
            {
                randomNumber = GenerateRandomNumber();
                trackingNumber = trackingPrefix + randomNumber;
            }

            return trackingNumber;
        }

        private static string GenerateRandomNumber()
        {
            Random random = new Random();
            long randomNumber = (long)(random.NextDouble() * 999999999999);
            string formattedNumber = randomNumber.ToString("D12");
            return formattedNumber;
        }

        private static bool CheckIfTrackingNumberExists(string trackingNumber)
        {
            // Check if the tracking number already exists in the database or list
            // and return true if it does, or false if it does not
            List<string> usedTrackingNumbers = GetUsedTrackingNumbersFromDatabase();

            return usedTrackingNumbers.Contains(trackingNumber);
        }

        private static List<string> GetUsedTrackingNumbersFromDatabase()
        {
            // Retrieve the list of used tracking numbers from the database
            // or create a new list if none exists
            // and return the list
            List<string> usedTrackingNumbers = new List<string>();
            // Code to retrieve the list from the database or file system
            return usedTrackingNumbers;
        }

    }
}
