﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace SampleAPI.Services
{
    public abstract class BaseRepository
    {
        private readonly DbConnection _connection;

        protected BaseRepository(DbConnection connection)
        {
            _connection = connection;

        }


        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                await _connection.OpenAsync();

                return await getData(_connection);
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName),
                    ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)",
                        GetType().FullName), ex);
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        protected async Task WithConnection(Func<IDbConnection, Task> getData)
        {
            try
            {
                await _connection.OpenAsync();
                await getData(_connection);
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName),
                    ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)",
                        GetType().FullName), ex);
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        protected async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData,
            Func<TRead, Task<TResult>> process)
        {
            try
            {
                await _connection.OpenAsync();
                var data = await getData(_connection);
                return await process(data);
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName),
                    ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)",
                        GetType().FullName), ex);
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

    }
}
