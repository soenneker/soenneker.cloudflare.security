using Soenneker.Cloudflare.Security.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cloudflare.Security.Tests;

[Collection("Collection")]
public sealed class CloudflareSecurityUtilTests : FixturedUnitTest
{
    private readonly ICloudflareSecurityUtil _util;

    public CloudflareSecurityUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ICloudflareSecurityUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
