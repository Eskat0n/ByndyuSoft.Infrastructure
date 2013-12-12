﻿namespace Codeparts.Frameplate.Dapper
{
    using System.Data;

    /// <summary>
    ///     Factory for <see cref="IDbConnection" />
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        ///     Create <see cref="IDbConnection" />
        /// </summary>
        IDbConnection Create(string connectionStringName = null);
    }
}