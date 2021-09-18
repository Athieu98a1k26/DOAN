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
        //RoleService
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