using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTreeMVCApplication.Entities
{
	public class MediaType
	{
        public int Id { get; set; }

		[Required]
		[StringLength(200, MinimumLength =2)]
		public string Title { get; set; }

		[Required]
        public string ThumbnailImagePath { get; set; }

		[ForeignKey("MediaTypeId")]
        public virtual ICollection<CategoryItem> CategoryItem { get; set; }


    }
}
