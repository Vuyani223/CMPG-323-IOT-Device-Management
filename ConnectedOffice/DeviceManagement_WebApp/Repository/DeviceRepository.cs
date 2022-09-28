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
	public class DeviceRepository
	{
		protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
		
		// GET ALL: Devices
        public async List<Device> GetAll()
		{
			return _context.Device.ToList();
		}

		// Get Devices by ID
		public async Task<Device> GetById(Guid? id)
        {
			var device = await _context.Device.FindByIdAsync(id);
			return (device);
		}

		//DELETE Device by ID
		public async Task<Device> DeleteByName(string name)
        {
			var device = await _context.Set<Device>().FindAsync(name);
			if (device == null)
            {
				return device;
            }

			_context.Set<Device>().Remove(device);
			await _context.SaveChangesAsync();

			return device;
		}

		//Edit
		public async Task<Device> Edit(Device device)
        {
			_context.Entry(device).State = Device.Modified;
			await _context.SaveChangesAsync();

			return device;
        }

		//Create
		public async Task<Device> Create(Device device)
        {
			_context.Set<Device>().Add(device);
			await _context.SaveChangesAsync();
			return device;
		}

		//Exits
		public async Task<Device> Exist(string name)
        {
			var device = await _context.Set<Device>().FindAsync(name);
			string exist = "Yes";
			if (device != null)
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

