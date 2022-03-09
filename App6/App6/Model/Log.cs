using SQLite;

namespace App6.Model
{
    class Log
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
