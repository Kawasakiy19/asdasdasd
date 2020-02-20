using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace NewTicketWPF
{
    public class TicketManagement
    {
        public List<Ticket> tickets;

        public TicketManagement()
        {
            tickets = new List<Ticket>();
        }

        public TicketManagement(int length) 
        {
            tickets = new List<Ticket>();
            GenerateTickets(length);
        }
         
        public TicketManagement(int type, int length)
        {
            tickets = new List<Ticket>();
            GenerateTickets(type, length);
        }

        public List<Ticket> GetTickets
        {
            get { return tickets; }
        }

        public void GenerateTickets(int length)
        {
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                tickets.Add(new Ticket(r.Next(1000000, 9999000)));
            }
        }

        public void GenerateTickets(int type, int length)
        {
            tickets = new List<Ticket>();
            Random r = new Random();
            if (type == 0)
            {
                for (int i = 0; i < length; i++)
                {
                    tickets.Add(new Ticket(r.Next(100000, 999900)));
                }
            }
            if (type == 1)
            {
                for (int i = 0; i < length; i++)
                {
                    tickets.Add(new Ticket(r.Next(1000000, 9999900)));
                }
            }
            if (type == 2)
            {
                for (int i = 0; i < length; i++)
                {
                    tickets.Add(new Ticket(r.Next(10000000, 99999900)));
                }
            }
        }

        public bool CheckEmpty()
        {
            if (tickets.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
