using Task.Repositories;
using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Inventory.Service.Sevices.UserService
{

    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _UserRepository;

        public UserService(IGenericRepository<User> UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _UserRepository.GetAll();
        }

		public User GetById(string id)
		{
			return _UserRepository.GetById(id);
		}

		public void Insert(User user)
        {
            _UserRepository.Add(user);
        }

        public void Update(User user)
        {
            _UserRepository.Update(user);
        }
		public void Delete(string id)
		{
			_UserRepository.Delete(id);
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