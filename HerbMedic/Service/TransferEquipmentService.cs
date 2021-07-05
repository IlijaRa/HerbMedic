using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Repository;
using Classes.Model;

namespace Classes.Service
{
    public class TransferEquipmentService
    {
        TransferEquipmentRepository transferRepository = new TransferEquipmentRepository();

        public string CreateTransfer(TransferEquipment transfer)
        {
            return transferRepository.CreateTransfer(transfer);
        }

        public int GenerateId()
        {
            List<TransferEquipment> transfers = transferRepository.ReadAllTransfers();
            try
            {
                int maxId = transfers.Max(obj => obj.id);
                return maxId + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
