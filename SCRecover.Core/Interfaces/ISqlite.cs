using SQLite.Net;


namespace SCRecover.Core.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
