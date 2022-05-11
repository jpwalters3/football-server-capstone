using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FootballServerCapstone.DAL.Tests
{
    internal static class Proceedures
    {
        internal static void SetGoodState()
        {
            using (var conn = new SqlConnection(new DbFactory(new ConfigProvider().Config).GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("SetKnownGoodState", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
