using disaster_management.Models;
using disaster_management.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DaDManagementContext _context;
        private readonly IServiceProvider _serviceProvider;

        private IDiseaseTypeService? _diseaseService;

        public UnitOfWork(DaDManagementContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IDiseaseTypeService Diseases => _diseaseService ??= _serviceProvider.GetRequiredService<IDiseaseTypeService>();

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
