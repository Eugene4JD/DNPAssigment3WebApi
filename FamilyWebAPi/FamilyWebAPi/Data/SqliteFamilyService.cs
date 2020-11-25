using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyWebAPi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace DNPAssigment1.Data
{
    public class SqliteFamilyService : IFamilyService
    {
        private FamilyDBContext ctx;

        public SqliteFamilyService(FamilyDBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            var families = await ctx.Families.ToListAsync();
            return families;
        }

       
        public async Task<Family> AddFamilyAsync(Family family)
        {
            EntityEntry<Family> newlyAdded = await ctx.Families.AddAsync(family);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            var families = await ctx.Families.ToListAsync();
            Family toRemove = families.First(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            if (toRemove != null)
            {
                ctx.Families.Remove(toRemove);
                await ctx.SaveChangesAsync();
            }
        }
        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            try
            {
                ctx.Update(family);
                //await RemoveFamilyByStreetNameAsync(family.StreetName);
                //await AddFamilyAsync(family);
                await ctx.SaveChangesAsync();
                return family;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}