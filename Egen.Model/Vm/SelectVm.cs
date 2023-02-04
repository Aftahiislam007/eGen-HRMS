﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Model.Vm
{
    [Serializable]
    public class SelectVm
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
