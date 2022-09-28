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
    public class ZoneRepository
	{
		protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

		// GET ALL: Homes
		public async List<Zone> GetAll()
		{
			return _context.Zone.ToList();
		}

		//GET Zones by ID
		public async Task<Category> GetById(Guid? id)
        {
			var zone = await _context.Category.FibdByIdAsync(id);
			return (zone);
        }

		//DELETE Zones by ID
		public async Task<Zone> DeleteByName(string name)
        {
			var zone = await _context.Set<Zone>().FindAsync(name);
			if (zone == null)
            {
				return zone;
            }

			_context.Set<Zone>().Remove(zone);
			await _context.SaveChangesAsync();

			return zone;
		}

		//Edit
		public async Task<Zone> Edit(Zone zone)
        {
			_context.Entry(zone).State = Zone.Modified;
			await _context.SaveChangesAsync();

			return zone;
        }

		//Create
		public async Task<Zone> Create(Zone zone)
        {
			_context.Set<Zone>().Add(zone);
			await _context.SaveChangesAsync();
			return zone;
		}

		//Exits
		public async Task<Zone> Exist(string name)
        {
			var zone = await _context.Set<Zone>().FindAsync(name);
			string exist = "Yes";
			if (zone != null)
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