﻿using BenTechAPI.Data;
using BenTechAPI.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.UserEnpoint.UserGetAllEndpoint
{
    public class UserGetAllEndpoint : EndpointWithoutRequest<List<User>>
    {
        private readonly ApplicationDBContext _context;

        public UserGetAllEndpoint(ApplicationDBContext context)
        {
            _context = context;
        }
        public override void Configure()
        {
            Get("api/users");
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var users = await _context.User.ToListAsync();
            await SendAsync(users, cancellation: ct);
        }
    }
}
