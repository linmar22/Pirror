using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PirrorConfigLib.Model;

namespace PirrorConfigLib
{
    public class PirrorConfigurationAccess
    {


        public PirrorConfiguration GetDemoConfiguration()
        {
            var demoConf = PirrorConfiguration.GetSampleConfiguration();
            return demoConf;
        }   
    }
}
