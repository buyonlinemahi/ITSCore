﻿using System;
namespace ITS.Core.Data.Model
{

    public class InvoiceCollectionActionUserName
    {
        public int InvoiceCollectionActionID { get; set; }
        public int InvoiceID { get; set; }
        public string Action { get; set; }
        public int UserID { get; set; }
        public DateTime FollowUpDate { get; set; }
        public DateTime DateofAction { get; set; }
        public string UserName { get; set; }
    }
}