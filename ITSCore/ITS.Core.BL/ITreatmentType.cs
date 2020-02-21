using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Page Name: ITreatmentType.cs
    * Author : Robin Singh
    * Latest Version : 1.0
    * Reason :- Interface For Treatment Type
    * Created on 01-01-2013     
*/
#endregion

namespace ITS.Core.BL
{
    public interface ITreatmentType
    {
        IEnumerable<TreatmentType> GetAllTreatmentType();
        
    }
}
