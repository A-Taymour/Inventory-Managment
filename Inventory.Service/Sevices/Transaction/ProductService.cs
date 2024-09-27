﻿using Task.Repositories;
using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Service.Sevices.TransactionService
{

    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _TransactionRepository;

        public TransactionService(IGenericRepository<Transaction> transactionRepository)
        {
            _TransactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _TransactionRepository.GetAll();
        }

        public Transaction GetById(int id)
        {
            return _TransactionRepository.GetById(id);
        }

        public void Insert(Transaction product)
        {
            _TransactionRepository.Add(product);
        }

        public void Update(Transaction product)
        {
            _TransactionRepository.Update(product);
        }

        public void Delete(int id)
        {
            _TransactionRepository.Delete(id);
        }
    }
}