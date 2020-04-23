﻿using Kolokwium.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        List<PrescriptionResponse> GetPrescription(int id);
    }
}
