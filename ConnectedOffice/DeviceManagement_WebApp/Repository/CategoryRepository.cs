using System;
using Microsot.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
	public class CategoryRepository
	{
		protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

		// GET ALL: Categories
		public async List<Category> GetAll()
		{
			return _context.Category.ToList();
		}

		// GET Categories by ID
		public async Task<Category> GetById(Guid? id)
        {
			var category = await _context.Category.FindByIdAsync(id);
			return (category);
        }

		//DELETE Categories by ID
		public async Task<Category> DeleteByName(string name)
        {
			var category = await _context.Set<Category>().FindAsync(name);
			if (category == null)
            {
				return category;
            }

			_context.Set<Category>().Remove(category);
			await _context.SaveChangesAsync();

			return category;
		}

		public async Task<Category> Edit(Category category)
        {
			_context.Entry(category).State = Category.Modified;
			await _context.SaveChangesAsync();

			return category;
        }
		
		//Create
		public async Task<Category> Create(Category category)
        {
			_context.Set<Category>().Add(category);
			await _context.SaveChangesAsync();
			return category;
		}

		//Exits
		public async Task<Category> Exist(string name)
        {
			var category = await _context.Set<Category>().FindAsync(name);
			string exist = "Yes";
			if (category != null)
            {
				exist = "Yes"
            }
			else
            {
				exist = "No"
            }

			return exist;
		}

	}
}

