using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Interfaces
{
    public interface IEditProductViewModelService
    {
        Task<EditProductViewModel> GetEditProductViewModelAsync(int id);
    }
}
