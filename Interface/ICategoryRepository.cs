using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Shopdunk.Interface
{
    public interface ICategoryRepository
    {
        public Task<bool> isCategoryAsync(string name);
        public Task CategoryCreateAsync(string name, string user_id);
    }

}