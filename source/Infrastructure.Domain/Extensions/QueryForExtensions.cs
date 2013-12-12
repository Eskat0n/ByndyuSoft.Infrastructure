﻿namespace Codeparts.Frameplate.Domain.Extensions
{
    using Criteria;
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    [PublicAPI]
    public static class QueryForExtensions
    {
        /// <summary>
        ///     Добавить критерий для поиска доменной сущности по идентификатору
        /// </summary>
        /// <param name="queryFor"></param>
        /// <param name="id">Идентификатор доменной сущности</param>
        /// <returns>Возвращает найденную доменную сущность, либо null</returns>
        [PublicAPI]
        [CanBeNull]
        public static TResult ById<TResult>(this IQueryFor<TResult> queryFor, int id)
        {
            return queryFor.With(new FindById(id));
        }

        /// <summary>
        ///     Добавить критерий для поиска всех объектов данного типа
        /// </summary>
        /// <returns>Возвращает найденную доменную сущность, либо null</returns>
        [PublicAPI]
        [CanBeNull]
        public static TResult All<TResult>(this IQueryFor<TResult> queryFor)
        {
            return queryFor.With(new AllEntities());
        }
    }
}