using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entities
{
     public class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public BadgeTier Tier { get; set; } = default!;
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = default!;
    }
    public enum BadgeTier
    {
        Standard,
        VIP,
    }
}
