﻿using Task.Repositories;
using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Inventory.Service.Sevices.ProductService
{

    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        public IEnumerable<Product> GetByCategoryId(int Categoryid)
        {
            return _productRepository.Find(x=>x.CategoryID== Categoryid);
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
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