using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    public interface IListViewModelService
    {
        Task<ListViewModel> GetListViewModelAsync(string category, string brand, string style, int page);
    }
}
