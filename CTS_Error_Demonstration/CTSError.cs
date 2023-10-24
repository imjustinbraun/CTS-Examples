using T4;
using T4.API;

namespace CTS_Error_Demonstration
{
    public class CTSError
    {
        public Host CTSHost { get; set; }

        public CTSError()
        {
            CTSHost = new(
                APIServerType.Simulator,
                "T4Example",
                "112A04B0-5AAF-42F4-994E-FA7CB959C60B",
                "CTSDev",
                "testUser",
                "123467"
                );
        }
    }
}