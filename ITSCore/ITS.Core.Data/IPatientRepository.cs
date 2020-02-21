using Core.Base.Data;
using ITS.Core.Data.Model;
/*
 Page Name:  IPatientRepository.cs                      
 Latest Version:  1.0
 Author : Anuj Batra
 
 * Revision History:                                                   

Updated By: Anuj Batra
Date:       01-01-2013
Version     1.0
Desc:       Added method to GetPatientByPatientID.
===================================================================================
*/
namespace ITS.Core.Data
{
    public interface IPatientRepository : IBaseRepository<Patient>
	{

        int AddPatient(Patient patient);
        Patient GetPatientByPatientID(int patientID);

       int UpdatePatientByPatientID(Patient patient);
       
    }
}
