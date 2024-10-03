using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DB.ViewModels.Report
{
    public class CombinedReportViewModel
    {
        public IEnumerable<StockReportViewModel> StockReports { get; set; }
        public IEnumerable<ProductReportViewModel> ProductReports { get; set; }
        public IEnumerable<SupplierReportViewModel> SupplierReports { get; set; }
    }
}
