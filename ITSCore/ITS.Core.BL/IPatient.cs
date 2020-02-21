using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  IPatient.cs                      
 Latest Version:  1.0
 Author : Anuj Batra
 
 * Revision History:                                                   

Updated By: Anuj Batra
Date:       01-01-2013
Version     1.0
Desc:       Added method to GetPatientByPatientID and GetAllPatient.
===================================================================================
*/

namespace ITS.Core.BL
{
    public interface IPatient
    {
        int AddPatient(Patient patient);
        Patient GetPatientByPatientID(int patientID);
        IEnumerable<Patient> GetAllPatient();
        int UpdatePatientByPatientID(Patient patient);
    }
}
