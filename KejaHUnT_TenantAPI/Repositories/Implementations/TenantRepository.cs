﻿using KejaHUnT_TenantAPI.Data;
using KejaHUnT_TenantAPI.Models.Domain;
using KejaHUnT_TenantAPI.Models.Dto;
using KejaHUnT_TenantAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnT_TenantAPI.Repositories.Implementations
{
    public class TenantRepository : ITenantRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TenantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tenant> CreateTenantAsync(Tenant tenant)
        {
            await _dbContext.Tenants.AddAsync(tenant);
            await _dbContext.SaveChangesAsync();
            return tenant;
        }

        public async Task<Tenant?> DeleteAync(long id)
        {
            var existingTenant = await _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTenant != null)
            {
                _dbContext.Tenants.Remove(existingTenant);
                await _dbContext.SaveChangesAsync();
                return existingTenant;
            }
            return null;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _dbContext.Tenants.ToListAsync();
        }

        public async Task<Tenant?> GetTenantByIdAsync(long id)
        {
            return await _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Tenant?> UpdateAsync(long id, UpdateTenantRequestDto tenant)
        {
            var existingTenant = await _dbContext.Tenants
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingTenant == null)
            {
                return null;
            }

            _dbContext.Entry(existingTenant).CurrentValues.SetValues(tenant);


           
            await _dbContext.SaveChangesAsync();

            return existingTenant;
        }
    }
}
