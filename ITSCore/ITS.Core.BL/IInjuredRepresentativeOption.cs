﻿using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IInjuredRepresentativeOption
    {
        IEnumerable<InjuredRepresentativeOption> GetAllInjuredRepresentativeOption();
    }
}