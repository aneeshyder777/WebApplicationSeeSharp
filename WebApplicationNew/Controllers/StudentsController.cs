﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationNew.Data;
using WebApplicationNew.Models;
using WebApplicationNew.Models.Entities;

namespace WebApplicationNew.Controllers
{
    public class StudentsController : Controller
    {
        private readonly  ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {

            var student = new Student
            {
               
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Student viewmodel)
        {
           var student = await dbContext.Students.FindAsync(viewmodel.id);
            if (student is not null) 
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.Phone = viewmodel.Phone;
                student.Subscribed = viewmodel.Subscribed;
              
                await dbContext.SaveChangesAsync();

            }

             return RedirectToAction("List", "Students");

        }

        [HttpPost]

        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.id);

            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List","Students");
             
        }

    }
}
