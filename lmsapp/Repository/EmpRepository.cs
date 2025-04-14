using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lmsapp.IRepo;
using Microsoft.AspNetCore.Identity;

namespace lmsapp.Repository
{
    public class EmpRepository : IEmpRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmpRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddEmpAsync(ApplicationUser emp, string password)
        {
            return await _userManager.CreateAsync(emp, password);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser emp, string password)
        {
            return await _userManager.CheckPasswordAsync(emp, password);
        }

        public Task<IEnumerable<ApplicationUser>> GetEmpAsync()
        {
            return Task.FromResult<IEnumerable<ApplicationUser>>(_userManager.Users.ToList());
        }

        public async Task<ApplicationUser> GetEmpByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetEmpByIdAsync(string empId)
        {
            return await _userManager.FindByIdAsync(empId);
        }
    }
}
