using Common.Gen;
using Sample.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cna.Erp.Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperFlow.Flow(args, () =>
            {

                return new ConfigExternalResources().GetConfigExternarReources();

            }, new HelperSysObjects(new ConfigContext().GetConfigContext()));
        }

    }
}
