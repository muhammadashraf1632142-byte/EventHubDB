using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Description { get; set; } = default!;
        public int MaxAttendees { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = default!;
    }
}
