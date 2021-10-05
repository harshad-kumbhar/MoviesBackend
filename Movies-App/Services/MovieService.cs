using Movies-App.Entities;
using Movies-App.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Movies-App.Services
{
    public class JobService : IJobService
    {
        private readonly IDapperHelper _dapperHelper;

        public JobService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        public int Create(Movie movie)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Name", movie.Name, DbType.String);
            dbPara.Add("Type", movie.Type, DbType.String);
            dbPara.Add("PublishedDate", movie.PublishedDate, DbType.String);
            dbPara.Add("IsLike", movie.IsLike, DbType.Boolean);
            dbPara.Add("Rating", movie.Rating, DbType.Int);

            #region using dapper  
            var data = _dapperHelper.Insert<int>("[dbo].[SP_Add_Job]",
                            dbPara,
                            commandType: CommandType.StoredProcedure);
            return data;
            #endregion

        }

        public Job GetByJobId(int JobId)
        {
            #region using dapper  
            var data = _dapperHelper.Get<Job>($"select * from job  where JobId={JobId}", null,
                    commandType: CommandType.Text);
            return data;
            #endregion


        }

        public int Delete(int JobId)
        {
            var data = _dapperHelper.Execute($"Delete [Job] where JObId={JobId}", null,
                    commandType: CommandType.Text);
            return data;
        }

        public List<Job> ListAll()
        {
            var data = _dapperHelper.GetAll<Job>("[dbo].[SP_Job_List]", null, commandType: CommandType.StoredProcedure);
            return data.ToList();

        }

        public string Update(Job job)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("JobTitle", job.JobTitle, DbType.String);
            dbPara.Add("JobId", job.JobID);
            dbPara.Add("JobImage", job.JobImage, DbType.String);
            dbPara.Add("CityId", job.CityId, DbType.Int32);
            dbPara.Add("IsActive", job.IsActive, DbType.String);
            dbPara.Add("UpdatedBY", "1", DbType.String);
            dbPara.Add("UpdatedDateTime", DateTime.Now, DbType.DateTime);


            var data = _dapperHelper.Update<string>("[dbo].[SP_Update_Job]",
                            dbPara,
                            commandType: CommandType.StoredProcedure);
            return data;


        }
    }
}