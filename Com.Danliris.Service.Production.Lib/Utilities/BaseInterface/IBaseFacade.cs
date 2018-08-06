﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Production.Lib.Utilities.BaseInterface
{
    public interface IBaseFacade<TModel>
    {
        ReadResponse<TModel> Read(int page, int size, string order, List<string> select, string keyword, string filter);
        Task<int> Create(TModel model);
        Task<TModel> ReadById(int id);
        Task<int> Update(int id, TModel model);
        Task<int> Delete(int id);
    }
}
