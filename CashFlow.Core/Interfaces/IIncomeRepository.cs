﻿using CashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IIncomeRepository
    {
        Task AddAsync(Income income, string userId);
        Task<Income> GetByIdAsync(int id, string userId);
        Task<List<Income>> GetAllAsync(string userId, string? filterYear, string? filterMonth);
        Task UpdateAsync(Income income, string userId);
        Task DeleteAsync(Income income, string userId);
    }
}