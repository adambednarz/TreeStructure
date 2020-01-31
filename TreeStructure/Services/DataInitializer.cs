using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IDirectoryService _directoryService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IDirectoryService directoryService, ILogger<DataInitializer> logger)
        {
            _directoryService = directoryService;
            _logger = logger;
        }


        public async Task SeedAsync()
        {
            var directories = await _directoryService.BrowseAsync();
            if (directories.Any())
            {
                _logger.LogTrace("Data was already initialized.");

                return;
            }

            _logger.LogTrace("Data was already initialized.");

            await  _directoryService.CreateByIdAsync("Mój komputer", null);
            await  _directoryService.CreateByIdAsync("One Drive", null);
            await _directoryService.CreateAsync("Dyck C", "Mój komputer");
            await _directoryService.CreateAsync("Dysk E", "Mój komputer");
            await _directoryService.CreateAsync("Dokumenty", "Dyck C");
            await _directoryService.CreateAsync("Zdjęcia", "Dyck C");
            await _directoryService.CreateAsync("Publikacje", "One Drive");
            await _directoryService.CreateAsync("Notatki", "One Drive");
            await _directoryService.CreateAsync("Praca", "Dokumenty");
            await _directoryService.CreateAsync("Dom", "Dokumenty");
            await _directoryService.CreateAsync("Finanse", "Dom");
            await _directoryService.CreateAsync("Paragony", "Finanse");
            await _directoryService.CreateAsync("Kalendarz", "Dom");
            await _directoryService.CreateAsync("Koncerty", "Kalendarz");
            await _directoryService.CreateByIdAsync("Pendrive", null);
            await _directoryService.CreateAsync("Projekty It", "Praca");
            await _directoryService.CreateAsync("Frontend", "Projekty It");
            await _directoryService.CreateAsync("Backend", "Projekty It");
            await _directoryService.CreateAsync("Architektura", "Backend");
            await _directoryService.CreateAsync("DDD", "Architektura");
            await _directoryService.CreateAsync("Onion Architecture", "Architektura");

            _logger.LogTrace("Data was initialized.");
        }
    }
}
