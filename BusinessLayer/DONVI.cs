using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    /// <summary>
    /// Hàm xử lý liên quan đến đơn vị
    /// </summary>
    public class DONVI
    {
        Entities db;

        /// <summary>
        /// Khởi tạo
        /// </summary>
        public DONVI()
        {
            db = Entities.CreateEntities();
        }

        /// <summary>
        /// Tìm kiếm theo mã đơn vị
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <returns></returns>
        public DataLayer.DONVI GetItem(string maDonVi)
        {
            return db.DONVIs
                .FirstOrDefault(x => 
                string.Equals(x.MADVI, maDonVi, System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm kiếm toàn bộ
        /// </summary>
        /// <returns></returns>
        public List<DataLayer.DONVI> GetAll()
        {
            return db.DONVIs.ToList();
        }

        /// <summary>
        /// Tìm kiếm tất cả theo mã công ty
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <returns></returns>
        public List<DataLayer.DONVI> GetAll(string maCongTy)
        {
            return db.DONVIs
                .Where(x => 
                string.Equals(x.MACTY, maCongTy, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Tạo mới
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Add(DataLayer.DONVI item)
        {
            try
            {
                db.DONVIs.Add(item);
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
        public void Update(DataLayer.DONVI item)
        {
            DataLayer.DONVI _dvi = db.DONVIs
                .FirstOrDefault(x => string.Equals(x.MADVI, item.MADVI, StringComparison.OrdinalIgnoreCase));
            _dvi.MACTY = item.MACTY;
            _dvi.TENDVI = item.TENDVI;
            _dvi.DIENTHOAI = item.DIENTHOAI;
            _dvi.FAX = item.FAX;
            _dvi.EMAIL = item.EMAIL;
            _dvi.DIACHI = item.DIACHI;
            _dvi.DISABLED = item.DISABLED;
            _dvi.KHO = item.KHO;
            _dvi.KYHIEU = item.KYHIEU;

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
        public void Delete(string maDonVi)
        {
            DataLayer.DONVI _dvi = db.DONVIs
                .FirstOrDefault(x => string.Equals(x.MADVI, maDonVi, StringComparison.OrdinalIgnoreCase));
            _dvi.DISABLED = true;

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
