﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{

    public enum IOPortType
    {
        InputTypePort,
        OutputTypePort,
    }

    public class IOPort
    {

        public virtual int Id { get; set; }

        public virtual IOPortType Type { get; set; }

        public virtual string PortName { get; set; }

        public virtual double PortValue { get; set; }

        public virtual IOConnection RelevantIOConnection { get; set; }

        public virtual EnnEquipment BelongsToEquipment { get; set; }
    }
}