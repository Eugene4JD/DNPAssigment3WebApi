using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DNPAssigment1.Models;
using FamilyWebAPi.DataAccess;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Models;

namespace DNPAssigment1.Data
{
    public class FamilyService : IFamilyService
    {
        private string familyFile = "families.json";
        private IList<Family> families;
        private FamilyDBContext dbContext;

        public FamilyService(FamilyDBContext familyDbContext)
        {
            dbContext = familyDbContext;
            families = new List<Family>();
            if (!File.Exists(familyFile))
            {
                WriteFamiliesToFile();
            }
            else
            {
                string content = File.ReadAllText(familyFile);
                families = JsonSerializer.Deserialize<List<Family>>(content);
            }
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            return this.families.ToList();
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            families.Add(family);
            WriteFamiliesToFile();
            return family;
        }

        public async Task RemoveFamilyAsync(String streetName, int houseNumber)
        {
            Family toRemove = families.First(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            families.Remove(toRemove);
            WriteFamiliesToFile();
        }

        public Task RemoveFamilyByStreetNameAsync(string streetName)
        {
            throw new NotImplementedException();
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            for (int i = 0; i < families.Count; i++)
            {
                if (families[i].StreetName.Equals(family.StreetName))
                {
                    families[i] = family;
                    break;
                }
            }
            WriteFamiliesToFile();
            return family;
        }

        private void WriteFamiliesToFile()
        {
            string productAsJson = JsonSerializer.Serialize(families);
            File.WriteAllText(familyFile, productAsJson);
        }
    }
}