using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MagazineEchipamente.Models;

namespace MagazineEchipamente.Data
{
    public class EchipamenteDatabase
    {
        //Aceasta clasa va contine cod pentru crearea, citirea, srierea si stergerea datelor
        //Utilizam API-r SQLite asincrone pentru a pune operatiile pe baza de date in thread-uri de background
        //Constructorul a estei clase ia ca si argument calea catre fisierul de tip baza de date 
        // => aceasta cale este furnizata de clasa App in pasul urmator

        readonly SQLiteAsyncConnection _database;
        public EchipamenteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Magazin>().Wait();
            _database.CreateTableAsync<Echipament>().Wait();
            _database.CreateTableAsync<ListaMagazine>().Wait();
        }

        public Task<int> SaveEchipamentAsync(Echipament Echipament)
        {
            if (Echipament.ID != 0)
            {
                return _database.UpdateAsync(Echipament);
            }
            else
            {
                return _database.InsertAsync(Echipament);
            }
        }
        public Task<int> DeleteEchipamentAsync(Echipament Echipament)
        {
            return _database.DeleteAsync(Echipament);
        }
        public Task<List<Echipament>> GetEchipamentsAsync()

        {
            return _database.Table<Echipament>().ToListAsync();
        }
    
       public Task<List<Magazin>> GetMagazinsAsync()
        {
            return _database.Table<Magazin>().ToListAsync();
        }
        public Task<Magazin> GetMagazinAsync(int id)
        {
            return _database.Table<Magazin>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveMagazinAsync(Magazin slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);

            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteMagazinAsync(Magazin slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> DeleteListaMagazineAsync(ListaMagazine listp)
        {
            return _database.DeleteAsync(listp);
        }

        public Task<List<ListaMagazine>> GetListaMagazines()
        {
            return _database.QueryAsync<ListaMagazine>("select * from ListaMagazine");
        }


        public Task<int> SaveListaMagazineAsync(ListaMagazine listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Echipament>> GetListaMagazinesAsync(int Magazinid)
        {
            return _database.QueryAsync<Echipament>(
            "select P.ID, P.Description from Echipament P"
            + " inner join ListaMagazine LP"
            + " on P.ID = LP.EchipamentID where LP.MagazinID = ?",
            Magazinid);
        }

    }

}
