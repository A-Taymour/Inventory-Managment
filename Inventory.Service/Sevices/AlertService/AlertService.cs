using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repositories;

namespace Inventory.Service.Sevices.AlertService
{
    public class AlertService : IAlertService
    {
        private readonly IGenericRepository<Alert> _alertRepository;

        public AlertService(IGenericRepository<Alert> AlertRepository)
        {
            _alertRepository = AlertRepository;
        }

        public IEnumerable<Alert> GetAll()
        {
            return _alertRepository.GetAll();
        }

        public Alert GetById(int id)
        {
            return _alertRepository.GetById(id);
        }


        /*
         When withdrawing a product, we check the count, if its lower than stocklowlevel
         we create an alert using MakeAlert method in controller, u can place it f ay 7eta
         then pass the created Object to Insert x
                                                |
                                                v
         */
        public void Insert(Alert alert)
        {
            _alertRepository.Add(alert);
        }

        public void Update(Alert alert)
        {
            _alertRepository.Update(alert);
        }

        public void Delete(int id)
        {
            _alertRepository.Delete(id);
        }
    }
}
