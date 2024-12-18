namespace SaintMichel.Services;

public static class MockTicketService
{
    public static List<Ticket> GetMockTickets()
    {
        return new List<Ticket>
        {
            new Ticket { Title = "Ticket 1", Description = "PB : Je n'arrive pas a faire mon compte", Status = "Open" },
            new Ticket { Title = "Ticket 2", Description = "Description of ticket 2", Status = "In Progress" },
            new Ticket { Title = "Ticket 3", Description = "Description of ticket 3", Status = "Closed" },
        };
    }
}
