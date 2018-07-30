using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core
{
   public interface IContextFactory
    {
        DbContext DbContext { get; }
    }
}
