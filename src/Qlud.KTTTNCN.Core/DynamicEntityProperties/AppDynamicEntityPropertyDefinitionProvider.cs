using Abp.DynamicEntityProperties;
using Abp.UI.Inputs;
using Qlud.KTTTNCN.Authorization.Users;
using Qlud.KTTTNCN.CustomInputTypes;

namespace Qlud.KTTTNCN.DynamicEntityProperties
{
    public class AppDynamicEntityPropertyDefinitionProvider : DynamicEntityPropertyDefinitionProvider
    {
        public override void SetDynamicEntityProperties(IDynamicEntityPropertyDefinitionContext context)
        {
            context.Manager.AddAllowedInputType<SingleLineStringInputType>();
            context.Manager.AddAllowedInputType<ComboboxInputType>();
            context.Manager.AddAllowedInputType<CheckboxInputType>();
            context.Manager.AddAllowedInputType<MultiSelectComboboxInputType>();

            //Add entities here 
            context.Manager.AddEntity<User, long>();
        }
    }
}
