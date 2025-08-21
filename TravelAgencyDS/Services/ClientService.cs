using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models.Entities;

namespace TravelAgency.Services
{
    public class ClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add a new client
        public void AddClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        // Optional: Get all clients
        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }
    }
}
