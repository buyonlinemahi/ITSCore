using ITS.Core.Data.Model;

/*
Latest Version:1.0
 * Author : Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add solicitor Interface
 * Description : Add Insert Method AddSolicitor

 */

namespace ITS.Core.BL
{
    public interface ISolicitor
    {
        int AddSolicitor(Solicitor solicitor);

        int UpdateSolicitorBySolicitorID(Solicitor solicitor);

        Solicitor GetSolicitorBySolicitorID(int solicitorID);

        Solicitor GetSolicitorByPatientID(int patientID);
    }
}