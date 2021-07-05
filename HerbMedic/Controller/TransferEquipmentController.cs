using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Service;
using Classes.Model;

namespace Classes.Controller
{

    public class TransferEquipmentController
    {
        TransferEquipmentService transferService = new TransferEquipmentService();

        public string CreateTransfer(TransferEquipment transfer)
        {
            return transferService.CreateTransfer(transfer);
        }

        public int GenerateId()
        {
            return transferService.GenerateId();
        }
    }
}
