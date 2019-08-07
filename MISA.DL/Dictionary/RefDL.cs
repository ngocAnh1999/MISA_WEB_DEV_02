using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Entities;

namespace MISA.DL
{
    public class RefDL
    {
        private MisaShopContext db = new MisaShopContext();

        // Hàm thực hiện lấy danh sách phiếu thu
        // Người tạo: Ngọc Ánh 30/07/2019
        public IEnumerable<Ref> GetData(int _pageIndex, int _pageSize)
        {
            
                var _refs = db.Refs.OrderBy(p => p.RefNo)
                .Skip((_pageIndex-1)*_pageSize)
                .Take(_pageSize);
                return  _refs;
        }

        // Hàm thực hiện thêm mới phiếu thu
        // Nguowif taoj: Ngoc Anh 30/07/2019
        public void AddRef(Ref _ref)
        {
            _ref.RefId = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        // Hàm thực hiện thêm mới phiếu thu 
        // Người tạo ngocanh 31/07/2019
        public IEnumerable<RefDetail> GetRefDetailByRefID(Guid _refId)
        {
            var _refResult = db.RefDetails.Where(p => p.RefId == _refId).ToList();
            return _refResult;
        }
    }
}
