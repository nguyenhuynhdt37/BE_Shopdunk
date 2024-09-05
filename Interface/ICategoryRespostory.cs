using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Shopdunk.Interface
{
    public interface ICategoryRespostory
    {
        public Task<string?> CategoryCreateAsync(string name);
    }
}