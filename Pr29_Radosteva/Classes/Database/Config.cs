using Microsoft.EntityFrameworkCore;

namespace Pr29_Radosteva.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=localhost;uid=root;pwd=;database=pr29;";
        public static MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
