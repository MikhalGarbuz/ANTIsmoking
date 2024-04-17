using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANTIsmoking.Data;
using ANTIsmoking.Models;

namespace ANTIsmoking.Scan
{
    public class ScanToDb
    {
        ChDbContext db = new ChDbContext();
        string filePath = "C:\\Users\\meine Laptop\\Desktop\\myProjects\\ChaserBot\\ANTIsmoking\\ANTIsmoking\\ChaserFile.txt";
        public async Task TxtToDb()
        {
            List<Chaser> data = new List<Chaser>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('/');
                    string name = parts[0].Trim();
                    int num3 = int.Parse(parts[1].Trim());
                    int num8 = int.Parse(parts[2].Trim());
                    int num11 = int.Parse(parts[3].Trim());
                    int num12 = int.Parse(parts[4].Trim());
                    int num14 = int.Parse(parts[5].Trim());

                    data.Add(new Chaser { name = name, cum3 = num3, cum8 = num8, cum11 = num11, cum12 = num12, cum14 = num14});
                }
            }
            db.InsertComm(data);
        }
        //public async Task MessageToDb()
        //{

        //}
    }
}
