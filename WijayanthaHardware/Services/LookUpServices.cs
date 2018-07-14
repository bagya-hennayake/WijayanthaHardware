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
        public LookUpServices(WijayanathaDb wijayanathaDb) : base(wijayanathaDb)
        {

        }
        public List<LookUpBO> GetLookUp(LookUpTypeEnum lookUpTypeEnum)
        {
            try
            {
                //using (var context = CreateContext())
                //{
                    string sqlCommand = string.Format($" SELECT [{lookUpTypeEnum.ToString()}ID] AS LookUpId,[Value],[Description],[Status]  FROM [LookUp].[{lookUpTypeEnum.ToString()}] WHERE Status=1");
                    var result = CreateContext().Database.SqlQuery<LookUpBO>(sqlCommand).OrderBy(o => o.Value).ToList();
                    return result;
               // }
            }
            catch (Exception ex)
            {
                var aa = ex.StackTrace;
            }
            return new List<LookUpBO>();
        }
    }
}