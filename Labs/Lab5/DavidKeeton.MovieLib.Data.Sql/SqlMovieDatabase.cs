using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib.Data.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        private readonly string _connectionString;

        public SqlMovieDatabase( string connectionString )
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));

            _connectionString = connectionString;
        }

        protected override int AddCore( Movie movie )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", movie.Title);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@length", movie.Length);               

                var parm = cmd.CreateParameter();
                parm.ParameterName = "@isOwned";
                parm.DbType = System.Data.DbType.Boolean;
                parm.Value = movie.Owned;
                cmd.Parameters.Add(parm);

                conn.Open();
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                movie.Id = id;
            };

            return movie.Id;
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            var items = new List<Movie>();

            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                var ds = new DataSet();

                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                if (ds.Tables.Count == 1)
                {
                    foreach (var row in ds.Tables[0].Rows.OfType<DataRow>())
                    {
                        var movie = new Movie() {
                            Id = Convert.ToInt32(row["Id"]),
                            Title = row.Field<string>("Title"),
                            Description = row.Field<string>("Description"),
                            Length = row.Field<int>("Length"),
                            Owned = row.Field<bool>("IsOwned"),
                        };

                        items.Add(movie);
                    };
                };
            };

            return items;
        }

        protected override Movie GetCore( int id )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return ReadData(reader);
                };
            };

            return null;
        }

        protected override Movie GetMovieByTitleCore( string title )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = ReadData(reader);

                        if (String.Compare(movie.Title, title, true) == 0)

                            return movie;
                    };
                };
            };

            return null;
        }

        private static Movie ReadData( SqlDataReader reader )
        {
            return new Movie() {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader.GetFieldValue<string>(1),
                Description = reader.GetString(2),
                Length = reader.GetInt32(3),                
                Owned = reader.GetBoolean(4)
            };
        }

        protected override void RemoveCore( int id )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("RemoveMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        protected override void UpdateCore( Movie movie )
        {

            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", movie.Id));
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@title", movie.Title);               
                cmd.Parameters.AddWithValue("@length", movie.Length);
                

                var parm = cmd.CreateParameter();
                parm.ParameterName = "@isOwned";
                parm.DbType = System.Data.DbType.Boolean;
                parm.Value = movie.Owned;
                cmd.Parameters.Add(parm);

                conn.Open();
                cmd.ExecuteNonQuery();
            };

            //return movie;
        }
    }
}
