using KMT.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.Services
{
    public class ApiServiceFactory
    {
        private static readonly object SyncRoot = new object();
        public string Url { get; set; }
        public IHttpClient HttpClient { get; set; }
        public ApiServiceFactory(string apiGatewayAddress)
        {

            Url = apiGatewayAddress;
            HttpClient = new StandardHttpClient();
        }
        private UserService _userService;
        public UserService UserService
        {
            get
            {
                if (_userService == null)
                    lock (SyncRoot)
                    {
                        if (_userService == null)
                            _userService = new UserService(Url, HttpClient);
                    }
                return _userService;

            }
        }
        //PermissonMenuService
        private PermissonMenuService _permissonMenuService;

        public PermissonMenuService permissonMenuService
        {
            get
            {
                if (_permissonMenuService == null)
                    lock (SyncRoot)
                    {
                        if (_permissonMenuService == null)
                            _permissonMenuService = new PermissonMenuService(Url, HttpClient);
                    }
                return _permissonMenuService;

            }
        }
        private ThongTinDuLichService _thongTinDuLichService;

        public ThongTinDuLichService thongTinDuLichService
        {
            get
            {
                if (_thongTinDuLichService == null)
                    lock (SyncRoot)
                    {
                        if (_thongTinDuLichService == null)
                            _thongTinDuLichService = new ThongTinDuLichService(Url, HttpClient);
                    }
                return _thongTinDuLichService;

            }
        }
        private SanPhamService _sanPhamService;

        public SanPhamService sanPhamService
        {
            get
            {
                if (_sanPhamService == null)
                    lock (SyncRoot)
                    {
                        if (_sanPhamService == null)
                            _sanPhamService = new SanPhamService(Url, HttpClient);
                    }
                return _sanPhamService;

            }
        }
        
        private PhongService _phongService;

        public PhongService phongService
        {
            get
            {
                if (_phongService == null)
                    lock (SyncRoot)
                    {
                        if (_phongService == null)
                            _phongService = new PhongService(Url, HttpClient);
                    }
                return _phongService;

            }
        }



        private UserRoleService _userRoleService;

        public UserRoleService userRoleService
        {
            get
            {
                if (_userRoleService == null)
                    lock (SyncRoot)
                    {
                        if (_userRoleService == null)
                            _userRoleService = new UserRoleService(Url, HttpClient);
                    }
                return _userRoleService;

            }
        }



        private RolePermissonService _rolePermissonService;

        public RolePermissonService rolePermissonService
        {
            get
            {
                if (_rolePermissonService == null)
                    lock (SyncRoot)
                    {
                        if (_rolePermissonService == null)
                            _rolePermissonService = new RolePermissonService(Url, HttpClient);
                    }
                return _rolePermissonService;

            }
        }

        private PermissonService _permissonService;

        public PermissonService permissonService
        {
            get
            {
                if (_permissonService == null)
                    lock (SyncRoot)
                    {
                        if (_permissonService == null)
                            _permissonService = new PermissonService(Url, HttpClient);
                    }
                return _permissonService;

            }
        }

        private RoleService _roleService;

        public RoleService roleService
        {
            get
            {
                if (_roleService == null)
                    lock (SyncRoot)
                    {
                        if (_roleService == null)
                            _roleService = new RoleService(Url, HttpClient);
                    }
                return _roleService;

            }
        }



        private MenuQuanTriService _menuQuanTriService;
        
        public MenuQuanTriService menuQuanTriService
        {
            get
            {
                if (_menuQuanTriService == null)
                    lock (SyncRoot)
                    {
                        if (_menuQuanTriService == null)
                            _menuQuanTriService = new MenuQuanTriService(Url, HttpClient);
                    }
                return _menuQuanTriService;

            }
        }

    }
}