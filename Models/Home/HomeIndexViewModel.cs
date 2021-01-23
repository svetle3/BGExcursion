using BGExcursion.DAL;
using BGExcursion.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using PagedList;
using PagedList.Mvc;

namespace BGExcursion.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        BGExcursionEntities context = new BGExcursionEntities();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public IPagedList<Tbl_Category> ListOfCategories { get; set; }
        public HomeIndexViewModel CreateModel(string search,int pageSize,int? page)
        {
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel
            {
                ListOfProducts = data
            };
        }
    }
}