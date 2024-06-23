﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTreeMVCApplication.Entities
{
	public class Content
	{
        public int Id { get; set; }

		[Required]
		[StringLength(200, MinimumLength =2)]
		public string Title { get; set; }
        public string HTMLContent { get; set; }
        public string VideoLink { get; set; }
        public CategoryItem CategoryItem { get; set; }

        [NotMapped]
        public int CatItemId { get; set; }

        [NotMapped]
        public int CategoryId { get; set;}
    }
}
