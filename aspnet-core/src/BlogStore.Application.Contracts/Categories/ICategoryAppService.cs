﻿using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BlogStore.Categories
{
    public interface ICategoryAppService: IApplicationService
    {
        Task<bool> CreateAsync(CreateCategoryDto dto);
    }
}