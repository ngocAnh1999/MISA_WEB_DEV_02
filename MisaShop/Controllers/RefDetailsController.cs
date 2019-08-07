using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MISA.DL;
using MISA.Entities;
using MISA.Entities.Dictionary;
using MisaShop.Properties;

namespace MisaShop.Controllers
{
    public class RefDetailsController : ApiController
    {
        private RefDL _refDL = new RefDL();

        [Route("refdetails/{refid}")]
        [HttpGet]
        public AjaxResult GetRefDetailByRefID(Guid refid)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetRefDetailByRefID(refid);

            }catch(Exception ex)
            {
                _ajaxResult.Data = ex;
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;

            }
            return _ajaxResult;
        }
    }
}