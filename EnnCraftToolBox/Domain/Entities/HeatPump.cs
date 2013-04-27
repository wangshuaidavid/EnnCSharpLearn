using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HeatPump : Equipment
    {
        public virtual double DrillNum { get; set; }
        public virtual double DrillHoleDiameter { get; set; }
        public virtual double DrillHoleSpace { get; set; }
        public virtual double DrillNConstant { get; set; }
        public virtual double DrillRadius { get; set; }

        public virtual double UPipeInnerDiameter { get; set; }
        public virtual double UPipeOutterDiameter { get; set; }
        public virtual double UPipeEquivalDiameter { get; set; }
        public virtual double UPipeHeatConductivity { get; set; }
        public virtual double UPipeHeatTransferConductivity { get; set; }

        public virtual double SoilHeatEquivalConductivity { get; set; }
        public virtual double SoilHeatDiffusivity { get; set; }
        public virtual double SoilRunningTime { get; set; }
        public virtual double SoilAverTemperature { get; set; }

        public virtual double LiquidHeatConductivity { get; set; }

        public virtual double PulseTime { get; set; }

        public virtual double CoolingRatedLoad { get; set; }
        public virtual double CoolingRatio { get; set; }
        public virtual double CoolingLiquidTemperature { get; set; }
        public virtual double CoolingRunningHours { get; set; }
        public virtual double CoolingTotalHours { get; set; }

        public virtual double HeatRatedLoad { get; set; }
        public virtual double HeatRatio { get; set; }
        public virtual double HeatLiquidTemperature { get; set; }
        public virtual double HeatHours { get; set; }
        public virtual double HeatTotalHours { get; set; }

        public virtual IOPort EleQIn { get; set; }
        public virtual IOPort CwQIn { get; set; }

        public virtual IOPort CoolingQOut { get; set; }
        public virtual IOPort LostQOut { get; set; }    
    }
}
