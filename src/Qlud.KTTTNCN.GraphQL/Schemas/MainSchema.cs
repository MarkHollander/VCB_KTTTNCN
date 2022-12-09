using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Qlud.KTTTNCN.Queries.Container;
using System;

namespace Qlud.KTTTNCN.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}