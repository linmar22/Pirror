using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PirrorConfigLib.Enums;

namespace PirrorConfigLib.Model
{
    public class SensorSettings
    {
        public SensorSettings(ScreenActivationType screenActivationType, int activationDistance = 0)
        {
            ScreenActivationType = screenActivationType;
            ActivationDistance = activationDistance;
        }

        public ScreenActivationType ScreenActivationType { get; }
        public int ActivationDistance { get; }
    }
}
