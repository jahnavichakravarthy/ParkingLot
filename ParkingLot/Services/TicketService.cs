using System;
using ParkingLot.Models;
using System.Collections.Generic;

namespace ParkingLot.Services
{
    interface ITicketService
    {
        string GenerateID();
        Ticket GenerateTicket(int slotId, string vehiclenumber);
        void UpdateTicketList(Ticket ticket);
        Ticket GetTicket(int id);
        int GetTicketCount();

    }
    public class TicketService : ITicketService
    {

        List<Ticket> tickets = new List<Ticket>();

        public string GenerateID()
        {
            string Id;
            Id = "TKT" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;//
            return Id;
        }
        public Ticket GenerateTicket(int slotId, string vehiclenumber)
        {
            //generate a ticket
            Ticket ticket = new Ticket(slotId, vehiclenumber)
            {
                Id = GenerateID(),
                InTime = DateTime.Now
            };
            return ticket;
        }
        public void UpdateTicketList(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        public Ticket GetTicket(int id)
        {
            Ticket SelectedTicket = tickets.Find(ticket => ticket.SlotNumber == id);
            return SelectedTicket;
        }
        public int GetTicketCount()
        {
            return tickets.Count;
        }
    }
}
