/*
 * Author: Kishore Reddy
 * Url: http://commonlibrarynet.codeplex.com/
 * Title: CommonLibrary.NET
 * Copyright: � 2009 Kishore Reddy
 * License: LGPL License
 * LicenseUrl: http://commonlibrarynet.codeplex.com/license
 * Description: A C# based .NET 3.5 Open-Source collection of reusable components.
 * Usage: Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using ComLib.Entities;
using ComLib.Data;
using ComLib.LocationSupport;



namespace ComLib.Web.Modules.Flags
{
    /// <summary>
    /// Generic repository for persisting Flag.
    /// </summary>
    public partial class FlagRepository : RepositorySql<Flag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamedQueryRepository"/> class.
        /// </summary>
        public FlagRepository() { }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TId, T&gt;"/> class.
        /// </summary>
        /// <param name="connectionInfo">The connection string.</param>
        public  FlagRepository(string connectionString) : base(connectionString)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TId, T&gt;"/> class.
        /// </summary>
        /// <param name="connectionInfo">The connection info.</param>
        /// <param name="helper">The helper.</param>
        public FlagRepository(ConnectionInfo connectionInfo) : base(connectionInfo)
        {            
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TId, T&gt;"/> class.
        /// </summary>
        /// <param name="connectionInfo">The connection info.</param>
        /// <param name="helper">The helper.</param>
        public FlagRepository(ConnectionInfo connectionInfo, IDatabase db)
            : base(connectionInfo, db)
        {
        }


        /// <summary>
        /// Initialize the rowmapper
        /// </summary>
        public override void Init(ConnectionInfo connectionInfo, IDatabase db)
        {
            base.Init(connectionInfo, db);
            this.RowMapper = new FlagRowMapper();
        }


        /// <summary>
        /// Create the entity using sql.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Flag Create(Flag entity)
        {
            string sql = "insert into Flags ( [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [UpdateComment], [AppId]"
			 + ", [Title], [RefId], [FlagType], [Model], [Url], [FlaggedByUser]"
			 + ", [FlaggedDate] ) values ( @CreateDate, @UpdateDate, @CreateUser, @UpdateUser, @UpdateComment, @AppId"
			 + ", @Title, @RefId, @FlagType, @Model, @Url, @FlaggedByUser"
			 + ", @FlaggedDate );" + IdentityStatement;;
            var dbparams = BuildParams(entity);            
            object result = _db.ExecuteScalarText(sql, dbparams);
            entity.Id = Convert.ToInt32(result);
            return entity;
        }


        /// <summary>
        /// Update the entity using sql.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Flag Update(Flag entity)
        {
            string sql = "update Flags set [CreateDate] = @CreateDate, [UpdateDate] = @UpdateDate, [CreateUser] = @CreateUser, [UpdateUser] = @UpdateUser, [UpdateComment] = @UpdateComment, [AppId] = @AppId"
			 + ", [Title] = @Title, [RefId] = @RefId, [FlagType] = @FlagType, [Model] = @Model, [Url] = @Url, [FlaggedByUser] = @FlaggedByUser"
			 + ", [FlaggedDate] = @FlaggedDate where Id = " + entity.Id;
            var dbparams = BuildParams(entity); 
            _db.ExecuteNonQueryText(sql, dbparams);
            return entity;
        }


        public override Flag Get(int id)
        {
            Flag entity = base.Get(id);
            
            return entity;
        }


        protected virtual DbParameter[] BuildParams(Flag entity)
        {
            var dbparams = new List<DbParameter>();
            			dbparams.Add(BuildParam("@CreateDate", SqlDbType.DateTime, entity.CreateDate));
			dbparams.Add(BuildParam("@UpdateDate", SqlDbType.DateTime, entity.UpdateDate));
			dbparams.Add(BuildParam("@CreateUser", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.CreateUser) ? "" : entity.CreateUser));
			dbparams.Add(BuildParam("@UpdateUser", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.UpdateUser) ? "" : entity.UpdateUser));
			dbparams.Add(BuildParam("@UpdateComment", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.UpdateComment) ? "" : entity.UpdateComment));
			dbparams.Add(BuildParam("@AppId", SqlDbType.Int, entity.AppId));
			dbparams.Add(BuildParam("@Title", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.Title) ? "" : entity.Title));
			dbparams.Add(BuildParam("@RefId", SqlDbType.Int, entity.RefId));
			dbparams.Add(BuildParam("@FlagType", SqlDbType.Int, entity.FlagType));
			dbparams.Add(BuildParam("@Model", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.Model) ? "" : entity.Model));
			dbparams.Add(BuildParam("@Url", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.Url) ? "" : entity.Url));
			dbparams.Add(BuildParam("@FlaggedByUser", SqlDbType.NVarChar, string.IsNullOrEmpty(entity.FlaggedByUser) ? "" : entity.FlaggedByUser));
			dbparams.Add(BuildParam("@FlaggedDate", SqlDbType.DateTime, entity.FlaggedDate));

            return dbparams.ToArray();
        }


        protected virtual DbParameter BuildParam(string name, SqlDbType dbType, object val)
        {
            var param = new SqlParameter(name, dbType);
            param.Value = val;
            return param;
        }

    }


    
    /// <summary>
    /// RowMapper for Flag.
    /// </summary>
    /// <typeparam name="?"></typeparam>
    public partial class FlagRowMapper : EntityRowMapper<Flag>, IEntityRowMapper<Flag>
    {
        public override Flag MapRow(IDataReader reader, int rowNumber)
        {
            Flag entity =  _entityFactoryMethod == null ? Flag.New() : _entityFactoryMethod(reader);
            			entity.Id = reader["Id"] == DBNull.Value ? 0 : (int)reader["Id"];
			entity.CreateDate = reader["CreateDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["CreateDate"];
			entity.UpdateDate = reader["UpdateDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["UpdateDate"];
			entity.CreateUser = reader["CreateUser"] == DBNull.Value ? string.Empty : reader["CreateUser"].ToString();
			entity.UpdateUser = reader["UpdateUser"] == DBNull.Value ? string.Empty : reader["UpdateUser"].ToString();
			entity.UpdateComment = reader["UpdateComment"] == DBNull.Value ? string.Empty : reader["UpdateComment"].ToString();
			entity.AppId = reader["AppId"] == DBNull.Value ? 0 : (int)reader["AppId"];
			entity.Title = reader["Title"] == DBNull.Value ? string.Empty : reader["Title"].ToString();
			entity.RefId = reader["RefId"] == DBNull.Value ? 0 : (int)reader["RefId"];
			entity.FlagType = reader["FlagType"] == DBNull.Value ? 0 : (int)reader["FlagType"];
			entity.Model = reader["Model"] == DBNull.Value ? string.Empty : reader["Model"].ToString();
			entity.Url = reader["Url"] == DBNull.Value ? string.Empty : reader["Url"].ToString();
			entity.FlaggedByUser = reader["FlaggedByUser"] == DBNull.Value ? string.Empty : reader["FlaggedByUser"].ToString();
			entity.FlaggedDate = reader["FlaggedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["FlaggedDate"];

            return entity;
        }
    }
}