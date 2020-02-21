using ITS.Core.Data.Model;
using System.Collections.Generic;


#region Comment
/*
    * Page Name: IInvoiceMethod.cs
    * Author : Satya
    * Latest Version : 1.0
    * Reason :- Interface For InvoiceMethod
    * Created on 11-22-2012   
  
  
*/
#endregion

namespace ITS.Core.BL
{
    public interface IInvoiceMethod
    {
        IEnumerable<InvoiceMethod> GetAllInvoiceMethod();
    }
}
