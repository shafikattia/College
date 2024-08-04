using College.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace College.ViewModel
{
    public class TraineeDepartmentViewModel
    {
        public int TraineID {  get; set; }
        
        public string TraineeName { get; set; }
        public string departmentName { get; set; }
        public string SearchTerm { get; set; }

    }
}

