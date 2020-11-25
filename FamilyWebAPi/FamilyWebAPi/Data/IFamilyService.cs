using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNPAssigment1.Models;
using Models;

namespace DNPAssigment1.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();

        Task<Family> AddFamilyAsync(Family family);

        Task RemoveFamilyAsync(string streetName, int housenumber);
        
        Task<Family> UpdateFamilyAsync(Family family);
    }
}