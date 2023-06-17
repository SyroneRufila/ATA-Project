using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrackingApp.Data;
using TrackingApp.Models.Domain;

namespace TrackingApp.Pages.Clients
{
    public class ListModel : PageModel
    {
        private readonly TrackingAppDbContext dbContext;

        public List<Client> Clients { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public ListModel(TrackingAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int pageNumber = 1, string searchInput = null)
        {
            IQueryable<Client> query = dbContext.Clients.AsQueryable();

            // Apply the search filter if searchInput is provided
            if (!string.IsNullOrEmpty(searchInput))
            {
                query = query.Where(client => client.trackingnumber.Contains(searchInput));
            }

            // Get the total number of clients after applying the search filter
            var totalClients = query.Count();

            // Calculate the total number of pages based on the total number of clients and the page size
            var pageSize = 10;
            TotalPages = (int)Math.Ceiling(totalClients / (double)pageSize);

            // Adjust the page number if it's out of range
            PageNumber = pageNumber > TotalPages ? TotalPages : pageNumber;
            PageNumber = PageNumber < 1 ? 1 : PageNumber;

            // Apply pagination to the query
            query = query.Skip((PageNumber - 1) * pageSize).Take(pageSize);

            // Retrieve the clients from the query
            Clients = query.ToList();
        }
    }
}
