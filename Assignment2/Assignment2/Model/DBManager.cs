using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace Assignment2.Model
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        public ObservableCollection<BodiesData> favourites;

        public DBManager() {
            _connection = DependencyService.Get<ISOLiteDb>().GetConnection();
        }

        public async Task<ObservableCollection<BodiesData>> CreateTable() {
            await _connection.CreateTableAsync<BodiesData>();
            var bodies = await _connection.Table<BodiesData>().ToListAsync();
            favourites = new ObservableCollection<BodiesData>(bodies);
            return favourites;
        }

        public void addFavourite(BodiesData body) {
            favourites.Add(body);
            _connection.InsertAsync(body);
        }

        public void deleteFavourite(BodiesData body)
        {
            favourites.Remove(body);
            _connection.DeleteAsync(body);
        }

        public void updateFavourite(BodiesData body)
        {
            var updatedBody = favourites.FirstOrDefault(f => f.id == body.id);
            updatedBody = body;
            _connection.UpdateAsync(updatedBody);

        }
    }
}
