using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace UserRelationsDemo;

[Dependency(ReplaceServices = true)]
public class UserRelationsDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UserRelationsDemo";
}
