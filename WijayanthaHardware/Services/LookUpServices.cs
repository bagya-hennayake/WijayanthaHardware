using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.DBContext;

namespace WijayanthaHardware.Services
{
    public class LookUpServices : RepositoryBase
    {
        public List<LookUpBO> GetLookUp(LookUpTypeEnum lookUpTypeEnum)
        {
            try
            {
                using (var context = CreateContext())
                {
                    string sqlCommand = $" SELECT [{lookUpTypeEnum.ToString()}ID] AS LookUpId,[Value],[Description],[Status]  FROM [LookUp].[{lookUpTypeEnum.ToString()}] WHERE Status=1";
                    return context.Database.SqlQuery<LookUpBO>(sqlCommand).OrderBy(o => o.Value).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.StackTrace;
                return new List<LookUpBO>();

            }
        }
    }
}