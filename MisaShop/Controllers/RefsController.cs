using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MISA.DL;
// using FresherTraining.Models;
using MISA.Entities;
using MISA.Entities.Dictionary;
using MisaShop.Properties;

namespace MisaShop.Controllers
{
    public class RefsController : ApiController
    {
        private RefDL _refDL = new RefDL();


        /// <summary>
        /// Hàm thực hiện lấy dữ liệ bảng phiếu thu chi REF
        /// Người tạo: Ngọc Ánh
        /// Ngày tạo: 25/07/2019
        /// </summary>
        /// <returns></returns>
        // GET: api/Refs
        [Route("refs/{_pageIndex}/{_pageSize}")]
        [HttpGet]
        public async Task<AjaxResult> GetRefs([FromUri] int _pageIndex,int _pageSize)
        {
            await Task.Delay(900);
            var _ajaxResult = new AjaxResult();
            try
            {

                _ajaxResult.Data = _refDL.GetData(_pageIndex, _pageSize);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }

        /// <summary>
        /// Thực hiện thêm mới 1 phiếu thu
        /// Người tạo VDThang 24/07/2019
        /// </summary>
        /// <returns></returns>
        [Route("refs")]
        [HttpPost]
        public AjaxResult Post([FromBody] Ref _ref)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.AddRef( _ref);
            } catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;

            }
            return _ajaxResult;
        }

        /// <summary>
        /// Thực hiện sửa 1 phiếu thu
        /// Người tạo VDThang 24/07/2019
        /// </summary>
        /// <returns></returns>
        //[Route("refs")]
        //[HttpPut]
        //public void Put([FromBody]Ref refitem)
        //{
        //    var item = db.Refs.Where(p => p.RefNo == refitem.RefNo).FirstOrDefault();
        //    item.RefDate = refitem.RefDate;
        //    item.RefNo = refitem.RefNo;
        //    item.RefType = refitem.RefType;
        //    item.ContactName = refitem.ContactName;
        //    item.Reason = refitem.Reason;
        //    item.Total = refitem.Total;
        //    db.SaveChanges();
        //}

        ///// <summary>
        ///// Thực hiện xóa các phiếu thu lựa chọn
        ///// Người tạo VDThang 24/07/2019
        ///// </summary>
        ///// <returns></returns>
        //[Route("refs")]
        //[HttpDelete]
        //public void DeleteMultiple([FromBody]List<Guid> refids)
        //{
        //    foreach (var refid in refids)
        //    {
        //        var refitem = db.Refs.Where(p => p.RefId == refid).FirstOrDefault();
        //        db.Refs.Remove(refitem);
        //    }
        //    db.SaveChanges();
        //}


    }
}