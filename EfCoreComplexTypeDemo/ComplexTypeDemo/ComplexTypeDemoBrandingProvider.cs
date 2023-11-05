using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ComplexTypeDemo;

[Dependency(ReplaceServices = true)]
public class ComplexTypeDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ComplexTypeDemo";
}
