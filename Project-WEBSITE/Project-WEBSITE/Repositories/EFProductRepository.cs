﻿using Microsoft.EntityFrameworkCore;
using Project_WEBSITE.Models;

namespace Project_WEBSITE.Repositories
{
	public class EFProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public EFProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await _context.Products.Include(p=>p.Category).ToListAsync();
		}
		public async Task<Product> GetByIdAsync(int Id)
		{
			return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == Id);
		}
		public async Task AddAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}
		public async Task DeleteAsync(int id)
		{
			var product = await _context.Products.FindAsync(id);
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}
	}
}
