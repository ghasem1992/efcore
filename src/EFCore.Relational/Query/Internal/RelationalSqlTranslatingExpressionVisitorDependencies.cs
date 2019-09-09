// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore.Query
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="RelationalSqlTranslatingExpressionVisitorFactory" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    ///     <para>
    ///         Do not construct instances of this class directly from either provider or application code as the
    ///         constructor signature may change as new dependencies are added. Instead, use this type in
    ///         your constructor so that an instance will be created and injected automatically by the
    ///         dependency injection container. To create an instance with some dependent services replaced,
    ///         first resolve the object from the dependency injection container, then replace selected
    ///         services using the 'With...' methods. Do not call the constructor at any point in this process.
    ///     </para>
    ///     <para>
    ///         The service lifetime is <see cref="ServiceLifetime.Singleton" />. This means a single instance
    ///         is used by many <see cref="DbContext" /> instances. The implementation must be thread-safe.
    ///         This service cannot depend on services registered as <see cref="ServiceLifetime.Scoped" />.
    ///     </para>
    /// </summary>
    public sealed class RelationalSqlTranslatingExpressionVisitorDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="RelationalSqlTranslatingExpressionVisitorFactory" />.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from either provider or application code as it may change
        ///         as new dependencies are added. Instead, use this type in your constructor so that an instance
        ///         will be created and injected automatically by the dependency injection container. To create
        ///         an instance with some dependent services replaced, first resolve the object from the dependency
        ///         injection container, then replace selected services using the 'With...' methods. Do not call
        ///         the constructor at any point in this process.
        ///     </para>
        ///     <para>
        ///         This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///         the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///         any release. You should only use it directly in your code with extreme caution and knowing that
        ///         doing so can result in application failures when updating to a new Entity Framework Core release.
        ///     </para>
        /// </summary>
        [EntityFrameworkInternal]
        public RelationalSqlTranslatingExpressionVisitorDependencies(
            [NotNull] ISqlExpressionFactory sqlExpressionFactory,
            [NotNull] IMemberTranslatorProvider memberTranslatorProvider,
            [NotNull] IMethodCallTranslatorProvider methodCallTranslatorProvider)
        {
            Check.NotNull(sqlExpressionFactory, nameof(sqlExpressionFactory));
            Check.NotNull(memberTranslatorProvider, nameof(memberTranslatorProvider));
            Check.NotNull(methodCallTranslatorProvider, nameof(methodCallTranslatorProvider));

            SqlExpressionFactory = sqlExpressionFactory;
            MemberTranslatorProvider = memberTranslatorProvider;
            MethodCallTranslatorProvider = methodCallTranslatorProvider;
        }

        /// <summary>
        ///     The expression factory..
        /// </summary>
        public ISqlExpressionFactory SqlExpressionFactory { get; }

        /// <summary>
        ///     The member translation provider.
        /// </summary>
        public IMemberTranslatorProvider MemberTranslatorProvider { get; }

        /// <summary>
        ///     The method-call translation provider.
        /// </summary>
        public IMethodCallTranslatorProvider MethodCallTranslatorProvider { get; }

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="sqlExpressionFactory"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public RelationalSqlTranslatingExpressionVisitorDependencies With([NotNull] ISqlExpressionFactory sqlExpressionFactory)
            => new RelationalSqlTranslatingExpressionVisitorDependencies(
                sqlExpressionFactory, MemberTranslatorProvider, MethodCallTranslatorProvider);

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="memberTranslatorProvider"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public RelationalSqlTranslatingExpressionVisitorDependencies With([NotNull] IMemberTranslatorProvider memberTranslatorProvider)
            => new RelationalSqlTranslatingExpressionVisitorDependencies(
                SqlExpressionFactory, memberTranslatorProvider, MethodCallTranslatorProvider);

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="methodCallTranslatorProvider"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public RelationalSqlTranslatingExpressionVisitorDependencies With(
            [NotNull] IMethodCallTranslatorProvider methodCallTranslatorProvider)
            => new RelationalSqlTranslatingExpressionVisitorDependencies(
                SqlExpressionFactory, MemberTranslatorProvider, methodCallTranslatorProvider);
    }
}
