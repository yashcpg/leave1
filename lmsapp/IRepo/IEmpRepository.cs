using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace lmsapp.IRepo
{
    
 public interface IEmpRepository
{
    Task<ApplicationUser> GetEmpByIdAsync(string empId);
    Task<ApplicationUser> GetEmpByEmailAsync(string email);
    Task<IEnumerable<ApplicationUser>> GetEmpAsync();
    Task<IdentityResult> AddEmpAsync(ApplicationUser emp, string password);
    Task<bool> CheckPasswordAsync(ApplicationUser emp, string password);
}

}

