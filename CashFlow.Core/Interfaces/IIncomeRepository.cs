﻿using CashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IIncomeRepository
    {
        Task AddAsync(Income income);
        Task<Income> GetByIdAsync(int id, string userId);
        Task<List<Income>> GetAllByMonthAsync(string userId, string filterYear, string filterMonth);
        Task<List<Income>> GetAllByYearAsync(string userId, string filterYear);
        Task UpdateAsync(Income income);
        Task DeleteAsync(Income income);
    }
}
