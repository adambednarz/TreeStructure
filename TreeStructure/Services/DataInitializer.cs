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
            var directories = await _directoryService.GetAllNode();
            if (directories.Any())
            {
                _logger.LogTrace("Data was already initialized.");

                return;
            }

            _logger.LogTrace("Data was already initialized.");

            await _directoryService.CreateAsync("Mój komputer", null);
            await _directoryService.CreateAsync("One Drive", null);
            await _directoryService.CreateAsync("Dyck C", null, "Mój komputer");
            await _directoryService.CreateAsync("Dysk E", null, "Mój komputer");
            await _directoryService.CreateAsync("Dokumenty", null, "Dyck C");
            await _directoryService.CreateAsync("Zdjęcia", null, "Dyck C");
            await _directoryService.CreateAsync("Publikacje", null, "One Drive");
            await _directoryService.CreateAsync("Notatki", null, "One Drive");
            await _directoryService.CreateAsync("Praca", null, "Dokumenty");
            await _directoryService.CreateAsync("Dom", null, "Dokumenty");
            await _directoryService.CreateAsync("Finanse", null, "Dom");
            await _directoryService.CreateAsync("Paragony", null, "Finanse");
            await _directoryService.CreateAsync("Kalendarz", null, "Dom");
            await _directoryService.CreateAsync("Koncerty", null, "Kalendarz");
            await _directoryService.CreateAsync("Pendrive", null);
            await _directoryService.CreateAsync("Projekty It", null, "Praca");
            await _directoryService.CreateAsync("Frontend", null, "Projekty It");
            await _directoryService.CreateAsync("Backend", null, "Projekty It");
            await _directoryService.CreateAsync("Architektura", null, "Backend");
            await _directoryService.CreateAsync("DDD", null, "Architektura");
            await _directoryService.CreateAsync("Onion Architecture", null, "Architektura");

            _logger.LogTrace("Data was initialized.");
        }

    }
}
