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
	public class HomeRepository
	{
		protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
		
		// GET ALL: Homes
        public async List<Home> GetAll()
		{
			return _context.Home.ToList();
		}
		
		// GET Homes by ID
		public async Task<Home> GetById(Guid id)
        {
			var home = await _context.Home.FindByIdAsync(id);
			return (home);
		}

		//DELETE Homes by ID
		public async Task<Home> DeleteByName(string name)
        {
			var home = await _context.Set<Home>().FindAsync(name);
			if (home == null)
            {
				return home;
            }

			_context.Set<Home>().Remove(home);
			await _context.SaveChangesAsync();

			return home;
		}

		//Edit
		public async Task<Home> Edit(Home home)
        {
			_context.Entry(home).State = Home.Modified;
			await _context.SaveChangesAsync();

			return home;
        }

		//Create
		public async Task<Home> Create(Home home)
        {
			_context.Set<Home>().Add(home);
			await _context.SaveChangesAsync();
			return home;
		}

		//Exits
		public async Task<Home> Exist(string name)
        {
			var home = await _context.Set<Home>().FindAsync(name);
			string exist = "Yes";
			if (home != null)
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