using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;
/*
 Page Name:  PatientImpl.cs                      
 Latest Version:  1.0
 Author : Anuj Batra
 
 * Revision History:                                                   

Updated By: Anuj Batra
Date:       01-01-2013
Version     1.0
Desc:       Added method to GetPatientByPatientID and GetAllPatient.
===================================================================================
*/
namespace ITS.Core.BL.Implementation
{
    public class PatientImpl : IPatient
    {
        private readonly IPatientRepository _patientRepository;

     

        public PatientImpl(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        public int AddPatient(Patient patient)
        {
            return _patientRepository.AddPatient(patient);
        }


        public Patient GetPatientByPatientID(int patientID)
        {
            return _patientRepository.GetPatientByPatientID(patientID);
        }

        public IEnumerable<Patient> GetAllPatient()
        {
            return _patientRepository.GetAll();
        }


        public int UpdatePatientByPatientID(Patient patient)
        {
            return _patientRepository.UpdatePatientByPatientID(patient);
           
        }

    }
}
