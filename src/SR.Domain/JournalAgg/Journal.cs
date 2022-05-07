using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Domain.PostingAgg;
using SR.Domain.UserAgg;

namespace SR.Domain.JournalAgg
{
    public class Journal
    {


       
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MonthID { get; set; }
        public string AcountNumber { get; set; }
        public string RullNumber { get; set; }
        public string CollaborationType { get; set; }
        public int MonthPerformance { get; set; }   
        public string MonthMessage { get; set; }

        //navigation properties
        public User User { get; set; }
        public List<Posting> Postings { get; set; }

        public Journal()
        {

        }

        public Journal(int userId, int monthID, string acountNumber, string rullNumber, string collaborationType, int monthPerformance, string monthMessage)
        {
            UserId = userId;
            MonthID = monthID;
            AcountNumber = acountNumber;
            RullNumber = rullNumber;
            CollaborationType = collaborationType;
            MonthPerformance = monthPerformance;
            MonthMessage = monthMessage;
        }

       public void Edit(int userId, int monthID, string acountNumber, string rullNumber, string collaborationType, int monthPerformance, string monthMessage)
        {
            UserId = userId;
            MonthID = monthID;
            AcountNumber = acountNumber;
            RullNumber = rullNumber;
            CollaborationType = collaborationType;
            MonthPerformance = monthPerformance;
            MonthMessage = monthMessage;
        }
    }
}
