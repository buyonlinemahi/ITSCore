/*
 Page Name:  GlobalConst.cs                      
   Latest Version:  1.2                                              
  Purpose: Remove the const for Pracitioner.                                                       
  Revision History:                                        
                                                           
    1.0 – 10/26/2012 Satya   
======================================================================================
Edited By : Vishal Sen
 Dateted : 11/17/2012 
 Description: Add a Schema in Global Constr supplier
Version : 1.1
======================================================================================

 * Version : 1.2
 * Edited By : Anuj Batra
 * Dateted : 01/31/2013 
 * Description: Remove the const for Pracitioner.
======================================================================================
 */
namespace ITS.Core.Data.SqlServer.Global
{
    public class GlobalConst
    {
        public struct Schema
        {
            public const string DBO = "dbo";
            public const string LOOKUP = "lookup";
            public const string REFERRER = "referrer";
            public const string GLOBAL = "global";
            public const string SUPPLIER = "supplier";
            public const string DOT = ".";
            
        }
    }
}
