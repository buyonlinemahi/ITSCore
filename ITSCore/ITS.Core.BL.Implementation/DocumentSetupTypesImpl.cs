using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/* ============================================================================= 
 *  Page Name:  DocumentSetupTypesImpl.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:    created class DocumentSetupTypesImpl with a method to GetAll
 * ======================================================================================
 */


namespace ITS.Core.BL.Implementation
{
   public class DocumentSetupTypesImpl:IDocumentSetupTypes
    {

       
       private readonly IDocumentSetupTypesRepository _documentSetupTypesRepository;

       public DocumentSetupTypesImpl(IDocumentSetupTypesRepository documentSetupTypesRepository)
        {
            _documentSetupTypesRepository = documentSetupTypesRepository;
        }



        public IEnumerable<DocumentSetupTypes> GetAllDocumentSetupTypes()
        {
            return _documentSetupTypesRepository.GetAll();
        }
    }
}
