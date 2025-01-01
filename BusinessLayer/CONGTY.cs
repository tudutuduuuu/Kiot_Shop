using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    /// <summary>
    /// Công ty
    /// </summary>
    public class CONGTY
    {
        Entities db;

        /// <summary>
        /// Khởi tạo
        /// </summary>
        public CONGTY()
        {
            db = Entities.CreateEntities();
        }

        /// <summary>
        /// Tìm kiếm theo mã công ty
        /// </summary>
        /// <param name="maCongTy"></param>
        /// <returns></returns>
        public DataLayer.CONGTY GetItem(string maCongTy)
        {
            return db.CONGTies
                .FirstOrDefault(x => string.Equals(
                    x.MACTY, maCongTy, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm kiếm tất cả
        /// </summary>
        /// <returns></returns>
        public List<DataLayer.CONGTY> GetAll()
        {
            return db.CONGTies.ToList();
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Add(DataLayer.CONGTY item)
        {
            try
            {
                db.CONGTies.Add(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm dữ liệu" + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Update(DataLayer.CONGTY item)
        {
            DataLayer.CONGTY _cty = db.CONGTies
                .FirstOrDefault(x => string.Equals(x.MACTY, item.MACTY, StringComparison.OrdinalIgnoreCase));
            _cty.TENCTY = item.TENCTY;
            _cty.DIENTHOAI = item.DIENTHOAI;
            _cty.FAX = item.FAX;
            _cty.EMAIL = item.EMAIL;
            _cty.DIACHI = item.DIACHI;
            _cty.DISABLED = item.DISABLED;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình cập nhật dữ liệu" + ex.Message);
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="maCongty"></param>
        /// <exception cref="Exception"></exception>
        public void Delete(string maCongty)
        {
            DataLayer.CONGTY _cty = db.CONGTies
                .FirstOrDefault(x => string.Equals(x.MACTY, maCongty, StringComparison.OrdinalIgnoreCase));
            _cty.DISABLED = true;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xóa dữ liệu" + ex.Message);
            }
        }
    }
}
