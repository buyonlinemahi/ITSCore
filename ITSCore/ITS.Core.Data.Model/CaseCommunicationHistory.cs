﻿using System;

namespace ITS.Core.Data.Model
{
    public class CaseCommunicationHistory
    {

        public int CaseCommunicationHistoryID { get; set; }
        public int CaseID { get; set; }
        public string SentTo { get; set; }
        public string SentCC { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public DateTime DateAdded { get; set; }
        public string UploadPath { get; set; }
        
    }
}