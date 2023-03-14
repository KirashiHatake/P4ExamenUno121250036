using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P4ExamenUno121250036.Controllers
{
    public class LocalizacionControl
    {

        readonly SQLiteAsyncConnection _connection;
        // Constructor de clase
        public LocalizacionControl(string DBPath)
        {
            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<Models.Localizacion>();
        }

        // CRUD - Create - Read - Update - Delete

        // Create / Update
        public Task<int> SaveGeo(Models.Localizacion posicion)
        {
            if (posicion.Id != 0)
                return _connection.UpdateAsync(posicion);
            else
                return _connection.InsertAsync(posicion);
        }

        //Read one una localizacion
        public Task<Models.Localizacion> GetGeo(int pid)
        {
            return _connection.Table<Models.Localizacion>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        // Read para toda la lista de Localizaciones
        public Task<List<Models.Localizacion>> GetListLocalizacion()
        {
            return _connection.Table<Models.Localizacion>().ToListAsync();
        }

        //Delete 
        public Task<int> DeleteLocalizaciones(Models.Localizacion posicion)
        {
            return _connection.DeleteAsync(posicion);
        }
    }
}
