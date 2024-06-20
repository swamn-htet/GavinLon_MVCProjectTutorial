﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechTreeMVCApplication.Entities;


namespace TechTreeMVCApplication.Data
{

    public class ApplicationUser : IdentityUser
    {
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Address1 { get; set; }

		[StringLength(250)] 
		public string Address2 { get; set; }

		[StringLength(50)]
		public string PostCode { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserCategory> UserCategory { get; set; }
    }

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options) 
        {          
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<MediaType> MediaType { get; set; } 
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<Content> Content { get; set; } 


    }


    

}
