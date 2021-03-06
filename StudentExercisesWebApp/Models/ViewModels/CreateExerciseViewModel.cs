﻿using Microsoft.AspNetCore.Mvc.Rendering;
using StudentExercisesWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesWebApp.Models.ViewModels
{
    public class CreateExerciseViewModel
    {
        public Exercise Exercise { get; set; }

        public List<SelectListItem> AssignableStudents { get; private set; }
        
        [Display(Name = "Assign To Students")]
        public List<int> SelectedStudents { get; set; }

        public CreateExerciseViewModel() { }
        public CreateExerciseViewModel(ApplicationDbContext ctx)
        {
            List<Student> AllStudents = ctx.Students.ToList();
            AssignableStudents = AllStudents.Select(li => new SelectListItem()
            {
                Text = li.FirstName + " " + li.LastName,
                Value = li.StudentId.ToString()
            }).ToList();
        }

    }
}
