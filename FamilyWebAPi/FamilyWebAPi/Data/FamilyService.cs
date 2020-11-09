using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DNPAssigment1.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Models;

namespace DNPAssigment1.Data
{
    public class FamilyService : IFamilyService
    {
        private string familyFile = "families.json";
        private IList<Family> families;

        public FamilyService()
        {
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
            return this.families;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            int max = -1;
            if (families.Count > 0)
            {
                max = families.Max(family => family.Id);
            }
            
            Console.WriteLine("Here is ok");
            family.Id = (++max);
            families.Add(family);
            WriteFamiliesToFile();
            return family;
        }

        public async Task RemoveFamilyAsync(int familyId)
        {
            Family toRemove = families.First(f => f.Id == familyId);
            families.Remove(toRemove);
            WriteFamiliesToFile();
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