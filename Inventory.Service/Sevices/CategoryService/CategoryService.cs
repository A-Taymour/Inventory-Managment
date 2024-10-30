using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repositories;

namespace Inventory.Service.Sevices.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly IGenericRepository<Category> _CategoryRepository;

        public CategoryService(IGenericRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _CategoryRepository.GetById(id);
        }

        public void Insert(Category Category)
        {
            _CategoryRepository.Add(Category);
        }

        public void Update(Category Category)
        {
            _CategoryRepository.Update(Category);
        }

        public void Delete(int id)
        {
            _CategoryRepository.Delete(id);
        }
		public string UploadFile(IFormFile file, string FolderName)
		{
			string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\", FolderName);

			string FileName = $"{Guid.NewGuid()}{file.FileName}";

			string FilePath = Path.Combine(FolderPath, FileName);

			using var FileStream = new FileStream(FilePath, FileMode.Create);
			file.CopyTo(FileStream);
			return FileName;
		}

		public void DeleteFile(string FolderName, string FileName)
		{
			string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\", FolderName, FileName);
			if (File.Exists(FilePath))
			{
				File.Delete(FilePath);
			}
		}
	}

}
