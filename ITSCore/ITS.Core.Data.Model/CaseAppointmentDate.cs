﻿using System;
namespace ITS.Core.Data.Model
{

    public class CaseAppointmentDate
    {
        public int CaseID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public DateTime? FirstAppointmentOfferedDate { get; set; }
        public string strAppointmentTime { get; set; }
        public string strAppointmentDate { get; set; }
        public string strAppointmentDate1 { get; set; }
        public DateTime CaseBookIADate { get; set; }
        public bool IsCaseBookIADateUsed { get; set; }
    }
}

