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
            if (!File.Exists(familyFile))
            {
                //Seed();
                WriteFamiliesToFile();
            }
            else
            {
                string content = File.ReadAllText(familyFile);
                families = JsonSerializer.Deserialize <List<Family>>(content);
            }
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            return this.families;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            int max = families.Max(family => family.Id);
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
            Family toUpdate = families.First(f => f.Id == family.Id);
            WriteFamiliesToFile();
            return toUpdate;
        }
        
        private void WriteFamiliesToFile()
        {
            string productAsJson = JsonSerializer.Serialize(families);
            File.WriteAllText(familyFile,productAsJson);
        }
        /*
        private void Seed()
        {
            Family[] fm =
            {
                new Family()
                {
                    Children = new Child[]
                    {
                        new Child()
                        {
                            Interests = new ChildInterest[]
                            {
                                ChildInterest.Soccer,
                                ChildInterest.Scout
                            }.ToList(),
                            Pets = new Pet[]
                            {
                                new Pet()
                                {
                                    Age = 3,
                                    Name = "Chapie",
                                    Species = PetSpecies.Dog
                                }
                            }.ToList(),
                            FirstName = "Tom",
                            LastName = "Dean",
                            EyeColor = EyeColor.Brown,
                            HairColor = HairColor.Black,
                            Age = 12,
                            Height = 140,
                            Weight = 45,
                            Id = 1

                        }
                    }.ToList(),

                    Adults = new Adult[]
                    {
                        new Adult()
                        {
                            Age = 34,
                            EyeColor = EyeColor.Black,
                            FirstName = "Mike",
                            HairColor = HairColor.Blond,
                            Height = 170,
                            Id = 1,
                            Job = Job.Astronaut.ToString(),
                            LastName = "Dean",
                            Weight = 60
                        },
                        new Adult()
                        {
                            Age = 35,
                            EyeColor = EyeColor.Blue,
                            FirstName = "Doraty",
                            HairColor = HairColor.Blue,
                            Height = 167,
                            Id = 2,
                            Job = Job.Waitress.ToString(),
                            LastName = "Dean",
                            Weight = 55
                        }
                    }.ToList(),

                    Pets = new Pet[]
                    {
                        new Pet()
                        {
                            Age = 3,
                            Name = "Chapie",
                            Species = PetSpecies.Dog
                        }
                    }.ToList(),
                    //Lastname = "Dean",
                    Address = "Downing street 5, Boston",
                    Id = 1
                },
            new Family()
                {
                    Children = new Child[]
                    {
                        new Child()
                        {
                            Interests = new ChildInterest[]
                            {
                                ChildInterest.Soccer,
                                ChildInterest.Scout
                            }.ToList(),
                            Pets = new Pet[]
                            {
                                new Pet()
                                {
                                    Age = 3,
                                    Name = "Braddy",
                                    Species = PetSpecies.Hamster
                                }
                            }.ToList(),
                            FirstName = "Mike",
                            LastName = "Green",
                            EyeColor = EyeColor.Brown,
                            HairColor = HairColor.Blue,
                            Age = 17,
                            Height = 182,
                            Weight = 75,
                            Id = 2
                        }
                    }.ToList(),

                    Adults = new Adult[]
                    {
                        new Adult()
                        {
                            Age = 45,
                            EyeColor = EyeColor.Blue,
                            FirstName = "Luke",
                            HairColor = HairColor.Blond,
                            Height = 185,
                            Id = 3,
                            Job = Job.Chef.ToString(),
                            LastName = "Green",
                            Weight = 87
                        },
                        new Adult()
                        {
                            Age = 39,
                            EyeColor = EyeColor.Amber,
                            FirstName = "Lucy",
                            HairColor = HairColor.Grey,
                            Height = 178,
                            Id = 4,
                            Job = Job.Chemist.ToString(),
                            LastName = "Green",
                            Weight = 64
                        }
                    }.ToList(),

                    Pets = new Pet[]
                    {
                        new Pet()
                        {
                            Age = 3,
                            Name = "Braddy",
                            Species = PetSpecies.Hamster
                        }
                    }.ToList(),
                    //Lastname = "Green",
                    Address = "Brown street 12, New York",
                    Id = 2
                }
            };
            families = fm.ToList();
        }*/
    }
}