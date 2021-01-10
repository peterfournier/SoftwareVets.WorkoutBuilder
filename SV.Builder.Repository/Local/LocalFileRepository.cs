using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SV.Builder.Repository
{
    public class LocalFileRepository : IRepository<int>
    {
        private string _fileName = "data-sv-builder.txt";
        private readonly string _appName;

        public LocalFileRepository()
        {
            _appName = typeof(LocalFileRepository).Assembly.FullName;
        }

        #region IRepository
        public ICollection<TModel> Get<TModel>()
            where TModel : new()
        {
            ICollection<TModel> collection = new List<TModel>();
            try
            {
                using (StreamReader sr = getStreamReaderForFileLocalFile())
                {
                    var line = sr.ReadLine();

                    while (line != null)
                    {
                        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(line);

                        collection.Add(model);

                        line = sr.ReadLine();
                    }
                }

                return collection;
            }
            catch (Exception)
            {
                return collection;
            }
        }

        public TModel Get<TModel>(int identity)
            where TModel : IdentityModel<int>, new()
        {
            TModel entity = null;
            try
            {
                using (StreamReader sr = getStreamReaderForFileLocalFile())
                {
                    var line = sr.ReadLine();

                    while (line != null && entity == null)
                    {
                        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(line);
                            if (model?.ID == identity)
                                entity = model;

                        line = sr.ReadLine();
                    }
                }
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TModel Update<TModel>(TModel entityToUpdate)
            where TModel : IdentityModel<int>, new()
        {
            try
            {
                var entity = Get<TModel>(entityToUpdate.ID);

                string file = File.ReadAllText(getFilePath());
                
                file = file.Replace(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(entityToUpdate));
                
                File.WriteAllText(getFilePath(), file);

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Remove<TModel>(TModel entityToRemove)
            where TModel : IdentityModel<int>, new()
        {
            try
            {
                string tempFile = Path.GetTempFileName();

                var filePath = getFilePath();
                using (var sr = new StreamReader(filePath))
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != JsonConvert.SerializeObject(entityToRemove))
                            sw.WriteLine(line);
                    }
                }

                File.Delete(filePath);
                File.Move(tempFile, filePath);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Create(object obj)
        {
            try
            {
                var filePath = getFilePath();
                using (StreamWriter outputFile = new StreamWriter(filePath, append: true))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    outputFile.WriteLine(json);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        private StreamReader getStreamReaderForFileLocalFile()
        {
            return new StreamReader(getFilePath());
        }

        private string getFilePath()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            return Path.Combine(path, _fileName);
        }

    }
}
