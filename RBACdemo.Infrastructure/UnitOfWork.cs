using RBACdemo.Core;
using RBACdemo.Core.Repositories;
using RBACdemo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContextFactory _context;

        public UnitOfWork(IContextFactory context)
        {
            _context = context ;
        }
       
        public IUserRepository User {  get => new UserRepository(_context); }

        public IRoleRepository Role => new RoleRepository(_context);
        
        public IMenuItemRepository MenuItem =>  new MenuItemRepository(_context);

        public int Complete()
        => _context.DbContext.SaveChanges();
        
        public void Dispose()
        =>_context.DbContext.Dispose();
        
    }
}
