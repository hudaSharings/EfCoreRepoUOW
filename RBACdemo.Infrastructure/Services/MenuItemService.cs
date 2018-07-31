using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Services
{
    public class MenuItemService : Service<MenuItem>,IMenuItemService
    {
        public IMenuItemRepository _repository { get; }
        public MenuItemService(IMenuItemRepository repository) : base(repository)
        {
            _repository = repository;
        }


    }
}
