﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TechTreeMVCApplication.Interfaces;

namespace TechTreeMVCApplication.Extensions
{
    public static class ConvertEntensions
    {
        public static List<SelectListItem> ConvertToSelectList<T>(this IEnumerable<T> collection, int selectedValue) where T : IPrimaryProperties
        {
            return (from item in collection
                     select new SelectListItem
                     {
                         Text = item.Title,
                         Value = item.Id.ToString(),
                         Selected = (item.Id == selectedValue)
                     }).ToList();

        }
    }

}
