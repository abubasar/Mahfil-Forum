using Mahfil.Controllers;
using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Mahfil.ViewModels
{
    public class MahfilFormViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public string Genre { get; set; }
        public DateTime GetDateTime() {
           
          return DateTime.Parse(string.Format("{0} {1}",Date,Time));

        }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<MahfilController, ActionResult>> updateExpression = c => c.Update(this);//this means returned view
                Expression<Func<MahfilController, ActionResult>> createExpression = c => c.Create(this);
                var action= (Id != "") ? updateExpression : createExpression;
                return (action.Body as MethodCallExpression).Method.Name;

                //return (Id !="") ? "Update" : "Create";  //Magic string not recommended
            }
               
        }
        public IEnumerable<Genre> Genres { get; set; }
    }
}