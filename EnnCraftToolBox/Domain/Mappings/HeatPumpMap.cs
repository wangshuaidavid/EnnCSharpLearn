using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Mappings
{
    class HeatPumpMap : ClassMap<HeatPump>
    {

        public HeatPumpMap()
        {
            Id(x => x.Id);
            Map(x => x.EquipName);
            Map(x => x.EquipDescription);

            Map(x => x.DrillNum);
            Map(x => x.DrillHoleDiameter);
            Map(x => x.DrillHoleSpace);
            Map(x => x.DrillNConstant);
            Map(x => x.DrillRadius);
            Map(x => x.UPipeInnerDiameter);
            Map(x => x.UPipeOutterDiameter);
            Map(x => x.UPipeEquivalDiameter);
            Map(x => x.UPipeHeatConductivity);
            Map(x => x.UPipeHeatTransferConductivity);
            Map(x => x.SoilHeatEquivalConductivity);
            Map(x => x.SoilHeatDiffusivity);
            Map(x => x.SoilRunningTime);
            Map(x => x.SoilAverTemperature);
            Map(x => x.LiquidHeatConductivity);
            Map(x => x.PulseTime);
            Map(x => x.CoolingRatedLoad);
            Map(x => x.CoolingRatio);
            Map(x => x.CoolingLiquidTemperature);
            Map(x => x.CoolingRunningHours);
            Map(x => x.CoolingTotalHours);
            Map(x => x.HeatRatedLoad);
            Map(x => x.HeatRatio);
            Map(x => x.HeatLiquidTemperature);
            Map(x => x.HeatHours);
            Map(x => x.HeatTotalHours);

            References<IOPort>(x => x.EleQIn).Unique().Cascade.All();
            References<IOPort>(x => x.CwQIn).Unique().Cascade.All();

            References<IOPort>(x => x.CoolingQOut).Unique().Cascade.All();
            References<IOPort>(x => x.LostQOut).Unique().Cascade.All();
        }
    }
}
