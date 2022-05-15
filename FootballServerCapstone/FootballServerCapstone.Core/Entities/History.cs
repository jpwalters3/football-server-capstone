using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.Core.Entities
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }

        public string HistoryEntry{ get; set; }

        //Many to One
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is History history &&
                HistoryId == history.HistoryId &&
                HistoryEntry == history.HistoryEntry &&
                PlayerId == history.PlayerId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(HistoryId, HistoryEntry, PlayerId);
        }
    }
}
