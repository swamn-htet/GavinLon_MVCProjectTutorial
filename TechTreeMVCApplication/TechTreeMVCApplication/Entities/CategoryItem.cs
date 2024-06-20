﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTreeMVCApplication.Entities
{
	public class CategoryItem
	{
        public int Id { get; set; }

		[Required]
		[StringLength(200,MinimumLength =2)]
		public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }

		[NotMapped]
		public virtual ICollection<SelectListItem> MediaType {  get; set; }
		public DateTime DateTimeItemReleased { get; set; }

    }
}
