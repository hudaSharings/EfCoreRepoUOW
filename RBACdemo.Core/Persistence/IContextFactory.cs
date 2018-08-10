using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core.Persistence
{
   public interface IContextFactory
    {
        DbContext DbContext { get; }
    }
}
