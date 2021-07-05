using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Model;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
    public class TransferEquipmentRepository
    {
        List<TransferEquipment> transfers = new List<TransferEquipment>();

        public TransferEquipmentRepository()
        {
            readTransferJson();
        }

        public void readTransferJson()
        {
            if (!File.Exists("transfers.json"))
            {
                File.Create("transfers.json").Close();
            }

            using (StreamReader r= new StreamReader("transfers.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    transfers = JsonConvert.DeserializeObject<List<TransferEquipment>>(json);
                }
            }
        }

        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(transfers, Formatting.Indented);
            File.WriteAllText("transfers.json", json);
        }
        public string CreateTransfer(TransferEquipment transfer)
        {
            string message;
            transfers.Add(transfer);
            writeInJson();
            return message = "SUCCEEDED";
        }

        public List<TransferEquipment> ReadAllTransfers()
        {
            return transfers;
        }

        public void DeleteTransfer(int id)
        {
            int index = transfers.FindIndex(obj => obj.id == id);
            transfers.RemoveAt(index);
            writeInJson();
        }
    }
}
