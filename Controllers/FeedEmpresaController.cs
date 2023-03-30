using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicativoSponsor.Models;
using AplicativoSponsor.Data;

namespace AplicativoSponsor.Controllers
{
    public class FeedEmpresaController : Controller
    {
        public ActionResult FeedEmpresa()
        {
            List<Empresa> empresa = new List<Empresa>();

            EmpresaDAO empresadao = new EmpresaDAO();

            empresa = empresadao.SearchAll();

            return View("FeedEmpresa", empresa);
        }

        public ActionResult Details(int id)
        {


            EmpresaDAO empresadao = new EmpresaDAO();

            Empresa empresa = empresadao.SearchOne(id);

            return View("Details", empresa);
        }

        public ActionResult Create()
        {
            return View("FormEmpresa");
        }

        public ActionResult Edit(int id)
        {
            EmpresaDAO empresadao = new EmpresaDAO();

            Empresa empresa = empresadao.SearchOne(id);
            return View("FormEmpresa", empresa);
        }

        public ActionResult ProcessCreate(Empresa empresa)
        {

            EmpresaDAO empresaDAO = new EmpresaDAO();

            empresaDAO.uptate(empresa);

            return View("Details", empresa);
        }

        public ActionResult Delete(int id)
        {

            EmpresaDAO empresaDAO = new EmpresaDAO();
            empresaDAO.Delete(id);

            List<Empresa> empresa = empresaDAO.SearchAll();

            return View("FeedEmpresa", empresa);
        }
    }
}