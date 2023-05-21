﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Jamiat_web.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Jamiat_web.Models
{
    public partial class JamiatContext
    {
        private IJamiatContextProcedures _procedures;

        public virtual IJamiatContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new JamiatContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IJamiatContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetHalqaMembersResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetMenusResult>().HasNoKey().ToView(null);
        }
    }

    public partial class JamiatContextProcedures : IJamiatContextProcedures
    {
        private readonly JamiatContext _context;

        public JamiatContextProcedures(JamiatContext context)
        {
            _context = context;
        }

        public virtual async Task<List<GetHalqaMembersResult>> GetHalqaMembersAsync(string halqaId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "halqaId",
                    Size = 50,
                    Value = halqaId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetHalqaMembersResult>("EXEC @returnValue = [dbo].[GetHalqaMembers] @halqaId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetMenusResult>> GetMenusAsync(int? UserId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = UserId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetMenusResult>("EXEC @returnValue = [dbo].[GetMenus] @UserId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
