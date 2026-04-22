using Soenneker.Cloudflare.Security.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cloudflare.Security.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CloudflareSecurityUtilTests : HostedUnitTest
{
    private readonly ICloudflareSecurityUtil _util;

    public CloudflareSecurityUtilTests(Host host) : base(host)
    {
        _util = Resolve<ICloudflareSecurityUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
