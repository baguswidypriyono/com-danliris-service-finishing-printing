﻿using Com.Danliris.Service.Finishing.Printing.Lib.Models.Master.Machine;
using Com.Danliris.Service.Production.Lib;
using Com.Danliris.Service.Production.Lib.Services.IdentityService;
using Com.Danliris.Service.Production.Lib.Utilities;
using Com.Danliris.Service.Production.Lib.Utilities.BaseClass;
using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Danliris.Service.Finishing.Printing.Lib.BusinessLogic.Implementations.Master.Machine
{
    public class MachineStepLogic : BaseLogic<MachineStepModel>
    {
        private const string UserAgent = "production-service";

        public MachineStepLogic(IIdentityService identityService, ProductionDbContext dbContext) : base(identityService, dbContext)
        {
        }

        public override void CreateModel(MachineStepModel model)
        {
            do
            {
                model.Code = CodeGenerator.Generate();
            }
            while (DbSet.Any(d => d.Code.Equals(model.Code)));

            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            base.CreateModel(model);
        }

        public HashSet<int> MachineStepIds(int id)
        {
            return new HashSet<int>(DbSet.Where(d => d.MachineId == id).Select(d => d.Id));
        }
    }
}
