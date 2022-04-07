﻿using System.Threading.Tasks;
using System.Web.Mvc;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;
using AutoMapper;
using System.Linq;
using University.BL.DTOs;
using System;

namespace University.Web.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IMapper mapper = MvcApplication.MapperConfiguration.CreateMapper();

        private readonly IInstructorRepository instructorRepository = new InstructorRepository(new UniversityModel());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> IndexJson()
        {
            var instructorsModel = await instructorRepository.GetAll();
            var instructorsDTO = instructorsModel.Select(x => mapper.Map<InstructorDTO>(x));
            return Json(instructorsDTO, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView(new InstructorDTO());
        }

        [HttpPost]
        public async Task<ActionResult> Create(InstructorDTO instructorDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var instructorModel = mapper.Map<Instructor>(instructorDTO);
                    await instructorRepository.Insert(instructorModel);
                }

                return Json(new ResponseDTO
                {
                    Message = "The process is successful",
                    IsSuccess = true,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var instructorModel = await instructorRepository.GetById(id);
            var instructorDTO = mapper.Map<InstructorDTO>(instructorModel);
            return PartialView(instructorDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(InstructorDTO instructorDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var instructorModel = mapper.Map<Instructor>(instructorDTO);
                    await instructorRepository.Update(instructorModel);
                }

                return Json(new ResponseDTO
                {
                    Message = "The process is successful",
                    IsSuccess = true,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await instructorRepository.Delete(id);
                return Json(new ResponseDTO
                {
                    Message = "The process is successful",
                    IsSuccess = true,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }

}
