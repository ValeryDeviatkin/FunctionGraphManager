using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Database.Dto;
using Database.Helpers;
using Newtonsoft.Json;
using Unity;
using ViewModels.Graph;
using ViewModels.Interfaces;
using Wpf.Tools.Helpers;

namespace Database.Services
{
    internal class DatabaseService : IDatabaseService
    {
        private const string StoragePath = "AppData";
        private readonly IUnityContainer _container;

        public DatabaseService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public async Task<IEnumerable<GraphViewModel>> GetAllAsync()
        {
            var result = new List<GraphViewModel>();

            if (Directory.Exists(StoragePath))
            {
                var files = Directory.GetFiles(StoragePath);

                foreach (var file in files)
                {
                    if (Guid.TryParse(Path.GetFileName(file), out var id))
                    {
                        try
                        {
                            var filePath = GetFilePath(id);
                            var json = File.ReadAllText(filePath);
                            var dto = JsonConvert.DeserializeObject<GraphDto>(json);
                            _container.Resolve<StateHub>().Save(dto);
                            result.Add(dto.ToViewModel());
                        }
                        catch (Exception e)
                        {
                            this.LogCriticalException(e);
                        }
                    }
                }
            }

            return result;
        }

        public async Task SaveAsync(GraphViewModel item)
        {
            if (!Directory.Exists(StoragePath))
            {
                Directory.CreateDirectory(StoragePath);
            }

            var dto = item.ToDto();
            _container.Resolve<StateHub>().Save(dto);
            var json = JsonConvert.SerializeObject(dto);
            var path = GetFilePath(dto.Id);
            File.WriteAllText(path, json);
        }

        public async Task DeleteAsync(Guid id)
        {
            var path = GetFilePath(id);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            _container.Resolve<StateHub>().Delete(id);
            File.Delete(path);
        }

        private static string GetFilePath(Guid id) => Path.Combine(StoragePath, id.ToString());
    }
}