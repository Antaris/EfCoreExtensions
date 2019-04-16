// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace EFCoreExtensions.Materialization
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// Provides a base implementation of a <see cref="IEntityMaterializerSourceHook"/>.
    /// </summary>
    public class EntityMaterializerSourceHook : IEntityMaterializerSourceHook
    {
        /// <inheritdoc />
        public virtual Expression CreateMaterializeExpression(IEntityType entityType, Expression valueBuffer, int[] indexMap, MaterializerExpressionFactory defaultFactory)
            => null;

        /// <inheritdoc />
        public virtual Expression CreateReadValueExpression(Expression valueBuffer, Type type, int index, IPropertyBase property, ReadValueExpressionFactory defaultFactory)
            => null;
    }
}
