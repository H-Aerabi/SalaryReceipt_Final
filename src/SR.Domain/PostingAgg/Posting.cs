using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Shared.Enums;
using SR.Domain.JournalAgg;

namespace SR.Domain.PostingAgg
{
    public class Posting
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public string Title { get; set; }
        public long CurrentAmount { get; set; }
        public bool IsTitle { get; set; }
        public long DeferredAmount { get; set; }
        public long DebtAmount { get; set; }
        //enum:AmountType in Shared.Enums
        public AmountType AmountType { get; set; }
        //enum:PaymentType in Shared.Enums
        public PaymentType PaymentType { get; set; }

        public long Remaining { get; set; }
        public string InstallmentNumber { get; set; }
        public string Description { get; set; }

       //navigation properties
      public Journal Journal { get; set; }

        public Posting(int journalId, string title, long currentAmount, long deferredAmount, long debtAmount, AmountType amountType, PaymentType paymentType, long remaining, string installmentNumber, string description, Journal journaln)
        {
            JournalId = journalId;
            Title = title;
            CurrentAmount = currentAmount;
            DeferredAmount = deferredAmount;
            DebtAmount = debtAmount;
            AmountType = amountType;
            PaymentType = paymentType;
            Remaining = remaining;
            InstallmentNumber = installmentNumber;
            Description = description;
            Journal = journaln;
        }
        public void Edit(int journalId, string title, long currentAmount, long deferredAmount, long debtAmount, AmountType amountType, PaymentType paymentType, long remaining, string installmentNumber, string description, Journal journaln)
        {
            JournalId = journalId;
            Title = title;
            CurrentAmount = currentAmount;
            DeferredAmount = deferredAmount;
            DebtAmount = debtAmount;
            AmountType = amountType;
            PaymentType = paymentType;
            Remaining = remaining;
            InstallmentNumber = installmentNumber;
            Description = description;
            Journal = journaln;
        }
    }
}
