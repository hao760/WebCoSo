using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

//using PagedList;
//using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        Model1 db = new Model1();
        // GET: SanPham
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        public ActionResult AddSanPham()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.thuongHieu = db.ThuongHieux.ToList();
            mymodel.loaiHangHoa = db.LoaiHangHoas.ToList();
            return View(mymodel);
        }
        [HttpPost]
        public ActionResult AddSanPham(HttpPostedFileBase file, FormCollection collection)
        {
            HangHoa hh = new HangHoa(); 

            if (file != null && file.ContentLength > 0)
                try
                {
                    var ten = collection["TenHangHoa"];
                    hh.TenHangHoa = ten;
                    var gia = collection["Gia"];
                    var thuongHieu =  Convert.ToInt32(collection["thuongHieu"]);
                    hh.GiaBan = Int32.Parse(gia);
                    hh.MaThuongHieu = thuongHieu;
                    string path = Path.Combine(Server.MapPath("~/ImgSanPham"),
                                      Path.GetFileName(file.FileName));
                    int loaiHang = Convert.ToInt32(collection["loaiHangHoa"]);
                    hh.MaLoaiHang = loaiHang;
                    file.SaveAs(path);
                    hh.AnhSanPham = Path.GetFileName(file.FileName); /*Path.Combine(("ImgSanPham"),*/
                    db.HangHoas.Add(hh);
                    db.SaveChanges();
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR  :" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("AddSanPham", "SanPham");
        }
        public ActionResult LayDanhSachLoaiSP()
        {
            var list = db.LoaiHangHoas.ToList();
            return PartialView(list);
        }
        public ActionResult LaySPTheoLoai(int maloai)
        {
            var list = db.HangHoas.Where(s => s.MaLoaiHang == maloai).ToList();
            return View(list);
        }
        //public ActionResult LaySPTheoLoai(int maloai, int? page)
        //{
        //    int pageSize = 6;
        //    int pageNum = (page ?? 1);
        //    return View(db.HangHoas.Where(s => s.MaLoaiHang == maloai).ToList().ToPagedList(pageNum, pageSize));

        //}
        public ActionResult LayDanhSachThuongHieu()
        {
            var list = db.ThuongHieux.ToList();
            return PartialView(list);
        }
        public ActionResult LaySPTheoThuongHieu(int maThuongHieu)
        {
            var list = db.HangHoas.Where(s => s.MaThuongHieu == maThuongHieu).ToList();
            return View("LaySPTheoLoai", list);
        }




        public ActionResult AddSPBangEXCEL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = (DataTable)Session["tmpdata"];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(dt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSPBangEXCEL(HttpPostedFileBase upload)
        {
            db = new Model1();

            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    IExcelDataReader reader = null;


                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                    //int fieldcount = reader.FieldCount;
                    //int rowcount = reader.RowCount;
                    DataTable dt = new DataTable();
                    DataRow row;
                    HangHoa temp;
                    DataTable dt_ = new DataTable();
                    try
                    {
                        dt_ = reader.AsDataSet().Tables[0];
                        for (int i = 0; i < dt_.Columns.Count; i++)
                        {
                            dt.Columns.Add(dt_.Rows[0][i].ToString());
                        }

                        //int rowcounter = 0;
                        for (int row_ = 1; row_ < dt_.Rows.Count; row_++)
                        {
                            temp = new HangHoa();
                            row = dt.NewRow();

                            for (int col = 0; col < dt_.Columns.Count; col++)
                            {
                                row[col] = dt_.Rows[row_][col].ToString();
                                if (col == 0)
                                {
                                    temp.TenHangHoa = dt_.Rows[row_][0].ToString();
                                    continue;
                                }
                                if (col == 1)
                                {
                                    temp.MaThuongHieu = ChuyenThuongHieuThanhMa(dt_.Rows[row_][1].ToString());
                                    continue;
                                }
                                if (col == 2)
                                {
                                    temp.MaLoaiHang = ChuyenTenLoaiThanhMa(dt_.Rows[row_][2].ToString());
                                    continue;
                                }
                                if (col == 3)
                                {
                                    temp.GiaBan = Convert.ToDecimal(dt_.Rows[row_][3]);
                                    continue;
                                }
                                if (col == 4)
                                {
                                    temp.MaKhuyenMai = 1;
                                    continue;
                                }
                                if (col == 5)
                                {
                                    temp.AnhSanPham = dt_.Rows[row_][5].ToString();
                                    continue;
                                }
                                if (col == 6)
                                {
                                    temp.SoLuongCon = 0;
                                    continue;
                                }
                            }


                            dt.Rows.Add(row);
                            db.HangHoas.Add(temp);
                            db.SaveChanges();

                        }

                    }

                    catch (Exception ex)

                    {
                        ModelState.AddModelError("File", "Unable to Upload file!");
                        
                        return View();
                    }

                    DataSet result = new DataSet();
                    result.Tables.Add(dt);
                    reader.Close();
                    reader.Dispose(); ;
                    ViewBag.Message = "Sản phẩm được thêm thành công.";
                     DataTable tmp = result.Tables[0];
                    Session["tmpdata"] = tmp;  //store datatable into session
                    return RedirectToAction("AddSPBangEXCEL");
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }
        public int ChuyenTenLoaiThanhMa(string tenLoai)
        {
            int loai = db.LoaiHangHoas.Where(s => s.TenLoai == tenLoai).SingleOrDefault().MaLoaiHang;
            return loai;
        }
        public int ChuyenThuongHieuThanhMa(string tenThuongHieu)
        {
            db = new Model1();
            ThuongHieu thieu = db.ThuongHieux.Where(s => s.TenThuongHieu.Equals(tenThuongHieu)).SingleOrDefault();
            if (thieu == null)
            {
                thieu = new ThuongHieu();
                thieu.TenThuongHieu = tenThuongHieu;
                db.ThuongHieux.Add(thieu);
                db.SaveChanges();
                thieu = db.ThuongHieux.Where(s => s.TenThuongHieu.Equals(tenThuongHieu)).SingleOrDefault();
            }
            return thieu.MaThuongHieu;
        }
    }
}