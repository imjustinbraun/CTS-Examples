using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4;
using T4.API;

namespace CTS_Error_Demonstration
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Host host = new(
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