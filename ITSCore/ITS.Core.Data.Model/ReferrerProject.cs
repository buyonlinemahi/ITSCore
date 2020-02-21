namespace ITS.Core.Data.Model
{
    /*
     * Latest Version : 1.1
 Page Name:  ReferrerProject.cs                      
  Version:  1.0                                              
  Purpose: create ReferrerProject model class                                                      
  Revision History:                                        
                                                           
    1.0 – 11/09/2012 Satya 
     * 
     * Version     : 1.1
     * Modified by : Pardeep
     * Date        : 13-June-2013
     * Description : Added new property EmailSendingOptionID

 */
    /// <summary>
    /// 
    /// </summary>
    public class ReferrerProject
    {
        public int ReferrerProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ReferrerID { get; set; }
        public int StatusID { get; set; }
        public bool FirstAppointmentOffered { get; set; }
        public bool Enabled { get; set; }
        public bool IsTriage { get; set; }
        public int EmailSendingOptionID { get; set; }
        public string CentralEmail { get; set; }
        public bool? IsActive { get; set; }
        
    }
}