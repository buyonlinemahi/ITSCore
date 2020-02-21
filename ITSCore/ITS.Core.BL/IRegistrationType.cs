using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Page Name: IRegistrationType.cs
    * Author : Vishal
    * Latest Version : 1.0
    * Reason :- Interface For Registration Type
    * Created on 12-21-2012     
*/
#endregion

namespace ITS.Core.BL
{   
    public interface IRegistrationType
    {
        IEnumerable<RegistrationType> GetAllRegistrationType();
        
    }
}
