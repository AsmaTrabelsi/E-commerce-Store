﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {

public static async Task<AppUser> FindUserByClaimsPrincipleWithAddress(this UserManager<AppUser> userManager,
    ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x=>x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            return  await userManager.Users.SingleOrDefaultAsync(x=> x.Email == user.FindFirstValue(ClaimTypes.Email));
        }
    }
}