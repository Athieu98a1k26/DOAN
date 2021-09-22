using KMT.DATA_MODEL.BinhLuan;
using KMT.DATA_MODEL.MuaHang;
using KMT.DATA_MODEL.SanPham;
using KMT.WEB_FRONTEND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class ChiTietSanPhamController : BaseController
    {
        // GET: ChiTietSanPham
        public async Task<ActionResult> Index(int? Id)
        {
            if (!Id.HasValue|| CurrentUser == null)
            {
                Response.Redirect("/");
                Response.End();
            }
            SanPhamInfo data= await ApiService.sanPhamService.GetById(Id.Value);
            ViewBag.IsBinhLuan = await ApiService.binhLuanService.IsBinhLuan(CurrentUser.Id, Id.Value);
            return View(data);
        }

        public async Task<JsonResult> AddOrUpdate(BinhLuanRequest model)
        {
            BinhLuanRequest m = new BinhLuanRequest();
            m.IDSANPHAM = model.IDSANPHAM;
            m.NOIDUNG = model.NOIDUNG;
            m.IDUSER = CurrentUser.Id;
            m.NGUOITAO = string.IsNullOrEmpty(CurrentUser.Name) ? CurrentUser.UserName : CurrentUser.Name;
            int count = await ApiService.binhLuanService.AddOrUpdate(m);
            if (count==0)
            {
                return Json(new MessageResponse(500, "Lỗi Thêm bình luận"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Thêm bình luận thành công"),JsonRequestBehavior.AllowGet);
        }
        //GetListBinhLuan
        public async Task<JsonResult> GetListBinhLuan(int IDSANPHAM)
        {
            return Json(await ApiService.binhLuanService.GetListBinhLuan(IDSANPHAM), JsonRequestBehavior.AllowGet);
        }
        //MuaSanPham
        public async Task<JsonResult> MuaSanPham(int IDSANPHAM)
        {
            MuaHangRequest m = new MuaHangRequest();
            m.IDSANPHAM = IDSANPHAM;
            m.IDUSER = CurrentUser.Id;
            m.NGAYTAO = DateTime.Now;
            m.NGUOITAO = string.IsNullOrEmpty(CurrentUser.Name) ? CurrentUser.UserName : CurrentUser.Name;
            int count = await ApiService.muaHangService.AddOrUpdate(m);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Lỗi mua hàng"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Thêm sản phẩm thành công"), JsonRequestBehavior.AllowGet);
        }
    }
}