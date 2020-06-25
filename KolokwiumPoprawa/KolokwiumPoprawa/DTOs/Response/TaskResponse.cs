﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.DTOs.Response
{
    public class TaskResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string ProjectName { get; set; }
        public string TaskType { get; set; }
    }
}
