using RBACdemo.Infrastructure.Core;
using RBACdemo.Infrastructure.Core.Repositories;
using RBACdemo.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RBACdemoContext _context;

        public UnitOfWork(RBACdemoContext context)
        {
            _context = context;
        }
       
        public IUserRepository User {  get => new UserRepository(_context); }

        public IRoleRepository Role => new RoleRepository(_context);
        
        public IMenuItemRepository MenuItem =>  new MenuItemRepository(_context);

        public int Complete()
        => _context.SaveChanges();
        
        public void Dispose()
        =>_context.Dispose();
        
    }
}
