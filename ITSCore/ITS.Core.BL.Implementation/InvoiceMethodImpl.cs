using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

#region Comment
/*
    * Author : Satya
    * Latest Version : 1.0
    * Reason :- class For InvoiceMethod    
    * Created on 11-22-2012 
 
*/
#endregion

namespace ITS.Core.BL.Implementation
{
    public class InvoiceMethodImpl : IInvoiceMethod
    {
        private readonly IInvoiceMethodRepository _invoiceMethodRepository;

        public InvoiceMethodImpl(IInvoiceMethodRepository invoiceMethodRepository)
        {
            _invoiceMethodRepository = invoiceMethodRepository;
        }

        public IEnumerable<InvoiceMethod> GetAllInvoiceMethod()
        {
            return _invoiceMethodRepository.GetAll();
        }
    }
}
